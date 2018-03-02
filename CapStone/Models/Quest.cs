using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace CapStone.Models
{
    public class Quest
    {
        [Key]
        public int Quest_ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        //[DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("ETA")]
        public int ETA_ID { get; set; }
        public ETA ETA { get; set; }
        public virtual IEnumerable<SelectListItem> ETAs { get; set; }

        [Required]
        [ForeignKey("Topic")]
        public int TopicID { get; set; }
        public Topic Topic { get; set; }
        public virtual IEnumerable<SelectListItem> Topics { get; set; }

        [Display(Name = "Flag")]
        public bool isFlagged { get; set; }

        public List<Labor> Labors { get; set; }

        //public decimal aggregateRating {get; set; } ? 

    }
}