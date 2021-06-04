using System;

namespace Api.Domain.Entities
{
    public class CepEntity : BaseEntity
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public Guid CountyId { get; set; }

        public CountyEntity County { get; set; }
    }
}