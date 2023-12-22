using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPhoneDirectory.Domain.Entities
{
    public class BaseEntity
    {
        [Column(Order = 1)] //Tum entitylerde 1.kolon ID olacak sekilde ayarlandi
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
