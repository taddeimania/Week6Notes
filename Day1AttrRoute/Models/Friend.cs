﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Day1AttrRoute.Models
{
    public class Friend
    {
        public int Id { get; set; }

        public string RequestorId { get; set; }

        [ForeignKey("RequestorId")]
        public virtual ApplicationUser Requestor { get; set; }

        public string TargetId { get; set; }

        [ForeignKey("TargetId")]
        public virtual ApplicationUser Target { get; set; }
    }
}