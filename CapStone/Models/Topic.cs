using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapStone.Models
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }

        public string theme { get; set; }
    }
}