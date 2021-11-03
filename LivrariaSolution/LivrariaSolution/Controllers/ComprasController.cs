using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LivrariaSolution.Data;
using LivrariaSolution.Models;
using Microsoft.AspNetCore.Authorization;

namespace LivrariaSolution.Controllers
{
    [Authorize]
    public class ComprasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var c = await _context.Compra.Include(c => c.Cliente).Include(f => f.Funcionario).Include(l => l.Livro).ToListAsync();
            return View(c);
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            var c = new Compra();
            var clientes = _context.Cliente.ToList();
            var funcionarios = _context.Funcionario.ToList();
            var livros = _context.Livro.ToList();

            c.Clientes = new List<SelectListItem>();
            c.Funcionarios = new List<SelectListItem>();
            c.Livros = new List<SelectListItem>();

            foreach (var cli in clientes)
            {
                c.Clientes.Add(new SelectListItem { Text = cli.Nome, Value = cli.Id.ToString() });
            }

            foreach (var fun in funcionarios)
            {
                c.Funcionarios.Add(new SelectListItem { Text = fun.Nome, Value = fun.Id.ToString() });
            }

            foreach (var li in livros)
            {
                c.Livros.Add(new SelectListItem { Text = li.Titulo, Value = li.Id.ToString() });
            }

            return View(c);

        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Compra compra)
        {
            int _clienteId = int.Parse(Request.Form["Cliente"].ToString());
            var cliente = _context.Cliente.FirstOrDefault(c => c.Id == _clienteId);
            compra.Cliente = cliente;

            int _funcionarioId = int.Parse(Request.Form["Funcionario"].ToString());
            var funcionario = _context.Funcionario.FirstOrDefault(f => f.Id == _funcionarioId);
            compra.Funcionario = funcionario;

            int _livroId = int.Parse(Request.Form["Livro"].ToString());
            var livro = _context.Livro.FirstOrDefault(l => l.Id == _livroId);
            compra.Livro = livro;

            if (ModelState.IsValid)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = _context.Compra.Include(c => c.Cliente).First(e => e.Id == id);
            var clientes = _context.Cliente.ToList();
            compra.Clientes = new List<SelectListItem>();

            foreach (var cli in clientes)
            {
                compra.Clientes.Add(new SelectListItem { Text = cli.Nome, Value = cli.Id.ToString() });
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////

            compra = _context.Compra.Include(f => f.Funcionario).First(e => e.Id == id);
            var funcionarios = _context.Funcionario.ToList();
            compra.Funcionarios = new List<SelectListItem>();

            foreach (var fun in funcionarios)
            {
                compra.Funcionarios.Add(new SelectListItem { Text = fun.Nome, Value = fun.Id.ToString() });
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////

            compra = _context.Compra.Include(l => l.Livro).First(e => e.Id == id);
            var livros = _context.Livro.ToList();
            compra.Livros = new List<SelectListItem>();

            foreach (var li in livros)
            {
                compra.Livros.Add(new SelectListItem { Text = li.Titulo, Value = li.Id.ToString() });
            }

            //var compra = await _context.Compra.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Compra compra)
        {
            if (id != compra.Id)
            {
                return NotFound();
            }

            int _clienteId = int.Parse(Request.Form["Cliente"].ToString());
            var cliente = _context.Cliente.FirstOrDefault(c => c.Id == _clienteId);
            compra.Cliente = cliente;

            int _funcionarioId = int.Parse(Request.Form["Funcionario"].ToString());
            var funcionario = _context.Funcionario.FirstOrDefault(f => f.Id == _funcionarioId);
            compra.Funcionario = funcionario;

            int _livroId = int.Parse(Request.Form["Livro"].ToString());
            var livro = _context.Livro.FirstOrDefault(l => l.Id == _livroId);
            compra.Livro = livro;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.Id))
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
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compra = await _context.Compra.FindAsync(id);
            _context.Compra.Remove(compra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
            return _context.Compra.Any(e => e.Id == id);
        }
    }
}
