using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.ENTITIES.EntityClass
{
    public class History:MyBaseClass
    {
        [Required]
        [MaxLength(250,ErrorMessage ="250 karakterden fazla giriş yapılamaz")]
        public string Text { get; set; }

        public virtual User Owner { get; set; }

    }
}
