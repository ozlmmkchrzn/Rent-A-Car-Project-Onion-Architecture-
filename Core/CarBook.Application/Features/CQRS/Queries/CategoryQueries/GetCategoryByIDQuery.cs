using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CategoryQueries
{
    public class GetCategoryByIDQuery
    {
        public int Id { get; set; }

        public GetCategoryByIDQuery(int id)
        {
            Id = id;
        }
    }
}
