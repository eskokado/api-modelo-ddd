using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.County
{
    public class CountyDtoUpdate
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(150, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Codigo IBGE é campo obrigatório")]
        public int CodeIBGE { get; set; }
        [Required(ErrorMessage = "UfId é campo obrigatório")]
        public Guid UfId { get; set; }

    }
}