using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjMVCLocadoraCarro.Data;
using ProjMVCLocadoraCarro.Models;

namespace ProjMVCLocadoraCarro.Controllers
{
    public class LocacaosController : Controller
    {
        private readonly ProjMVCLocadoraCarroContext _context;

        public LocacaosController(ProjMVCLocadoraCarroContext context)
        {
            _context = context;
        }

        // GET: Locacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locacao.Include(c => c.Carro).ToListAsync());
        }

        // GET: Locacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacao.FirstOrDefaultAsync(m => m.Id == id);

            if (locacao == null)
            {
                return NotFound();
            }

            return View(locacao);
        }

        // GET: Locacaos/Create
        public IActionResult Create()
        {
            var l = new Locacao();
            var carros = _context.Carro.ToList();

            l.Carros = new List<SelectListItem>();

            foreach (var car in carros)
            {
                l.Carros.Add(new SelectListItem { Text = car.Nome, Value = car.Id.ToString() }) ;
            }

            return View(l);
        }

        // POST: Locacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Locacao locacao)
        {
            int _carroId = int.Parse(Request.Form["Carro"].ToString());
            var carro = _context.Carro.FirstOrDefault(m => m.Id == _carroId);
            locacao.Carro = carro;

            if (ModelState.IsValid)
            {
                _context.Add(locacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locacao);
        }

        // GET: Locacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = _context.Locacao.Include(c => c.Carro).First(v => v.Id == id);

            var carros = _context.Carro.ToList();

            locacao.Carros = new List<SelectListItem>();

            foreach (var car in carros)
            {
                locacao.Carros.Add(new SelectListItem { Text = car.Nome, Value = car.Id.ToString() });
            }

            if (locacao == null)
            {
                return NotFound();
            }
            return View(locacao);
        }

        // POST: Locacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Locacao locacao)
        {
            if (id != locacao.Id)
            {
                return NotFound();
            }

            int _carroId = int.Parse(Request.Form["Carro"].ToString());
            var carro = _context.Carro.FirstOrDefault(m => m.Id == _carroId);
            locacao.Carro = carro;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocacaoExists(locacao.Id))
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
            return View(locacao);
        }

        // GET: Locacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locacao == null)
            {
                return NotFound();
            }

            return View(locacao);
        }

        // POST: Locacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locacao = await _context.Locacao.FindAsync(id);
            _context.Locacao.Remove(locacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocacaoExists(int id)
        {
            return _context.Locacao.Any(e => e.Id == id);
        }
    }
}
