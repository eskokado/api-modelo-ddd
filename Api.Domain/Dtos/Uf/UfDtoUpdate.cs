using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Uf
{
    public class UfDtoUpdate
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Initials é campo obrigatório")]
        [StringLength(2, ErrorMessage = "Initial deve ter no máximo {1} caracteres")]
        public string Initials { get; set; }
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(150, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }
    }
}