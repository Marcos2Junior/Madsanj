using System;

namespace Data.ModelDb
{
    public class FinanceiroParcela
    {
        public int Id { get; set; }
        public int FinanceiroId { get; set; }
        public Financeiro Financeiro { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal? MultaAtraso { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }

        public FinanceiroParcela()
        {
        }

        public FinanceiroParcela(int id, Financeiro financeiro, decimal valorParcela, decimal multaAtraso, DateTime dataVencimento, DateTime? dataPagamento)
        {
            Id = id;
            Financeiro = financeiro;
            ValorParcela = valorParcela;
            MultaAtraso = multaAtraso;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
        }
    }
}
