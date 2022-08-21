using DAL.AMenistop.DTO;
using DAL.AMenistop.Interfaces;
using DAL.AMenistop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AMenistop.Repositories
{
    internal class StoreItemRepository : IStoreItemRepository
    {
        public StoreItem Add(StoreItem model)
        {
            using (var context = new AMenistopContext())
            {
                context.StoreItems.Add(model);
                context.SaveChanges();
            }

            return model;
        }

        public void Delete(int id)
        {
            using (var context = new AMenistopContext())
            {
                StoreItem storeItem = context.StoreItems.FirstOrDefault(x => x.Id == id);
                context.StoreItems.Remove(storeItem);
                context.SaveChanges();
            }
        }

        public IEnumerable<StoreItem> GetAll()
        {
            IEnumerable<StoreItem> result;
            using (var context = new AMenistopContext())
            {
                result = context.StoreItems.ToList();
            }

            return result;
        }

        public StoreItem GetById(int id)
        {
            StoreItem storeItem;
            StoreItemDTO result;
            using (var context = new AMenistopContext())
            {
                storeItem = context.StoreItems.FirstOrDefault(x => x.Id == id);
                result = new StoreItemDTO()
                {
                    Id = storeItem.Id,
                    Name = storeItem.Name,
                    SellPrice = storeItem.SellPrice,
                    BuyPrice = storeItem.BuyPrice,
                    Quantity = storeItem.Quantity
                };
            }

            return storeItem;
        }

        public void Update(StoreItem model)
        {
            using (var context = new AMenistopContext())
            {
                StoreItem storeItem = context.StoreItems.FirstOrDefault(x => x.Id == model.Id);
                storeItem.Name = model.Name;
                storeItem.SellPrice = model.SellPrice;
                storeItem.BuyPrice = model.BuyPrice;
                storeItem.Quantity = model.Quantity;
                context.SaveChanges();
            }
        }
    }
}
