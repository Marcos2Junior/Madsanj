using Data.ModelDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Madsanj.Models.FormViewModel
{
    public class FinanceiroCreate
    {
        public Financeiro Financeiro { get; set; }

        [Display(Name = "Existem Parcelas?")]
        public bool Existe { get; set; }

        [Range(1, 1000, ErrorMessage = " {0} deve ser entre {1} a {2}")]
        [Display(Name = "Quantidade de parcelas")]
        public int QuantidadeParcela { get; set; }

        [Range(0.1, 50000.0, ErrorMessage = " {0} deve ser entre {1} a {2}")]
        [Display(Name = "Valor da parcela")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal ValorParcela { get; set; }

        [Display(Name = "Data de vencimento")]
        [DataType(DataType.Date)]
        public DateTime DataVencimento { get; set; }
    }
}
