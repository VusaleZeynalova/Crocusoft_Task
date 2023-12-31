﻿using Entity.BaseEntity;
using Entity.MemberShip;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class About :IEntity
    {
        public int AboutId { get; set; }
        public string? AboutText { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? Qualification { get; set; }
        public string? Email { get; set; }
        public AppUser User { get; set; }
        [ForeignKey("AppUser")]
        public int UserId { get; set; }
    }
}
