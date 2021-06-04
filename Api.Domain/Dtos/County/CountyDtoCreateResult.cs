using System;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Dtos.County
{
    public class CountyDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CodeIBGE { get; set; }
        public Guid UfId { get; set; }
        public UfDto Uf { get; set; }
        public DateTime CreateAt { get; set; }
    }
}