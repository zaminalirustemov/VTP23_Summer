namespace Participant_Panel.Entites.Domains
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool isDeleted { get; set; }

        public List<AppUser>? AppUsers { get; set; }
    }
}
