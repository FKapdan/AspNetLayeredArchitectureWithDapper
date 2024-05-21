using System.ComponentModel;

namespace Web.Models
{
    public class UserModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Surname")]
        public string Surname { get; set; }
        [DisplayName("Tel")]
        public string TelNo { get; set; }
        [DisplayName("Job")]
        public string Job { get; set; }
        [DisplayName("Adress")]
        public string Adress { get; set; }
    }
}
