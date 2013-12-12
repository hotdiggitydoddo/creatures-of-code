using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JotAThought.Web.Models
{
    public class CreatePostViewModel
    {
        [Required, StringLength(255, MinimumLength=3)]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }

        public string Author { get; set; }

        public int ID { get; set; }

        public bool UpdateMe { get; set; }
    }
}