﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TireDep.Domain.Model
{
    public class Deposit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TireTreadHeight { get; set; }
        public SeasonTire SeasonTire { get; set; }
        public Owner Owner { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
    }
}
 