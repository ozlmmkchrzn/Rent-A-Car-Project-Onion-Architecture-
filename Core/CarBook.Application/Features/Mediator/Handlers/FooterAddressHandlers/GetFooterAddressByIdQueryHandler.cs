using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAdressByIdQueryResult>
    { 
        private readonly IRepository<FooterAddess> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddess> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAdressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var values =  await _repository.GetByIdAsync(request.Id);
            return new GetFooterAdressByIdQueryResult
            {
                FooterAddressID = values.FooterAddressID,
                Address = values.Address,
                Description = values.Description,
                Email = values.Email,
                Phone = values.Phone
            };
        }
    }
}
