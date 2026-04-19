namespace Contact_Management_System__JWT___EF_Core_.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public ICollection<ContactInfo> Contacts { get; set; }
    }
}
