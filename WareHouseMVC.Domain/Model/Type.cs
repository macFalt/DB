﻿using System;
namespace WareHouseMVC.Domain.Model
{
    public class Type
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }





    }
}
