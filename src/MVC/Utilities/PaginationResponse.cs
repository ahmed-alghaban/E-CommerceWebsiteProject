namespace E_CommerceWebsiteProject.src.MVC.Utilities
{
    public class PaginationResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalOfPages { get; set; }
        public List<T>? Data { get; set; }

    }
}