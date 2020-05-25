using System;
using System.Collections.Generic;

namespace Data.ModelDb
{
    public class Financeiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Entrada { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataRegistro { get; set; }
        public List<FinanceiroParcela> FinanceiroParcelas { get; set; }

        public Financeiro()
        {
        }

        public Financeiro(int id, string nome, string descricao, bool entrada, decimal valorTotal, DateTime dataRegistro, List<FinanceiroParcela> financeiroParcelas)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Entrada = entrada;
            ValorTotal = valorTotal;
            DataRegistro = dataRegistro;
            FinanceiroParcelas = financeiroParcelas;
        }
    } 
}
