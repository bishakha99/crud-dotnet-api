using System.ComponentModel.DataAnnotations.Schema;

namespace crud_dotnet_api.data
{
    public class branches
    {
        public Guid id { get; set; }
        public string ref_code { get; set; }
        public string name { get; set; }
        public string short_name { get; set; }
        [ForeignKey("Banks")]
        public Guid bank_id { get; set; }
       
        public Banks Banks { get; set; }
        public string ifsc { get; set; }
        public string address { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }

    }
}
