namespace ProniaOnionAlpha.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            AccountRoles = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AccountRoles> AccountRoles { get; set; }
    }
}
