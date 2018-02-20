﻿using System.Linq;
using System.Threading.Tasks;

using Cucklist.Data;
using Cucklist.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cucklist.Controllers
{
    [Authorize]
    public class PostsController :Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
        _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
        return View(await _context.Post.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
        if ( id == null )
        {
        return NotFound();
        }

        var post = await _context.Post
                .SingleOrDefaultAsync(m => m.PostId == id);
        if ( post == null )
        {
        return NotFound();
        }

        return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
        return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Title,Description,Link")] Post post)
        {

        /*string currentuser=User.Identity.Name;*/

        string currentUserId = User.Identity.GetUserId();

        ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);

        post.Owner = currentUser.UserName;
        post.UserId = currentUser.Id;

        ModelState.Merge(dictionary: null);


        if ( ModelState.IsValid )
        {
        _context.Add(post);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
        }
        return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
        if ( id == null )
        {
        return NotFound();
        }

        var post = await _context.Post.SingleOrDefaultAsync(m => m.PostId == id);
        if ( post == null )
        {
        return NotFound();
        }
        return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("PostId,Title,Description,Link,UserId,Owner")] Post post)
        {
        if ( id != post.PostId )
        {
        return NotFound();
        }

        if ( ModelState.IsValid )
        {
        try
        {
        _context.Update(post);
        await _context.SaveChangesAsync();
        }
        catch ( DbUpdateConcurrencyException )
        {
        if ( !PostExists(post.PostId) )
        {
        return NotFound();
        }
        else
        {
        throw;
        }
        }
        return RedirectToAction(nameof(Index));
        }
        return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
        if ( id == null )
        {
        return NotFound();
        }

        var post = await _context.Post
                .SingleOrDefaultAsync(m => m.PostId == id);
        if ( post == null )
        {
        return NotFound();
        }

        return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
        var post = await _context.Post.SingleOrDefaultAsync(m => m.PostId == id);
        _context.Post.Remove(post);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
        return _context.Post.Any(e => e.PostId == id);
        }
    }
}
