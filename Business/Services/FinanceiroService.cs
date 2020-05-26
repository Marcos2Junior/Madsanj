using Business.Services.ImplementInterface;
using Data;
using Data.ModelDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class FinanceiroService : CRUD
    {
        private ExceptionFull _exception = new ExceptionFull();

        public FinanceiroService(MadsanjContext context) : base(context) { }

        public async Task<bool> CrudAsync(Financeiro financeiro, int opcaoCrud)
        {
            if (financeiro == null)
                return false;

            if (opcaoCrud != 0)
            {
                if (await GetFinanceiroAsync(financeiro.Id) == null)
                    return false;
            }

            switch (opcaoCrud)
            {
                case 0:
                    financeiro.DataRegistro = DateTime.Now;
                    _exception = Add(financeiro);
                    break;
                case 1:
                    _exception = Update(financeiro);
                    break;
                case 2:
                    _exception = Delete(financeiro);
                    break;
                default:
                    return false;
            }

            if (_exception.Status)
                _exception = await SaveChangesAsync();

            if (!_exception.Status)
            {
                Erro(new ExceptionFull(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,
                    GetType().Name,
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    _exception.Mensagem, _exception.Status, DateTime.Now, null
                    ));

                return false;
            }

            return true;
        }

        public async Task<Financeiro> GetFinanceiroAsync(int id)
        {
            var _financeiro = await SearchId<Financeiro>(x => x.Id == id);

            if (_financeiro != null)
                _financeiro.FinanceiroParcelas = await GetFinanceiroParcelas(_financeiro.Id);

            return _financeiro;
        }

        public async Task<List<Financeiro>> GetAllFinanceirosAsync()
        {
            var _financeiro = await GetAllAsync<Financeiro>();

            foreach (var item in _financeiro)
            {
                item.FinanceiroParcelas = await GetFinanceiroParcelas(item.Id);
            }

            return _financeiro;
        }

        public async Task<Financeiro> SearchFinanceiro(string nome)
        {
            var _financeiro = await SearchAsync<Financeiro>(x => x.Nome.ToUpper() == nome.ToUpper());

            _financeiro.ForEach(async x => x.FinanceiroParcelas = await GetFinanceiroParcelas(x.Id));

            return _financeiro.FirstOrDefault();
        }

        public async Task<List<FinanceiroParcela>> GetFinanceiroParcelas(int IdFinanceiro) =>
            await SearchAsync<FinanceiroParcela>(x => x.FinanceiroId == IdFinanceiro);
    }
}
