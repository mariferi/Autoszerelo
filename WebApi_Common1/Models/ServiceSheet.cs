using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Common.Models
{
   public class ServiceSheet
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(20)]
        public string CarType { get; set; }
        [Required]
        [MaxLength(7)]
        public string LicensePlate { get; set; }

        [Required]
        [MaxLength(200)]
        public string ErrorDescription { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public string WorkStatus { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is ServiceSheet))
            {
                return false;
            }
            return (this.Id == ((ServiceSheet)obj).Id);
            
        }

        public override string ToString()
        {
            return $"Név:\t{CustomerName}\nAutó:\t{CarType} --- {LicensePlate}\nÁllapot:\t{WorkStatus}\nFelvéve:\t{Date.ToString("yyyy/MM/dd")}";
        }
    }
}
