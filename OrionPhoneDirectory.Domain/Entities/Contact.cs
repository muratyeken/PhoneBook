using OrionPhoneDirectory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPhoneDirectory.Domain.Entities
{
    public class Contact : BaseEntity
    {
        [ForeignKey("TheUser")]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Status Status { get; set; }
        public virtual User? TheUser { get; set; }

        
    }
}
