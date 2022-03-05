using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawsuitsAPI.Data.Repositories;
using LawsuitsAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LawsuitsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawsuitController : ControllerBase
    {
        private readonly ILawsuitRepository _lawsuitRepository;

        public LawsuitController(ILawsuitRepository lawsuitRepository)
        {
            _lawsuitRepository = lawsuitRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLawsuits()
        {
            return Ok(await _lawsuitRepository.GetAllLawsuits());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLawsuitDetails(int id)
        {
            return Ok(await _lawsuitRepository.GetLawsuitDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLawsuit([FromBody] Lawsuit lawsuit)
        {
            if (lawsuit == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) // Comprueba que estén los campos requeridos, etc.
            {
                return BadRequest(ModelState);
            }
            var created = await _lawsuitRepository.InsertLawsuit(lawsuit);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLawsuit([FromBody] Lawsuit lawsuit)
        {
            if (lawsuit == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _lawsuitRepository.UpdateLawsuit(lawsuit);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLawsuit(int id)
        {
            await _lawsuitRepository.DeleteLawsuit(new Lawsuit() { Id = id });

            return NoContent();
        }
    }
}