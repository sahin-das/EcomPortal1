namespace EcomPortal.Models.Dtos.Product
{
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
