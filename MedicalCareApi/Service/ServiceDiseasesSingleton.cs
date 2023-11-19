using MedicalCareApi.DB;
using MedicalCareApi.Models;
using MedicalCareApi.Views;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCareApi.Service
{
    public class ServiceDiseasesSingleton
    {
        AppDBModel _appDB;
        public ServiceDisease BuildServiseDisease()
        {
            return new ServiceDisease(_appDB);
        }
        public ServiceDiseasesSingleton (AppDBModel appDB)
        {
            _appDB = appDB;
        }

        public ViewDiseases GetViewDiseases(Disease? dis)
        {
            return new ViewDiseases() {
                Id = dis.Id,
                Name = dis.Name,
                CodeName = dis.DiseaseType.Name,
                CodeType = dis.DiseaseType.Code,
                Description = dis.Description,
                DiscriptorDoctor = dis.DiscriptionDoctor
            };
        }

        public Disease GetDisease(ViewDiseases? dis) 
        { 
            return new Disease() { 
                Id = dis.Id,
                Name = dis.Name,
                Description = dis.Description,
                DiseaseType = BuildServiseDisease().getDiseaseType(dis.CodeType),
                DiscriptionDoctor = dis.DiscriptorDoctor

            };
        }

        public async Task<ViewDiseases> UpdateDisease(ViewDiseases viewDiseases)
        {
                
               var t = BuildServiseDisease().UpdDisease(GetDisease(viewDiseases));
                if (t == null)
                    throw new Exception("");
               return GetViewDiseases(t);
        }

        public async Task<ViewDiseases> AddDisease(ViewDiseases viewDiseases)
        {
            var t = BuildServiseDisease().AddDisease(GetDisease(viewDiseases));
            return GetViewDiseases(t);
        }

        public async Task<ViewDiseases> getDisease(Guid Id)
        {
            var t = BuildServiseDisease().getDisease(Id);
            return GetViewDiseases(t);
        }

    }
}
