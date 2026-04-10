using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Application.DTOs.Response
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public DateTime AccessExpiresIn { get; set; }
    }
}
