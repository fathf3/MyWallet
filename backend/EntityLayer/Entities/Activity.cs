﻿using CoreLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Activity : EntityBase, IEntityBase
    {
        public Activity() { }

        public Activity(string name)
        {
            Name = name;
            
        }

        public string Name { get; set; }
        
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Seans> Seans { get; set; }

    }
}
