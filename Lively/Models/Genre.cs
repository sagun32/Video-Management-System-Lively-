﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lively.Models;
using System.ComponentModel.DataAnnotations;

namespace Lively.Models
{
    public class Genre
    {
        public byte ID { get; set; }

        [Required]
        [StringLength (255)]
        public string Name { get; set; }
    }
}