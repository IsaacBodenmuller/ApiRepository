using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Application.DTOs.Request
{
    public class RefreshRequest
    {
        public string RefreshToken { get; set; }
        public bool Remember {  get; set; }
    }
}
