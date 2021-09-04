using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GelaBahia.Data;
using GelaBahia.Models;

namespace GelaBahia.Controllers
{
    public class ServicoesController : Controller
    {
        private readonly GelaBahiaContext _context;

        public ServicoesController(GelaBahiaContext context)
        {
            _context = context;
        }

        // GET: Servicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servico.Where(x => x.FuncionarioID == 0).ToListAsync());
        }

        // GET: Servicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico
                .FirstOrDefaultAsync(m => m.ID == id);
            if (servico == null)
            {
                return NotFound();
            }

            servico.Cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ID == servico.ClienteID);

            return View(servico);
        }

        public async Task<IActionResult> AddEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }
            PopulateFuncionariosDropDownList(servico);
            return View(servico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(int id, [Bind("ID,Nome,DiaHora,Valor,Tipo,TipoManutencao,ClienteID,FuncionarioID")] Servico servico)
        {
            var funcionario = await _context.Funcionario.FindAsync(servico.FuncionarioID);
            if (funcionario == null || !funcionario.Disponivel)
            {
                // return View("Views/Servicoes/FuncionarioErrors.cshtml");
            }

            if (id != servico.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servico);
                    funcionario.Disponivel = false;
                    funcionario.Comissao += servico.Valor * 0.4f;
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.ID))
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
            return View(servico);
        }

        private void PopulateFuncionariosDropDownList(object selectedFuncionario = null)
        {
            var funcionariosQuery = from c in _context.Funcionario.Where(x => x.Disponivel)
                                    orderby c.Nome
                                    select c;
            ViewBag.FuncionarioID = new SelectList(funcionariosQuery.AsNoTracking(), "ID", "Nome", selectedFuncionario);
        }

        private void PopulateClientesDropDownList(object selectedCliente = null)
        {
            var clientesQuery = from c in _context.Cliente
                                orderby c.Nome
                                select c;
            ViewBag.ClienteID = new SelectList(clientesQuery.AsNoTracking(), "ID", "Nome", selectedCliente);
        }

        // GET: Servicoes/Create
        public IActionResult Create()
        {
            PopulateClientesDropDownList();
            return View();
        }

        // POST: Servicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,DiaHora,Valor,Tipo,TipoManutencao,ClienteID")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servico);
        }

        // GET: Servicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }
            PopulateClientesDropDownList(servico);
            return View(servico);
        }

        // POST: Servicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,DiaHora,Valor,Tipo,TipoManutencao,ClienteID")] Servico servico)
        {
            if (id != servico.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.ID))
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
            return View(servico);
        }

        // GET: Servicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico
                .FirstOrDefaultAsync(m => m.ID == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // POST: Servicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servico = await _context.Servico.FindAsync(id);
            var funcionario = await _context.Funcionario.FindAsync(servico.FuncionarioID);
            _context.Servico.Remove(servico);
            funcionario.Disponivel = true;
            _context.Update(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicoExists(int id)
        {
            return _context.Servico.Any(e => e.ID == id);
        }
    }
}
