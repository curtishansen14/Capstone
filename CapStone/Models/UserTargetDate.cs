using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CapStone.Models
{
    public class UserTargetDate
    {
        [Key]
        public int UserTargetDateid { get; set; }

        [ForeignKey("AspNetUser")]
        public string Id { get; set; }
        public ApplicationUser AspNetUser { get; set; }

        public DateTime? datetime { get; set; }
    }
}