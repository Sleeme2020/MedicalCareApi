
using ViewsDisease;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsDisease;
using Microsoft.AspNetCore.Http.HttpResults;
using ServiceDisease;


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
                return _diseasesSingleton.BuildServiseDisease()
                .getDisease()
                .Select(u => ViewConverterDises.DisiesToView(u,u.DiseaseType));

            });
            return await t;
        }

        [HttpGet("{Id}")]
        public async Task<ViewDiseases> Get([FromQuery] Guid Id)
        {
            var t = await Task.Run(async delegate ()
            {
                var dis = await _diseasesSingleton.getDisease(Id);
                return ViewConverterDises.DisiesToView(
                     dis, dis.DiseaseType
                    );

            });

            return t;
        }

        [HttpPost]
        public async Task<ActionResult<ViewDiseases>> Post([FromBody] ViewDiseases viewDiseases)
        {
            if (viewDiseases.Id == Guid.Empty)
            {
                var Dis = await _diseasesSingleton.AddDisease(
                        ViewConverterDises.ViewToDisease(viewDiseases, viewDiseases.DiseasesType)
                        );
                return ViewConverterDises.DisiesToView(
                    Dis, Dis.DiseaseType
                    );
            }
            var dis = await _diseasesSingleton.UpdateDisease(
                        ViewConverterDises.ViewToDisease(viewDiseases, viewDiseases.DiseasesType)
                        );
            return ViewConverterDises.DisiesToView(
                    dis, dis.DiseaseType
                    );
        }


        [HttpPost("{Id}")]
        public async Task<ActionResult<ViewDiseases>> PostId([FromQuery] Guid Id,[FromBody] ViewDiseases viewDiseases)
        {

            if (Id != Guid.Empty)
            {
                viewDiseases.Id = Id;
                var dis = await _diseasesSingleton.UpdateDisease(
                        ViewConverterDises.ViewToDisease(viewDiseases, viewDiseases.DiseasesType)
                        );
                return ViewConverterDises.DisiesToView(
                    dis, dis.DiseaseType
                    );
            }

            return BadRequest();
        }
    }
}