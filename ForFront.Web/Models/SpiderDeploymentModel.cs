using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForFront.Web.Models
{
    public class SpiderDeploymentModel
    {
        //this represents the spiders current position on the X axis
        [Required]
        [Range(0,100)]
        public int XAxis { get; set; }
        //this represents the spiders currents position on the Y axis
        [Required]
        [Range(0, 100)]
        public int YAxis { get; set; }
        [Required]
        [Range(0, 100)]
        // defines the limit of the x axis
        public int MaxXAxis { get; set; }
        [Required]
        [Range(0, 100)]
        //defines the limit of the y axis
        public int MaxYAxis { get; set; }
        [Required]
        [RegularExpression(@"\b(Left|Right|Up|Down)\b", ErrorMessage = "Please enter a valid direction")]
        // this allows us to automatically set the index in the array based off the direction entered
        public string CurrentDirection { get; set; }
        [RegularExpression(@"\b[FLR]+\b(?![,])", ErrorMessage = "Please enter a valid command")]
        public string Command { get; set; }
    }
}
