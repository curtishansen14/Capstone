using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CapStone.Models
{
    public class Labor
    {
        [Key]
        public int Labor_ID { get; set; }

        [ForeignKey("Quest")]
        [ScriptIgnore]
        public int Quest_ID { get; set; }
        [ScriptIgnore]
        public Quest Quest { get; set; }


        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(509)]
        public string Description { get; set; }

        [ForeignKey("ETA")]
        public int ETA_ID { get; set; }
        public ETA ETA { get; set; }

        public string Location { get; set; }
    }
}