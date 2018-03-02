using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CapStone.Models
{
    public class UserQuest
    {
        [Key]
        public int UserQuestid { get; set; }
        //make sure the userquest is unique on quest id and user id tables. so there can only be one userquest object for both a user and a quest
        [ForeignKey("Quest")]

        public int Quest_ID { get; set; }
        public Quest Quest { get; set; }

        [ForeignKey("AspNetUser")]
        public string Id { get; set; }
        public ApplicationUser AspNetUser { get; set; }

        [Display(Name = "Active")]
        public bool isActive { get; set; }

        [Display(Name = "Complete")]
        public bool isComplete { get; set; }
        
        [Display(Name = "Rating")]
        public int? rating { get; set; }

        [Display(Name = "Target Date")]
        public DateTime? Target { get; set; }

        public List<UserLabor> UserLabors { get; set; }
        public decimal PercentComplete()
        {
            decimal completionPercentage;
            ApplicationDbContext db = new ApplicationDbContext();
            var completedLabors = db.UserLabors.Where(x => x.isComplete == true && x.UserQuestid == x.UserQuest.UserQuestid).Count();
            var totalLabors = db.UserLabors.Where(y => y.UserQuestid == y.UserQuest.UserQuestid).Count();

            completionPercentage = 100 * ((decimal)completedLabors / totalLabors);
            completionPercentage = Decimal.Round(completionPercentage, 0);
            return completionPercentage;
        }
    }
}