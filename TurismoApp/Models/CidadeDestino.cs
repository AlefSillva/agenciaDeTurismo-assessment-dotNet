using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Models
{
    public class CidadeDestino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da cidade é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome da cidade deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O país da cidade é obrigatório")]
        public int PaisDestinoId { get; set; }

        public PaisDestino? PaisDestino { get; set; }

        public List<PacoteTuristico> PacotesTuristicos { get; set; } = new List<PacoteTuristico>();
    }
}
