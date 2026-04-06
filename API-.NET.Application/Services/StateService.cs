using API_.NET.Application.DTOs.Request;
using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Application.Services
{
    public class StateService
    {
        private readonly IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<string> Create(CreateStateRequest request)
        {
            var state = new State
            {
                Name = request.Name,
                Uf = request.Uf,
            };
            await _stateRepository.Create(state);
            return "Estado criado com sucesso";
        }
    }
}
