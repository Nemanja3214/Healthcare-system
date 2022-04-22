﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Data.Entities
{
    [Table("room")]
    public class Room
    {
        [Column("id")]
        public decimal Id { get; set; }

        [Column("name")]
        public string RoleName { get; set; }

        [Column("Room_type_id")]
        public decimal RoomTypeId  { get; set; }

        [Column("deleted")]
        public bool isDeleted { get; set; }

        public List<Inventory> Inventories { get; set; }
        //public List<Transfer> TransfersFrom { get; set; }
        //public List<Transfer> TransfersTo { get; set; }
        public RoomType RoomType { get; set; }
        public List<Operation> Operations { get; set; }

    }
}
