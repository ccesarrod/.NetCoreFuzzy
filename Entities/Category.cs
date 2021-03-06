﻿using System.Collections.Generic;

namespace fuzzy.core.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
       
        public ICollection<Product> Products { get; set; }
    }
}
