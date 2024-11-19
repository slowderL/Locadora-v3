using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Controllers
{
    public class GeneroController : Controller
    {
        private readonly Contexto _context;

        public Genero Generos { get; private set; }

        public GeneroController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Generos.ToListAsync());
        }

        // GET: GeneroController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Generos
                .FirstOrDefaultAsync(m => m.GenId == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // GET: GeneroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneroController/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenId,Nome,desc,DtCriacao")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genero);
        }

        // GET: Apostadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Generos.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }

        // POST: GeneroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenId,Nome,desc,DtCriacao")] Genero genero)
        {
            if (id != genero.GenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneroExists(genero.GenId))
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
            return View(genero);
        }
        private bool GeneroExists(int genId)
        {
            throw new NotImplementedException();
        }

        // GET: GeneroController/Delete/5
        // GET: Generos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Generos
                .FirstOrDefaultAsync(m => m.GenId == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // POST: Generos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero != null)
            {
                _context.Generos.Remove(genero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenerosExists(int id)
        {
            return _context.Generos.Any(e => e.GenId == id);
        }
    }
}
