using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogsByAuthorIdQueryHandler : IRequestHandler<GetBlogsByAuthorIdQuery, List<GetBlogsByAuthorIdQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogsByAuthorIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogsByAuthorIdQueryResult>> Handle(GetBlogsByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetBlogByAuthorId(request.Id);
            return values.Select(x => new GetBlogsByAuthorIdQueryResult
            {
                AuthorID = x.AuthorID,
                BlogID = x.BlogID,
                AuthorDescription = x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl,
                AuthorName = x.Author.Name
            }).ToList();
        }
    }
}
