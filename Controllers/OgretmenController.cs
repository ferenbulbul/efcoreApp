using System.Reflection.Metadata.Ecma335;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class OgretmenController : Controller
    {
        private readonly DataContext _context;
        public OgretmenController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Ogretmenler.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen model)
        {
            _context.Ogretmenler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ortmn=await _context.Ogretmenler.FindAsync(id);
            if(ortmn==null)
            {
                return NotFound();
            }
            return View(ortmn);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id,Ogretmen model)
        {
            if(id==null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Ogretmenler.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                    if(! _context.Ogretmenler.Any(o=>o.OgretmenId==model.OgretmenId))
                    {
                            return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
   
        public async Task<IActionResult>Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var ogrt=await _context.Ogretmenler.FindAsync(id);
            if(ogrt==null)
            {
                return NotFound();
            }
            return View(ogrt);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Ogretmen model)
        {
            var ogretmn= await _context.Ogretmenler.FindAsync(model.OgretmenId);
            
            if(ogretmn==null)
            {
                return NotFound();
            }
            _context.Ogretmenler.Remove(ogretmn);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public class IActionResults (){

        }
   }
}