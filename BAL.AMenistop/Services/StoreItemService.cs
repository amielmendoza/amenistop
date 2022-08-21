using BAL.AMenistop.Common;
using BAL.AMenistop.Interfaces;
using BAL.AMenistop.Models;
using DAL.AMenistop.Command;
using DAL.AMenistop.DTO;
using DAL.AMenistop.Interfaces;
using System;
using System.Collections.Generic;

namespace BAL.AMenistop.Services
{
    public class StoreItemService : IStoreItemService
    {
        public ResultObject<StoreItem> Add(StoreItem model)
        {
            try
            {
                StoreItemDTO storeItem = new StoreItemDTO()
                {
                    Name = model.Name,
                    SellPrice = model.SellPrice,
                    BuyPrice = model.BuyPrice,
                    Quantity = model.Quantity
                };
                NewStoreItemCommand command = new NewStoreItemCommand(storeItem);
                storeItem = command.Add();
                ResultObject<StoreItem> result = new ResultObject<StoreItem>()
                {
                    Data = new StoreItem()
                    {
                        Id = storeItem.Id,
                        Name = storeItem.Name,
                        SellPrice = storeItem.SellPrice,
                        BuyPrice = storeItem.BuyPrice,
                        Quantity = storeItem.Quantity
                    }
                };

                return result;
            }
            catch (Exception ex)
            {
                ResultObject<StoreItem> result = new ResultObject<StoreItem>()
                {
                    HasError = true,
                    Exception = ex.Message
                };
                return result;
            }
        }

        public ResultObject<StoreItem> Delete(int id)
        {
            try
            {
                DeleteStoreItemCommand command = new DeleteStoreItemCommand(id);
                command.Delete();

                return new ResultObject<StoreItem>();
            }
            catch (Exception ex)
            {
                ResultObject<StoreItem> result = new ResultObject<StoreItem>()
                {
                    HasError = true,
                    Exception = ex.Message
                };
                return result;
            }
        }

        public ResultObjectList<StoreItem> GetAll()
        {
            try
            {
                GetStoreItemCommand command = new GetStoreItemCommand();
                IEnumerable<StoreItemDTO> storeItems = command.GetAll();
                List<StoreItem> data = new List<StoreItem>();

                foreach (var storeItem in storeItems)
                {
                    data.Add(new StoreItem()
                    {
                        Id = storeItem.Id,
                        Name = storeItem.Name,
                        SellPrice = storeItem.SellPrice,
                        BuyPrice = storeItem.BuyPrice,
                        Quantity = storeItem.Quantity
                    });
                }

                ResultObjectList<StoreItem> result = new ResultObjectList<StoreItem>()
                {
                    Data = data
                };

                return result;
            }
            catch (Exception ex)
            {
                ResultObjectList<StoreItem> result = new ResultObjectList<StoreItem>()
                {
                    HasError = true,
                    Exception = ex.Message
                };
                return result;
            }
        }

        public ResultObject<StoreItem> GetById(int id)
        {
            try
            {
                GetStoreItemCommand command = new GetStoreItemCommand();
                StoreItemDTO storeItem = command.GetById(id);

                ResultObject<StoreItem> result = new ResultObject<StoreItem>()
                {
                    Data = new StoreItem()
                    {
                        Id = storeItem.Id,
                        Name = storeItem.Name,
                        SellPrice = storeItem.SellPrice,
                        BuyPrice = storeItem.BuyPrice,
                        Quantity = storeItem.Quantity
                    }
            };

                return result;
            }
            catch (Exception ex)
            {
                ResultObject<StoreItem> result = new ResultObject<StoreItem>()
                {
                    HasError = true,
                    Exception = ex.Message
                };
                return result;
            }
        }

        public ResultObject<StoreItem> Update(StoreItem model)
        {
            try
            {
                StoreItemDTO storeItem = new StoreItemDTO()
                {
                    Id = model.Id,
                    Name = model.Name,
                    SellPrice = model.SellPrice,
                    BuyPrice = model.BuyPrice,
                    Quantity = model.Quantity
                };
                UpdateStoreItemCommand command = new UpdateStoreItemCommand(storeItem);
                command.Update();

                ResultObject<StoreItem> result = new ResultObject<StoreItem>()
                {
                    Data = new StoreItem()
                    {
                        Id = storeItem.Id,
                        Name = storeItem.Name,
                        SellPrice = storeItem.SellPrice,
                        BuyPrice = storeItem.BuyPrice,
                        Quantity = storeItem.Quantity
                    }
                };

                return result;
            }
            catch (Exception ex)
            {
                ResultObject<StoreItem> result = new ResultObject<StoreItem>()
                {
                    HasError = true,
                    Exception = ex.Message
                };
                return result;
            }
        }
    }
}
