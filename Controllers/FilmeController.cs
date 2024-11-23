using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Controllers
{
    public class FilmeController : Controller
    {
        private readonly LocadoraContext _context;

        public FilmeController(LocadoraContext context)
        {
            _context = context;
        }

        // GET: Filmes
        public async Task<IActionResult> Index()
        {
            var filmes = await _context.Filmes
                .Include(f => f.Produtora)  // Incluir a Produtora do Filme
                .Include(f => f.Generos)    // Incluir os Gêneros do Filme
                .ToListAsync();

            return View(filmes);
        }

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes
                .Include(f => f.Produtora)  // Incluir a Produtora do Filme
                .Include(f => f.Generos)    // Incluir os Gêneros do Filme
                .FirstOrDefaultAsync(m => m.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            ViewBag.Produtoras = new SelectList(_context.Produtoras, "ProdId", "ProdNome");
            ViewBag.Generos = _context.Generos.Select(g => new SelectListItem
            {
                Value = g.GenId.ToString(),
                Text = g.Nome
            }).ToList();

            return View();
        }

        // POST: Filmes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Filme filme, int[] selectedGeneros)
        {
            if (ModelState.IsValid)
            {
                // Associar os gêneros ao filme
                if (selectedGeneros != null && selectedGeneros.Length > 0)
                {
                    var generos = await _context.Generos
                        .Where(g => selectedGeneros.Contains(g.GenId))
                        .ToListAsync();

                    foreach (var genero in generos)
                    {
                        filme.Generos.Add(genero);
                    }
                }

                // Associar a produtora ao filme
                filme.Produtora = await _context.Produtoras.FindAsync(filme.ProdId);

                // Adicionar o filme ao contexto e salvar
                _context.Filmes.Add(filme);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Repassar listas para a view em caso de erro
            ViewBag.Produtoras = new SelectList(_context.Produtoras, "ProdId", "ProdNome", filme.ProdId);
            ViewBag.Generos = _context.Generos.Select(g => new SelectListItem
            {
                Value = g.GenId.ToString(),
                Text = g.Nome
            }).ToList();

            return View(filme);
        }



        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes
                .Include(f => f.Produtora)  // Incluir a Produtora
                .Include(f => f.Generos)    // Incluir os Gêneros
                .FirstOrDefaultAsync(m => m.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            // Passando as produtoras e gêneros para a view
            ViewBag.Produtoras = new SelectList(_context.Produtoras, "ProdId", "ProdNome", filme.ProdId);
            ViewBag.Generos = new MultiSelectList(_context.Generos, "GenId", "Nome", filme.Generos.Select(g => g.GenId).ToArray());

            return View(filme);
        }

        // POST: Filmes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Filme filme, int[] selectedGeneros)
        {
            if (id != filme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Atualizando os Gêneros do Filme
                    if (selectedGeneros != null && selectedGeneros.Length > 0)
                    {
                        filme.Generos = _context.Generos.Where(g => selectedGeneros.Contains(g.GenId)).ToList();
                    }

                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.Id))
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

            // Repassando as produtoras e gêneros para a view caso haja erro de validação
            ViewBag.Produtoras = new SelectList(_context.Produtoras, "ProdId", "ProdNome", filme.ProdId);
            ViewBag.Generos = new MultiSelectList(_context.Generos, "GenId", "Nome", selectedGeneros);
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes
                .Include(f => f.Produtora)
                .Include(f => f.Generos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }
    }
}
