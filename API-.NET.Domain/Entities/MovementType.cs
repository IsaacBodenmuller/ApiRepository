using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Domain.Entities
{
    public class MovementType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<InventoryMovement> Movements { get; set; }
    }
}
