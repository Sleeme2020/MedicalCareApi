using MedicalCareApi.DB;
using MedicalCareApi.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalCareApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MedicalCareApi.Service;

namespace MedicalCareApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiseasesController : ControllerBase
    {
        ServiceDiseasesSingleton _diseasesSingleton;
        public DiseasesController(ServiceDiseasesSingleton diseasesSingleton)
        {
            _diseasesSingleton = diseasesSingleton;
        }

        [HttpGet]
        public async Task<IEnumerable<ViewDiseases>> Get()
        {
            var t = Task.Run(delegate ()
            {
                return _diseasesSingleton.BuildServiseDisease().getDisease().Select(u => _diseasesSingleton.GetViewDiseases(u));

            });
            return await t;
        }

        [HttpGet("{Id}")]
        public async Task<ViewDiseases> Get([FromQuery] Guid Id)
        {
            var t = Task.Run(delegate ()
            {
                return _diseasesSingleton.getDisease(Id);

            });
            return await t;
        }

        [HttpPost]
        public async Task<ActionResult<ViewDiseases>> Post([FromBody] ViewDiseases viewDiseases)
        {
            if (viewDiseases.Id == Guid.Empty)
            {
                return await _diseasesSingleton.AddDisease(viewDiseases);
            } 
            
            return await _diseasesSingleton.UpdateDisease(viewDiseases);
        }


        [HttpPost("{Id}")]
        public async Task<ActionResult<ViewDiseases>> PostId([FromQuery] Guid Id,[FromBody] ViewDiseases viewDiseases)
        {

            if (Id != Guid.Empty)
            {
                viewDiseases.Id = Id;
                return await _diseasesSingleton.UpdateDisease(viewDiseases);
            }

            return BadRequest();
        }
    }
}