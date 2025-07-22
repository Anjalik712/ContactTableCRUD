using System.ComponentModel.DataAnnotations;

namespace ContactProject.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }     
        public string? MiddleName { get; set; }     
        public string? LastName { get; set; }   
        public int Age { get; set; }
        public DateOnly DOB { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
