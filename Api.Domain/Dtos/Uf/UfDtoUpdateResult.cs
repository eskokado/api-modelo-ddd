using System;

namespace Api.Domain.Dtos.Uf
{
    public class UfDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}