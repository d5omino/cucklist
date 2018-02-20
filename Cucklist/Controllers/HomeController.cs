using System.Diagnostics;
using System.Threading.Tasks;

using Cucklist.Data;
using Cucklist.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cucklist.Controllers
{
    public class HomeController :Controller
    {
        private readonly ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
        _context = context;
        }


        public async Task<IActionResult> Index()
        {
        return View(await _context.Post.ToListAsync());
        }




        public IActionResult Error()
        {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
