using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.FetureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            var values = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Özellik Başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _mediator.Send(new RemoreFeatureCommand(id));
            return Ok("Özellik Başarıyla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Özellik Başarıyla Güncellendi.");
        }
    }
}
