using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fameline.Lib.Models
{
    public class Container
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Weight { get; set; }

        public int VesselId { get; set; }

        public virtual Vessel Vessel { get; set; }
    }
}
