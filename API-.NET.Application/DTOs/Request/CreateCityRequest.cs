using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Application.DTOs.Request
{
    public class CreateCityRequest
    {
        public string Name { get; set; }
        public int StateId { get; set; }
    }
}
