using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GunsOfTheOldWest.Ui.Mvc.Models
{
    public class Winner
    {
        public int Id { get; set; }

        [DisplayName("First name")]
        public required string FirstName { get; set; }

        [DisplayName("Last name")]
        public required string LastName { get; set; }

        [DisplayName("Email address")]
        [EmailAddress]
        public required string Email { get; set; }

        [DisplayName("Phone number")]        
        public required string PhoneNumber { get; set; }
        public required DateTime SubmissionDate { get; set; } = DateTime.Now;
    }
}
