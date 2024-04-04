using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace crud_dotnet_api.data
{
    public class Banks

    {
       

        public Guid id { get; set; }
        [Required(ErrorMessage = "Reference code is required")]
        public string ref_code { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters and spaces")]
        public string name { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters and spaces")]
        public string sort_name { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits")]
        public string Mobile_no { get; set; }

        public  DateTime created_At { get; set; }
        
        public DateTime updated_at { get; set; }
        
    }
}
