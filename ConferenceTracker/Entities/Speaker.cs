using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceTracker.Entities
{
    public class Speaker : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (EmailAddress != null
                && EmailAddress.EndsWith("TechnologyLiveConference.com",
                StringComparison.OrdinalIgnoreCase))
            {
                result.Add(new ValidationResult
                    ("Technology Live Conference staff should not use their conference email addresses"));
            }

            return result;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First name")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        [MinLength(2)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(500)]
        [MinLength(10)]
        public string Description { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public bool IsStaff { get; set; }
    }
}
