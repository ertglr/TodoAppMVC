using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.ENTITIES.EntityClass
{
    public class MyBaseClass
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Column(TypeName ="Date")]
        public DateTime? CreatedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }
        [Required]
        public string ModifiedUser { get; set; }


        public MyBaseClass()
        {
            if (CreatedOn==null)
            {
                CreatedOn = DateTime.Now.Date;
            }
        }
    }
}
