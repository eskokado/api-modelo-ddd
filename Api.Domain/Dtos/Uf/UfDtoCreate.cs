using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Uf
{
    public class UfDtoCreate
    {
        [Required(ErrorMessage = "Sigla é campo obrigatório")]
        [StringLength(2, ErrorMessage = "Sigla deve ter no máximo {1} caracteres")]
        public string Initials { get; set; }
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(150, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }
    }
}