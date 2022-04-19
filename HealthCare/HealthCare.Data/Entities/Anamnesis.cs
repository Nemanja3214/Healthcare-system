﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Data.Entities
{
    [Table("anamnesis")]
    public class Anamnesis
    {
        [Column("description")]
        public string Description { get; set; }

        [Column("Examination_Doctor_id")]
        public int doctorId { get; set; }

        [Column("Examination_Room_id")]
        public int roomId { get; set; }

        [Column("Examination_Patient_id")]
        public int patientId { get; set; }

        [Column("Examination_examination_started")]
        public DateTime StartTime { get; set; }

        [Column("deleted")]
        public bool isDeleted { get; set; }
    }
}
