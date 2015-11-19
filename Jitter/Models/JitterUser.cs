using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jitter.Models
{
    public class JitterUser
    {
        [Key]
        public int JitterUserId { get; set; }
        
        [MaxLength(161)]
        public object Description { get; set; }

        public object FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [RegularExpression(@"^[a-z\d]+[-_a-zA-Z\d]{0,2}[a-zA-Z\d]+")]
        public object Handle { get; set; }

        public object LastName { get; set; }
        public object Picture { get; set; }
    }
}