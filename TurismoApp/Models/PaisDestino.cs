using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Models
{
    public class PaisDestino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do país é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome do país deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; } = string.Empty;

        public List<CidadeDestino> CidadesDestino { get; set; } = new List<CidadeDestino>();
    }
}