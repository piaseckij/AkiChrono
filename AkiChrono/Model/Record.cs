using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkiChrono.Model
{
    public class Record
    {
        public int Id { get; set; }
        public string Pilot { get; set; }

        [Column(TypeName = "bigint")]
        public TimeSpan TimeSum { get; set; }

        public int PlaneId { get; set; }
        public DateTime DateAdded { get; set; }

        public Plane Plane { get; set; }
    }
}
