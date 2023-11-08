namespace UniverCom.Domain.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AppUser> Members { get; set; }
    }
}
