using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkiChrono.Model
{
    public class Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "bigint")]
        public TimeSpan TotalTime { get; set; } = TimeSpan.FromHours(100);

        [Column(TypeName = "bigint")]
        public TimeSpan TimeProp { get; set; } = TimeSpan.FromHours(100);

        [Column(TypeName = "bigint")]
        public TimeSpan TimeAirframe { get; set; } = TimeSpan.FromHours(100);

        [Column(TypeName = "bigint")]
        public TimeSpan TimeEngine { get; set; } = TimeSpan.FromHours(100);

    }
}
