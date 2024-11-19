using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Controllers
{
    public class FilmeController : Controller
    {
        private readonly Contexto _context;

        public Filme Filmes { get; private set; }

        public FilmeController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Filmes.ToListAsync());
        }

        // GET: EmprestimoController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Filmes = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Filmes == null)
            {
                return NotFound();
            }

            return View(Filmes);
        }

        // GET: EmprestimoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmprestimoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Genero,Preco, Emprestimo")] Filme Filmes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Filmes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Filmes);
        }

        // GET: EmprestimoController/Edit/5
        public async Task<ActionResult> Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Filmes = await _context.Filmes.SingleOrDefaultAsync(i => i.Id == id);
            if (Filmes == null)
            {
                return NotFound();
            }
            return View(Filmes);
        }

        // POST: EmprestimoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Genero,Preco, Emprestimo")] Filme Filmes)
        {
            if (id != Filmes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Filmes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmesExists(Filmes.Id))
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
            return View(Filmes);
        }

        private bool FilmesExists(int id)
        {
            throw new NotImplementedException();
        }

        // GET: EmprestimoController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Filmes = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Filmes == null)
            {
                return NotFound();
            }

            return View(Filmes);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Filmes = await _context.Filmes.FindAsync(id);
            if (Filmes != null)
            {
                _context.Filmes.Remove(Filmes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
