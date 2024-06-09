using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogsWithAuthors()
        {
            var values = _context.Blogs.Include(x => x.Author).Include(y => y.Category).ToList();
            return values;
        }

        public List<Blog> GetLat3BlogsWithAuthors()
        {
            var values = _context.Blogs.Include(x => x.Author).OrderByDescending(y => y.BlogID).Take(3).ToList();
            return values;
        }
    }
}
