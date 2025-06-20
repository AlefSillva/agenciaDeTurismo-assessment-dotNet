using System;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A data da reserva é obrigatória")]
        public DateTime DataReserva { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public Cliente Cliente { get; set; } = null!;

        [Required]
        public int PacoteTuristicoId { get; set; }

        [Required]
        public PacoteTuristico PacoteTuristico { get; set; } = null!;

        [Required]
        public int QuantidadeDiarias { get; set; }
    }

}
