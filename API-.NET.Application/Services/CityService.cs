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
    public class CityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<string> Create(CreateCityRequest request)
        {
            var city = new City
            {
                Name = request.Name,
                StateId = request.StateId
            };
            await _cityRepository.Create(city);
            return "Cidade criada com sucesso";
        }
    }
}
