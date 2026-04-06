using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string? Cpf { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }

        public string? Cep { get; set; }
        public string? Address { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
