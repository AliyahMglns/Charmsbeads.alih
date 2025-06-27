using Inventory_BusinessDataLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using InventoryDataService;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharmBeadsController : ControllerBase
    {
        InventoryService inventoryService = new InventoryService();

        [HttpGet("beads")]
        public IEnumerable<InventorySupplies> GetBeads()
        {
            return InventorySupplies.ItemStock.BeadStocks;
        }

        [HttpGet("charms")]
        public IEnumerable<InventorySupplies> GetCharms()
        {
            return InventorySupplies.ItemStock.CharmStocks;
        }

        [HttpPost("beads")]
        public bool AddBead(InventorySupplies item)
        {
            inventoryService.AddItem("bead", item.Name, item.Quantity);
            BeadsStorage.SaveBeads(InventorySupplies.ItemStock.BeadStocks.Select(b => $"{b.Name}: {b.Quantity}").ToList());
            return true;
        }

        [HttpPost("charms")]
        public bool AddCharm(InventorySupplies item)
        {
            inventoryService.AddItem("charm", item.Name, item.Quantity);
            BeadsStorage.SaveCharms(InventorySupplies.ItemStock.CharmStocks.Select(c => $"{c.Name}: {c.Quantity}").ToList());
            return true;
        }

        [HttpDelete("beads")]
        public bool RemoveBead(string name, int qty)
        {
            var result = inventoryService.RemoveItem("bead", name, qty);
            if (result)
            {
                BeadsStorage.SaveBeads(InventorySupplies.ItemStock.BeadStocks.Select(b => $"{b.Name}: {b.Quantity}").ToList());
            }
            return result;
        }

        [HttpDelete("charms")]
        public bool RemoveCharm(string name, int qty)
        {
            var result = inventoryService.RemoveItem("charm", name, qty);
            if (result)
            {
                BeadsStorage.SaveCharms(InventorySupplies.ItemStock.CharmStocks.Select(c => $"{c.Name}: {c.Quantity}").ToList());
            }
            return result;
        }
    }
}
