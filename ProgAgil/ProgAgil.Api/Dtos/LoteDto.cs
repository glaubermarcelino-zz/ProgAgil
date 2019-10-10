using System.ComponentModel.DataAnnotations;

namespace ProgAgil.Api.Dtos
{
    public class LoteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage="O campo '{0}' é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage="O campo '{0}' é obrigatório!")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage="O campo '{0}' é obrigatório!")]
        public string DataInicio { get; set; }

        [Required(ErrorMessage="O campo '{0}' é obrigatório!")]
        public string DataFim { get; set; }
        
        [Required(ErrorMessage="O campo '{0}' é obrigatório!")]
        [Range(2, 120000, ErrorMessage = "A quantidade deve estar entre 2 e 120000!")]
        public int Quantidade { get; set; }
    }
}