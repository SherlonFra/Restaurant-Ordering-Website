using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManager.Data;
using RestaurantManager.Models;

namespace RestaurantManager.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        // Using DI to get the configuration object from the app and the AppDbContext
        public StoreController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Categories.OrderBy(c => c.Name).ToList());
        }

        public IActionResult Items(int id)
        {
            var Menuitems = _dbContext.Menuitems
                            .Where(i => i.CategoryId == id)
                            .OrderBy(i => i.Name)
                            .ToList<Menuitem>();
            return View(Menuitems);
        }
    }
}
