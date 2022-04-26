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
        [Required(ErrorMessage = "X Axis is required")]
        [Range(1,100, ErrorMessage = "Please enter a valid coordinate")]
        [Display(Name = "X Axis", Prompt = "Enter the spiders X Axis")]
        public int XAxis { get; set; }
        //this represents the spiders currents position on the Y axis
        [Required(ErrorMessage = "Y Axis is required")]
        [Range(1, 100, ErrorMessage = "Please enter a valid coordinate")]
        [Display(Name = "Y Axis", Prompt = "Enter the spiders Y Axis")]
        public int YAxis { get; set; }
        [Required(ErrorMessage = "Max X Axis is required")]
        [Range(1, 100, ErrorMessage = "Please enter a valid coordinate")]
        [Display(Name = "Max X Axis", Prompt = "Enter the maximum X Axis")]
        // defines the limit of the x axis
        public int MaxXAxis { get; set; }
        [Required(ErrorMessage = "Max Y Axis is required")]
        [Range(1, 100, ErrorMessage = "Please enter a valid coordinate")]
        [Display(Name = "Max Y Axis", Prompt = "Enter the maximum Y Axis")]
        //defines the limit of the y axis
        public int MaxYAxis { get; set; }
        [Required]
        [Display(Name = "Current Direction", Prompt = "Enter X Axis")]
        // this allows us to automatically set the index in the array based off the direction entered
        public string CurrentDirection { get; set; }
        [Required]
        [RegularExpression(@"\b[FLR]+\b(?![,])", ErrorMessage = "Please enter a valid command")]
        [Display(Name = "Command", Prompt = "Enter Command e.g FRFLFF")]
        public string Command { get; set; }
    }

    public enum Directions
    {
        Left,
        Right,
        Up,
        Down
    }
}
