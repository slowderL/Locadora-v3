using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Controllers
{
    public class ProdutoraController : Controller
    {
        private readonly Contexto _context;
        public ProdutoraController(Contexto context)
        {
            _context = context;
        }
        // GET: ProdutoraController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtoras.ToListAsync());
        }

        // GET: Apostadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtora = await _context.Produtoras
                .FirstOrDefaultAsync(m => m.ProdId == id);
            if (produtora == null)
            {
                return NotFound();
            }

            return View(produtora);
        }

        // GET: ProdutoraController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdId,ProdNome,ProdCnpj,ProdEnd")] Produtora produtora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtora);
        }

      // POST: ProdutoraController/Edit/5
        // GET: Apostadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtora = await _context.Produtoras.FindAsync(id);
            if (produtora == null)
            {
                return NotFound();
            }
            return View(produtora);
        }

        // POST: Produtoras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdId,ProdNome,ProdCnpj,ProdEnd")] Produtora produtora)
        {
            if (id != produtora.ProdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoraExists(produtora.ProdId))
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
            return View(produtora);
        }

        private bool ProdutoraExists(int prodId)
        {
            throw new NotImplementedException();
        }

        // GET: ProdutoraController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apostador = await _context.Produtoras
                .FirstOrDefaultAsync(m => m.ProdId == id);
            if (apostador == null)
            {
                return NotFound();
            }

            return View(apostador);
        }

        // POST: Produtoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtora = await _context.Produtoras.FindAsync(id);
            if (produtora != null)
            {
                _context.Produtoras.Remove(produtora);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApostadorExists(int id)
        {
            return _context.Produtoras.Any(e => e.ProdId == id);
        }
    }
}
