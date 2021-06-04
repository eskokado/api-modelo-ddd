using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoCreate
    {
        [Required(ErrorMessage = "Cep é campo obrigatório")]
        [StringLength(10, ErrorMessage = "Cep deve ter no máximo {1} caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Logradouro é campo obrigatório")]
        [StringLength(150, ErrorMessage = "Logradouro deve ter no máximo {1} caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Numero é campo obrigatório")]
        [StringLength(15, ErrorMessage = "Numero deve ter no máximo {1} caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "CountyId é campo obrigatório")]
        public Guid CountyId { get; set; }
    }
}