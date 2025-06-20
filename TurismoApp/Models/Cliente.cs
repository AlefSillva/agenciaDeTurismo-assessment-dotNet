using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TurismoApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "Nome deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public bool IsDeleted { get; set; } = false;
    }
}
