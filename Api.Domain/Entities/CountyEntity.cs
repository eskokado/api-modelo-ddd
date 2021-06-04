using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class CountyEntity : BaseEntity
    {

        public string Name { get; set; }

        public int CodeIBGE { get; set; }

        public Guid UfId { get; set; }

        public UfEntity Uf { get; set; }

        public IEnumerable<CepEntity> Ceps { get; set; }
    }
}