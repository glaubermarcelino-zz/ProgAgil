using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProgAgil.Api.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O número de caracteres deve estar entre 5 e 100!")]
        [Required(ErrorMessage = "O campo local deve ser informado!")]
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [Required(ErrorMessage = "O tema deve ser ser informado!")]
        public string Tema { get; set; }
        [Range(2, 120000, ErrorMessage = "O número de pessoas deve estar entre 2 e 120000")]
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }
        [Phone(ErrorMessage = "Informe um número de telefone válido!")]
        public string Telefone { get; set; }
        [EmailAddress(ErrorMessage = "Informe um E-mail válido")]
        public string Email { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get; set; }
    }
}