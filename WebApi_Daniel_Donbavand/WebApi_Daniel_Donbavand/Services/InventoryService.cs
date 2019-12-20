using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Daniel_Donbavand.Models;

namespace WebApi_Daniel_Donbavand.Services
{
    public class InventoryServices : IInventoryServices
    {
        private readonly Dictionary<string, InventoryItems> _inventoryItems;

        public InventoryServices()
        {
            _inventoryItems = new Dictionary<string, InventoryItems>();
        }
        public InventoryItems AddInventoryItems(InventoryItems items)
        {
            Console.WriteLine(items);
            _inventoryItems.Add(items.ItemName, items);
            return items;
        }

        public Dictionary<string, InventoryItems> GetInventoryItems()
        {
            return _inventoryItems;
        }
    }
}
