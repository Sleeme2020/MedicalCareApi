using ModelsDisease;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsDisease
{
    static public class ViewConverterDises
    {

        static public ViewDiseases DisiesToView(Disease? dis, DiseaseType? diseaseType)
        {
            return new ViewDiseases()
            {
                Id = dis.Id,
                Name = dis.Name,
                DiseasesType = DisiesTypeToView(diseaseType), 
                Description = dis.Description,
                DiscriptorDoctor = dis.DiscriptionDoctor,
                FullName = dis.FullName,
            };
        }


        static public Disease ViewToDisease(ViewDiseases? dis, ViewDiseasesType? diseaseType)
        {
            return new Disease()
            {
                Id = dis.Id,
                Name = dis.Name,
                Description = dis.Description,
                DiseaseType = ViewToDisiesType(diseaseType),
                DiscriptionDoctor = dis.DiscriptorDoctor,
                FullName = dis.FullName

            };
        }

        static public ViewDiseasesType DisiesTypeToView(DiseaseType? diseaseType)
        {
            return new ViewDiseasesType()
            {
                CodeName = diseaseType.Name,
                 CodeType = diseaseType.Code
            };
        }

        static public DiseaseType ViewToDisiesType(ViewDiseasesType? diseaseType)
        {
            return new DiseaseType()
            {
                 Code = diseaseType.CodeType,
                 Name = diseaseType.CodeName
            };
        }
    }
}
