using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VoterAppMVC.Models
{
    public class Voter
    {
        [Required]
        public int voterid { get; set; }

        [Required]
        [StringLength(75,ErrorMessage ="Name length must be less tahn 76")]
        public string votername { get; set; }
        [Required]
        public string vaddress { get; set; }
    }
}