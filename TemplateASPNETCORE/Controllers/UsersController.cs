using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TemplateASPNETCORE.Data;
using TemplateASPNETCORE.Models;
using TemplateASPNETCORE.Services;

namespace TemplateASPNETCORE.Controllers
{
  public class UsersController : Controller
  {
    private readonly IService _service;

    public readonly IUserService _userService;

    //D.I - Dependecy Injection
    public UsersController(IService service, IUserService userService)
    {
      _service = service;
      _userService = userService;
    }

    // GET: Users
    public async Task<IActionResult> Index()
    {
      return View(await _userService.GetUsers());
    }

    // GET: Users/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var user = _userService.GetUserById(id.Value);

      if (user == null)
      {
        return NotFound();
      }

      return View(user);
    }

    // GET: Users/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Users/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,name,email,password")] User user)
    {
      if (ModelState.IsValid)
      {
        _service.Add(user);
        if (await _service.SaveChangeAsync())
          return RedirectToAction(nameof(Index));
      }
      return View(user);
    }

    // GET: Users/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var user = _userService.GetUserById(id.Value);

      if (user == null)
      {
        return NotFound();
      }
      return View(user);
    }

    // POST: Users/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("id,name,email,password")] User user)
    {
      if (id != user.id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _service.Update(user);
          await _service.SaveChangeAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!await _userService.UserExists(user.id))
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
      return View(user);
    }

    // GET: Users/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var user = _userService.GetUserById(id.Value);

      if (user == null)
      {
        return NotFound();
      }

      return View(user);
    }

    // POST: Users/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var user = _userService.GetUserById(id);
      _service.Delete(user);
      await _service.SaveChangeAsync();
      return RedirectToAction(nameof(Index));
    }
    
  }
}
