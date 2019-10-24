using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.ENTITIES.EntityClass
{
    public class Task: MyBaseClass
    {
        public string Text { get; set; }
        public bool IsComleted { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DueDate{ get; set; }
        public virtual User Owner { get; set; }
        

    }
}
