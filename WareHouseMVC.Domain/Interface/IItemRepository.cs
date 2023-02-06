using System;
using WareHouseMVC.Domain.Model;
using Type = WareHouseMVC.Domain.Model.Type;

namespace WareHouseMVC.Domain.Interface
{
    public interface IItemRepository
    {

        void DeleteItem(int itemId);


        int AddItem(Item item);


        IQueryable<Item> GetItemsByTypeId(int typeId);


        Item GetItemById(int itemId);


        IQueryable<Tag> GetAllTag();


        IQueryable<Type> GetAllType();


    }
}



