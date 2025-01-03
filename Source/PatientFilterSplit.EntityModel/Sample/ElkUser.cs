using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PatientFilterSplit.EntityModel.Sample
{
    public class ElkUser
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
