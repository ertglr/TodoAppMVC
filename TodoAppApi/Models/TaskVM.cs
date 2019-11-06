using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoAppApi.Models
{
    public class TaskVM
    {
        public Guid ID { get; set; }
        [Required]
        public string Text { get; set; }
        public bool IsComplated { get; set; }

        public string ModifiedUser { get; set; }
    }
}