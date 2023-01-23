﻿using System;
namespace WareHouseMVC.Domain.Model
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public virtual Type Type { get; set; }

        public ICollection<ItemTag> ItemTags { get; set; }

    }
}
