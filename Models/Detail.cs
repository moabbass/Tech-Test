using NuGet.Packaging.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace Verto.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public string name { get; set; } 
        
        public string content { get; set; }
        public string buttonName { get; set; }
        public string pictureName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile picture { get; set; }


        public Detail()
        {
            
        }
    }
}
