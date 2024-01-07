namespace ProniaOnionAlpha.Domain.Entities
{
    public class AccountRoles
    {
        public int RoleId { get; set; }
        public int AuthorId { get; set; }
        public  Role Role { get; set; }
        public Author Author { get; set; }
    }
}
