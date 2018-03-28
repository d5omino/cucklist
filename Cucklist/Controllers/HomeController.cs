using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Cucklist.Data;
using Cucklist.Models;
using Cucklist.Models.HomeViewModels;

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


        List<Image> images=await _context.Image.ToListAsync();
        List<Video> videos=await _context.Video.ToListAsync();
        List<Audio> clips=await _context.Audio.ToListAsync();
        IndexViewModel model = new IndexViewModel(images,videos,clips);

        return View(model);
        }




        public IActionResult Error()
        {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
