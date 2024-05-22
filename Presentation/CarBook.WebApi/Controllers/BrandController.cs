
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly GetBrandQueryHandler getBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler getBrandByIdQueryHandler;
        private readonly CreateBrandCommandHandler createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler removeBrandCommandHandler;

        public BrandController(GetBrandQueryHandler getBrandQueryHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            this.getBrandQueryHandler = getBrandQueryHandler;
            this.getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            this.createBrandCommandHandler = createBrandCommandHandler;
            this.updateBrandCommandHandler = updateBrandCommandHandler;
            this.removeBrandCommandHandler = removeBrandCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = await getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await createBrandCommandHandler.Handle(command);
            return Ok("Marka Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Marka Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await updateBrandCommandHandler.Handle(command);
            return Ok("Marka Güncellendi.");
        }
    }
}
