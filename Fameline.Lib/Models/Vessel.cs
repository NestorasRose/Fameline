using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fameline.Lib.Models
{
    public class Vessel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal MaxWeight { get; set; }

        public int FleetId { get; set; }

        public virtual Fleet Fleet { get; set; }

        public virtual ICollection<Container> Containers { get; set; }
    }
}
