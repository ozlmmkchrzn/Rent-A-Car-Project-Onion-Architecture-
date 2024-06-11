using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;

        public CommentController(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _repository.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {

            _repository.Create(comment);
            return Ok("Yorum eklendi.");
        }

        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var values = _repository.GetById(id);
            _repository.Remove(values);
            return Ok("Yorum silindi.");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _repository.Update(comment);
            return Ok("Yorum güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id) 
        {
            var values = _repository.GetById(id);
            return Ok(values);
        }
    }
}
