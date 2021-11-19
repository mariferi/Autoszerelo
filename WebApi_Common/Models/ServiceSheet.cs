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

        public string WorkStatus { get; set; }
    }
}
