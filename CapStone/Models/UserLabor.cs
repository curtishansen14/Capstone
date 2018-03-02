using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CapStone.Models
{
    public class UserLabor
    {
        [Key]
        public int UserLaborId { get; set; }

        [ForeignKey("Labor")]
        public int Labor_ID { get; set; }
        public Labor Labor { get; set; }


        [ForeignKey("AspNetUser")]
        public string Id { get; set; }
        public ApplicationUser AspNetUser { get; set; }

        [ForeignKey("UserQuest")]
        public int UserQuestid { get; set; }
        public UserQuest UserQuest { get; set; }


        public bool isComplete { get; set; }

    }
}