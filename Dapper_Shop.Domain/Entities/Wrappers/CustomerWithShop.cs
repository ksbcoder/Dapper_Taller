﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Shop.Domain.Entities.Wrappers
{
    public class CustomerWithShop
    {
        public int Customer_id { get; set; }
        public string Fullname { get; set; }
        public string Address_customer { get; set; }
        public string Phone_customer { get; set; }

        public Shop Shop { get; set; }
    }
}
