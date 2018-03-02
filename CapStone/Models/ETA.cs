using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapStone.Models
{
    public class ETA
    {
        [Key]
        public int ETA_ID { get; set; }
        public string TIME { get; set; }
    }
}