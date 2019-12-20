using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Daniel_Donbavand.Models;

namespace WebApi_Daniel_Donbavand.Services
{
    public interface IInventoryServices
    {
        InventoryItems AddInventoryItems(InventoryItems items);
        Dictionary<string, InventoryItems> GetInventoryItems();
    }
}
