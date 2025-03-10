﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [StringLength(50)]
        public string ContactUserName { get; set; }
        [StringLength(50)]
        public string ContactMail { get; set; }
        [StringLength(50)]
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }
    }
}
