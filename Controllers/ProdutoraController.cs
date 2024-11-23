using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Controllers
{
    public class ProdutoraController : Controller
    {
        private readonly LocadoraContext _context;
        public ProdutoraController(LocadoraContext context)
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
        public async Task<IActionResult> Create([Bind("ProdId,ProdNome,ProdCnpj,ProdEnd,DtCriacao")] Produtora produtora)
        {
            // Verifica se a data de criação é válida (não posterior à data do sistema)
            if (produtora.DtCriacao > DateTime.Now)
            {
                ModelState.AddModelError("DtCriacao", "A data de criação não pode ser posterior à data atual.");
            }

            // Se o modelo for válido
            if (ModelState.IsValid)
            {
                // Adiciona a produtora ao contexto
                _context.Add(produtora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redireciona para a lista de produtoras
            }

            // Se houver erros, retorna a view com a produtora
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

            // Busca a produtora no banco de dados
            var produtora = await _context.Produtoras.FindAsync(id);
            if (produtora == null)
            {
                return NotFound();
            }

            // Validação adicional: verificar se a data de criação não é posterior à data atual
            if (produtora.DtCriacao > DateTime.Now)
            {
                ModelState.AddModelError("DtCriacao", "A data de criação não pode ser posterior à data atual.");
                // Retorna a view com os dados da produtora para correção
                return View(produtora);
            }

            // Retorna a view com os dados da produtora para edição
            return View(produtora);
        }


        // POST: Produtoras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdId,ProdNome,ProdCnpj,ProdEnd,DtCriacao")] Produtora produtora)
        {
            // Verifica se o ID fornecido na URL corresponde ao ID da produtora
            if (id != produtora.ProdId)
            {
                return NotFound();
            }

            // Validação adicional: verificar se a data de criação não é posterior à data atual
            if (produtora.DtCriacao > DateTime.Now)
            {
                ModelState.AddModelError("DtCriacao", "A data de criação não pode ser posterior à data atual.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Atualiza a produtora no banco de dados
                    _context.Update(produtora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Se a produtora não existir mais, retorna NotFound
                    if (!ProdutoraExists(produtora.ProdId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        // Lança a exceção para ser tratada no nível superior
                        throw;
                    }
                }

                // Redireciona para a lista de produtoras
                return RedirectToAction(nameof(Index));
            }

            // Retorna a view em caso de erro de validação
            return View(produtora);
        }

        private bool ProdutoraExists(int prodId)
        {
            // Verifica se existe uma produtora com o ID fornecido no banco de dados
            return _context.Produtoras.Any(e => e.ProdId == prodId);
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
