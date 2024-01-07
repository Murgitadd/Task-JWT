namespace ProniaOnionAlpha.Domain.Entities
{
    public class Author:BaseNameableEntity
    {
        public Author()
        {
            AccountRoles = new();
        }
        public int Password { get; set; }
        public List<AccountRoles> AccountRoles { get; set; }
    }
}
