using API_.NET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task Create(Customer customer);
    }
}
