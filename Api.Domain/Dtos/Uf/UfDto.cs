using System;

namespace Api.Domain.Dtos.Uf
{
    public class UfDto
    {
        public Guid Id { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime Update { get; set; }
    }
}