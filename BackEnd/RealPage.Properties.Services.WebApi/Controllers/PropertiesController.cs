using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealPage.Properties.Application.DTO;
using RealPage.Properties.Application.Interface;
using System.Threading.Tasks;

namespace RealPage.Properties.Services.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : Controller
    {
        private readonly IPropertiesApplication _propertiesApplication;
        public PropertiesController(IPropertiesApplication propertiesApplication)
        {
            _propertiesApplication = propertiesApplication;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody]PropertyDto propertyDto)
        {
            if (propertyDto == null)
                return BadRequest();
            var response = await _propertiesApplication.Add(propertyDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]PropertyDto propertyDto)
        {
            if (propertyDto == null)
                return BadRequest();
            var response = await _propertiesApplication.Update(propertyDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();
            var response = await _propertiesApplication.Delete(int.Parse(id));
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{propertyId}")]
        public async Task<IActionResult> Get(string propertyId)
        {
            if (string.IsNullOrEmpty(propertyId))
                return BadRequest();
            var response = await _propertiesApplication.Get(int.Parse(propertyId));
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _propertiesApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetByState/{state}")]
        public async Task<IActionResult> GetByState(string state)
        {
            if (string.IsNullOrEmpty(state))
                return BadRequest();
            var response = await _propertiesApplication.GetByState(state);
            if (response.IsSuccess)
                return Ok(response  );

            return BadRequest(response.Message);

            return BadRequest(response.Message);
        }
    }
}