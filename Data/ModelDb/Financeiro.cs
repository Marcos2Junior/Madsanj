using Data.Classes.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.ModelDb
{
    public class Financeiro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "{0} tamanho deve ser entre {2} e {1}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "{0} tamanho deve ser entre {2} e {1}")]
        public string Descricao { get; set; }

        [Display(Name = "Entrada?")]
        public bool Entrada { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [Range(0.1, 50000.0, ErrorMessage = " {0} deve ser entre {1} a {2}")]
        [Display(Name = "Valor total")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal ValorTotal { get; set; }
        [Display(Name = "Tempo indeterminado?")]
        public bool TempoIndeterminado { get; set; }
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
