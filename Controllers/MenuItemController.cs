using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuItemListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        // GET: api/MenuItem
        public static List<MenuItem> menuItemList = new List<MenuItem>()
        {
            new MenuItem{Id=1, Name = "Sandwich",FreeDelivery = true, Price = 25.00, DateOfLaunch = Convert.ToDateTime("2020-07-24"),Active = true},
            new MenuItem{Id=2, Name = "Noodeles",FreeDelivery = true, Price = 50.00, DateOfLaunch = Convert.ToDateTime("2020-07-24"),Active = true},
            new MenuItem{Id=3, Name = "Pizza",FreeDelivery = true, Price = 120.00, DateOfLaunch = Convert.ToDateTime("2020-07-24"),Active = true},
            new MenuItem{Id=4, Name = "Burger",FreeDelivery = true, Price = 60.00, DateOfLaunch = Convert.ToDateTime("2020-07-24"),Active = true},
            new MenuItem{Id=5, Name = "Hot Dog",FreeDelivery = true, Price = 80.00, DateOfLaunch = Convert.ToDateTime("2020-07-24"),Active = true}

        };

        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            //return new string[] { "value1", "value2" };
            return menuItemList.ToList();
        }

        // GET: api/MenuItem/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            //return "value";
            MenuItem item = menuItemList.Where(x => x.Id == id).FirstOrDefault();
            return Convert.ToString(item.Name);
        }
    }
}

