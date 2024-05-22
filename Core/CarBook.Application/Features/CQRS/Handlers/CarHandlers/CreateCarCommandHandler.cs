﻿using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
                BrandID = command.BrandID,
                Name = command.Name,
                BigImageUrl = command.BigImageUrl,
                Luggage = command.Luggage,
                Km = command.Km,
                Fuel = command.Fuel,
                CoverImageUrl = command.CoverImageUrl,
                Seat = command.Seat,
                Model = command.Model,
                Transmission = command.Transmission,
                
            });
        }
    }
}
