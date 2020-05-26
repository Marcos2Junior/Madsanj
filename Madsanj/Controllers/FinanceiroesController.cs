using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data.ModelDb;
using Business.Services;
using Madsanj.Models.FormViewModel;
using System.Collections.Generic;

namespace Madsanj.Controllers
{
    public class FinanceiroesController : Controller
    {
        private readonly FinanceiroService _financeiro;

        public FinanceiroesController(FinanceiroService context)
        {
            _financeiro = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _financeiro.GetAllFinanceirosAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _financeiro.GetFinanceiroAsync((int)id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FinanceiroCreate financeiroCreate)
        {
            if (financeiroCreate.Existe && !financeiroCreate.Financeiro.TempoIndeterminado)
            {
                financeiroCreate.Financeiro.FinanceiroParcelas = new List<FinanceiroParcela>();
                for (int i = 0; i < financeiroCreate.QuantidadeParcela; i++)
                {
                    financeiroCreate.Financeiro.FinanceiroParcelas.Add(new FinanceiroParcela()
                    {
                        DataVencimento = financeiroCreate.DataVencimento.AddMonths(i),
                        ValorParcela = financeiroCreate.ValorParcela
                    });
                }
            }

            await _financeiro.CrudAsync(financeiroCreate.Financeiro, 0);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _financeiro.GetFinanceiroAsync((int)id);
            if (financeiro == null)
            {
                return NotFound();
            }
            return View(financeiro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Entrada,ValorTotal,DataRegistro")] Financeiro financeiro)
        {
            if (id != financeiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _financeiro.CrudAsync(financeiro, 1))
                    return RedirectToAction(nameof(Index));

                if (await _financeiro.GetFinanceiroAsync(financeiro.Id) == null)
                    return NotFound();

                return BadRequest();
            }

            return View(financeiro);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _financeiro.GetFinanceiroAsync((int)id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var financeiro = await _financeiro.GetFinanceiroAsync(id);

            if (await _financeiro.CrudAsync(financeiro, 2))
                return RedirectToAction(nameof(Index));

            return BadRequest();
        }
    }
}