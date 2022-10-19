using GProject2.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GProject2.Models
{
    public class Coach
    {
        [Key]
        public int CoachId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string DiscordName { get; set; }
        [Required]
        public string About { get; set; }
        public string Social { get; set; }
        [Required]
        [EmailAddress]
        public string PaypalAcc { get; set; }
        public string Achivment { get; set; }
        public GameType Game { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        //[RegularExpression(@"(?=.\d)(?=.[A-Za-z]).{8,}", ErrorMessage = "Your password must be at least 8 characters long and contain at least 1 letter and 1 number")]
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public int Price { get; set; }
        public string ShortDescription { get; set; }
        public string Sunday { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public Boolean IsCoachConfirmed { get; set; }
    }
}
