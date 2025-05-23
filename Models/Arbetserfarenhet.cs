﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models
{
    public class Arbetserfarenhet
    {
        [Key]
        public int ArbetserfarenhetID { get; set; }

        [Required, StringLength(50)]

        public string Företag { get; set; }

        [Required, StringLength(50)]

        public string Jobbtitel { get; set; }

        [Required, StringLength(100)]// Inte för mycket text nåå
        public string Jobbbeskrivning { get; set; }

        public DateOnly Jobbstart { get; set; }

        public DateOnly Jobbslut { get; set; }

        [ForeignKey("Person")]
        public int PerosonID_FK { get; set; }
        public virtual Person Person { get; set; } // FK relation till Person
        public int PersonId_FK { get; internal set; }
    }
}
