using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título do pacote é obrigatório")]
        [MinLength(3, ErrorMessage = "O título do pacote deve ter no mínimo 3 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A data de início é obrigatória")]
        public DateTime DataInicio { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A capacidade deve ser maior que zero")]
        public int CapacidadeMaxima { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }

        // Relacionamento N:N com CidadeDestino
        public List<CidadeDestino> CidadesDestino { get; set; } = new List<CidadeDestino>();

        // Relacionamento 1:N com Reserva
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        // Evento - capacidade máxima é atingida
        public event EventHandler? CapacityReached;

        public void VerificarCapacidade(int reservasAtuais)
        {
            if (reservasAtuais >= CapacidadeMaxima)
            {
                CapacityReached?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool IsDeleted { get; set; } = false;
    }
}
