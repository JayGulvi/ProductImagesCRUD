using System.ComponentModel.DataAnnotations;

namespace ImageUploadCRUD.Models
{
    public class ProductsList
    {
        [Key]
        public int Id { get; set; }
        public string ProPhoto {  get; set; }
        public string ProName {  get; set; }    
        public string Description {  get; set; }
        public decimal Price { get; set; }
    }
}
