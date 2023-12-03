using HospitalCard;
using Microsoft.EntityFrameworkCore;
using Infrastruct;
using AbstractSeviceBase;
namespace HospitalCardService
{
   
    public class HospitalCardService:AbstractBaseServise<HospitalCard.HospitalCard>
    {
        public HospitalCardService(AppDBModelHospital _appDB) : base(_appDB)
        {


        }
        public IEnumerable<HospitalCard.HospitalCard> getHospitalCard()
        {
            return base.GetValues();
        }

        public HospitalCard.HospitalCard? UpdHospitalCard(HospitalCard.HospitalCard disease)
        {

            return base.UpdValue(disease.Id, disease);
        }

        public HospitalCard.HospitalCard? AddHospitalCard(HospitalCard.HospitalCard disease)
        {
           return base.setValue(disease);
        }

        public HospitalCard.HospitalCard? getHospitalCard(Guid Id)
        {
            return base.GetValue(Id);
        }

}
}
