﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RavenTest.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Hand> Hands { get; set; }
    }
}