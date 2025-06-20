using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Pages.Descontos
{
    public class DescontoModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "O preço da diária é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal PrecoDiaria { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "O número de diárias é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O número de diárias deve ser maior que zero.")]
        public int NumeroDiarias { get; set; }

        public decimal? PrecoTotalCalculado { get; set; }
        public bool AplicouDesconto { get; set; } = false;

        public void OnGet()
        {
            PrecoTotalCalculado = null;
            AplicouDesconto = false;
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                PrecoTotalCalculado = null;
                AplicouDesconto = false;
                return;
            }

            // Cálculo do preço da diária já com desconto para mais de 3 diárias
            Func<int, decimal, decimal> calcularPrecoComDesconto = (numDiarias, precoDiaria) =>
            {
                if (numDiarias > 3)
                {
                    return precoDiaria * 0.9m; 
                }
                return precoDiaria;
            };

            var precoUnitarioComDesconto = calcularPrecoComDesconto(NumeroDiarias, PrecoDiaria);
            PrecoTotalCalculado = precoUnitarioComDesconto * NumeroDiarias;

            AplicouDesconto = precoUnitarioComDesconto < PrecoDiaria;
        }
    }
}
