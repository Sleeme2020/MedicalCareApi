
using ViewsDisease;
using Microsoft.AspNetCore.Mvc;
using ModelsDisease;
using Microsoft.AspNetCore.Http.HttpResults;

using Microsoft.AspNetCore.Authorization;
using Infrastruct;


namespace MedicalCareApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiseasesController : ControllerBase
    {
        //IServiceModel<Disease> _diseasesSingleton;
        //public DiseasesController(IServiceModel<Disease> diseasesSingleton)
        //{
        //    _diseasesSingleton = diseasesSingleton;
        //}

        List<ViewDiseases> t = new List<ViewDiseases>()
            {
                new ViewDiseases() { Description="About 1", FullName = "Name 1", DiseasesType = new ViewDiseasesType() { CodeName = "TypeNAme1", CodeType = 3 } },
            new ViewDiseases() { Description="About 2", FullName = "Name 2", DiseasesType = new ViewDiseasesType() { CodeName = "TypeNAme1", CodeType = 3 } },
            new ViewDiseases() { Description="About 3", FullName = "Name 3", DiseasesType = new ViewDiseasesType() { CodeName = "TypeNAme2", CodeType = 2 } },
            };


        [HttpGet]
        public async Task<IEnumerable<ViewDiseases>> Get()
        {
            //var t = await Task.Run(delegate ()
            //{
            //    return _diseasesSingleton
            //    .get()
            //    .Select(u => ViewConverterDises.DisiesToView(u,u.DiseaseType));

            //});

            

            return  t;
        }


        [HttpPost]
        public async Task<ActionResult<ViewDiseases>> Post([FromBody] ViewDiseases viewDiseases)
        {
            t.Add(viewDiseases);
            return viewDiseases;
        }

        //[HttpGet("{Id}")]
        //public async Task<ViewDiseases> Get([FromQuery] Guid Id)
        //{
        //    var t = await Task.Run( delegate ()
        //    {
        //        var dis = _diseasesSingleton.get(Id);
        //        return ViewConverterDises.DisiesToView(
        //             dis, dis.DiseaseType
        //            );

        //    });

        //    return t;
        //}

        //[HttpPost]
        //public async Task<ActionResult<ViewDiseases>> Post([FromBody] ViewDiseases viewDiseases)
        //{
        //    if (viewDiseases.Id == Guid.Empty)
        //    {
        //        var Dis = _diseasesSingleton.Add(
        //                ViewConverterDises.ViewToDisease(viewDiseases, viewDiseases.DiseasesType)
        //                );
        //        return ViewConverterDises.DisiesToView(
        //            Dis, Dis.DiseaseType
        //            );
        //    }
        //    var dis =  _diseasesSingleton.Upd(viewDiseases.Id,
        //                ViewConverterDises.ViewToDisease(viewDiseases, viewDiseases.DiseasesType)
        //                );
        //    return ViewConverterDises.DisiesToView(
        //            dis, dis.DiseaseType
        //            );
        //}



        //[HttpPost("{Id}")]
        //public async Task<ActionResult<ViewDiseases>> PostId([FromQuery] Guid Id,[FromBody] ViewDiseases viewDiseases)
        //{

        //    if (Id != Guid.Empty)
        //    {
        //        viewDiseases.Id = Id;
        //        var dis = _diseasesSingleton.Upd(Id,
        //                ViewConverterDises.ViewToDisease(viewDiseases, viewDiseases.DiseasesType)
        //                );
        //        return ViewConverterDises.DisiesToView(
        //            dis, dis.DiseaseType
        //            );
        //    }

        //    return BadRequest();
        //}
    }
}