﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSB.Messages
{
    public class Position
    {
        public int PortfolioId { get; set; }
        public string Security { get; set; }
        public int NumberOfShares { get; set; }
    }
}
