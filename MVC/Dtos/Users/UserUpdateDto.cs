namespace E_CommerceWebsiteProject.MVC.Dtos.Users
{
    public class UserUpdateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public DateTime UpdatedAt{ get; set; }
    }
}