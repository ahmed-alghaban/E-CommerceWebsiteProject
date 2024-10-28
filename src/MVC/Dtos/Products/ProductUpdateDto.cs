namespace E_CommerceWebsiteProject.src.MVC.Dtos.Products
{
    public class ProductUpdateDto
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryID { get; set; }
        public Guid StoreID { get; set; }
    }
}