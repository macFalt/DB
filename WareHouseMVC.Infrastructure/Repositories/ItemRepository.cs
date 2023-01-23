﻿using System;
using WareHouseMVC.Domain.Interface;
using WareHouseMVC.Domain.Model;
using Type = WareHouseMVC.Domain.Model.Type;

namespace WareHouseMVC.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly Context _context;

        public ItemRepository(Context context)
        {
            _context = context;

        }

        public void DeleteItem(int itemId)
        {
            var item = _context.Items.Find(itemId);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        public int AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item.Id;

        }

        public IQueryable<Item> GetItemsByTypeId(int typeId)
        {
            var items = _context.Items.Where(i => i.TypeId == typeId);
            return items;


        }

        public Item GetItemById(int itemId)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == itemId);
            return item;



        }

        public IQueryable<Tag> GetAllTag()
        {
            var tags = _context.Tags;
            return tags;


        }

        public IQueryable<Type> GetAllType()
        {
            var types = _context.Types;
            return types;
        }



    }
}
