using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIDQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIDQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIDQueryResult> Handle(GetCategoryByIDQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCategoryByIDQueryResult
            {
                CategoryID = values.CategoryID,
                Name = values.Name
            };
        }
    }
}
