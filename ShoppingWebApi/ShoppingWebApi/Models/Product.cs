﻿using System;
namespace ShoppingWebApi.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Product()
        {
        }
    }
}
