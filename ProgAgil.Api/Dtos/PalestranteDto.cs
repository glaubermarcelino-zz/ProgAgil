using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProgAgil.Api.Dtos
{
    public class PalestranteDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage="O campo '{0}' é obrigatório!")]
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }
        [Required]
        [Phone()]
        public string Telefone { get; set; }

        [Required(ErrorMessage="O campo '{0}' é obrigatório!")]
        [EmailAddress(ErrorMessage="Informe um e-mail válido!")]
        public string Email { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Eventos { get; set; }
    }
}