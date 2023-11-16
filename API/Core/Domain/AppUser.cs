namespace API.Core.Domain
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}
