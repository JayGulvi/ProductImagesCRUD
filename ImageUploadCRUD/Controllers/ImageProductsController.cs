using ImageUploadCRUD.Data;
using ImageUploadCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ImageUploadCRUD.Controllers
{
    public class ImageProductsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment env;
        public ImageProductsController(ApplicationDbContext db,IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        public IActionResult Index()
        {
            var data  =  db.ProductsImg.ToList();
            return View(data);
        }
        public IActionResult AddProducts()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProducts(ProductListImage p)
        {

            var path = env.WebRootPath;
            var filepath = "Photo/" + p.ProPhoto.FileName;
            var fullpath = Path.Combine(path, filepath);
            UploadFiles(p.ProPhoto, fullpath);

            var a = new ProductsList()
            {
                ProPhoto = filepath,
                ProName = p.ProName,
                Description = p.Description,
                Price = p.Price,
            };

            db.ProductsImg.Add(a);
            db.SaveChanges();
            TempData["SuccessMsg"] = "Product Added Successfully";
            return RedirectToAction("Index", "ImageProducts");
        }

        private void UploadFiles(IFormFile file, string path)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = db.ProductsImg.Find(id);
            if(data == null)
            {
                return NotFound();
            }
            db.ProductsImg.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index", "ImageProducts");
        }
        
        public IActionResult Update(int id)
        { 
            var d = db.ProductsImg.Find(id);
            return View(d);
        }
        [HttpPost]
        public IActionResult Update(ProductListImage pro, int id)
        {
            var data = db.ProductsImg.Find(id);
            var path = env.WebRootPath;
            var filepath = "Photo/" + pro.ProPhoto.FileName;
            var fullpath = Path.Combine(path, filepath);
            UploadFiles(pro.ProPhoto, fullpath);

            data.ProPhoto = filepath;
            data.ProName =pro.ProName;
            data.Description =pro.Description;
            data.Price =pro.Price;

            db.ProductsImg.Update(data);
            db.SaveChanges();
            TempData["UptMsg"] = "Product update successfully";
            return RedirectToAction("Index");
        }
    }
}
