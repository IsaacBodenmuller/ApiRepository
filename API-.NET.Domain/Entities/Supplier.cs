using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Domain.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj {  get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Cep { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
