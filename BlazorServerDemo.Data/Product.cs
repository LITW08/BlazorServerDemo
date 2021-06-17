﻿using System;
using System.ComponentModel.Design;

namespace BlazorServerDemo.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public short UnitsInStock { get; set; }
    }
}
