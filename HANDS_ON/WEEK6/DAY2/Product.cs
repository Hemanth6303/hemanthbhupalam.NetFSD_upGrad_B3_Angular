using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}, Price: {Price}";
        }
    }
}
