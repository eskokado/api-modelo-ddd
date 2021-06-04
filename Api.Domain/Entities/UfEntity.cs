using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class UfEntity : BaseEntity
    {
        public string Initials { get; set; }
        public string Name { get; set; }
        public IEnumerable<CountyEntity> Counties { get; set; }
    }
}