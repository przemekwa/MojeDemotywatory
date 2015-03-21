﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi
{
    public class Page
    {
        public int PageNumber { get; set; }

        public List<Demotywator> DemotywatorList { get; set; }

        public Page(int pageNumber)
        {
            this.DemotywatorList = new List<Demotywator>();

            this.PageNumber = pageNumber;
        }
    }
}