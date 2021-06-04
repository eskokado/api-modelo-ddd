using System;
using Api.Domain.Dtos.County;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public Guid CountyId { get; set; }

        public CountyDto County { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}