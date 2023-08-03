using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{
    public class Clients
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                var year = DateTime.Now.Year - DateOfBirth.Year;
                if (DateTime.Now.Month > DateOfBirth.Month)
                    year--;
                return year;
            }
        }
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? Users { get; set; }
    }
}

