using ModelsDisease;

using Microsoft.EntityFrameworkCore;
using Infrastruct;

namespace ServiceDisease
{
    public class ServiceDisease
    {
        AppDBModel _appDB;
        public ServiceDisease(AppDBModel _appDB)
        {
            this._appDB = _appDB;
        }

        public IEnumerable<Disease> getDisease()
        {
            _appDB.Diseases.Include(u=>u.DiseaseType).Load();
            return _appDB.Diseases;
        }

        public Disease? UpdDisease(Disease disease)
        { 
            var t= _appDB.Diseases.FirstOrDefault(u=>u.Id == disease.Id);
            (t as IUpdate<Disease>)?.Update(disease);
            _appDB.SaveChanges();
            return t;
        }

        public Disease? AddDisease(Disease disease)
        {
            if(_appDB.Diseases.Any(u => u.Id == disease.Id))
                throw new Exception("");            
                
            _appDB.Diseases.Add(disease);
            _appDB.SaveChanges();
            return disease;
        }

        public DiseaseType? getDiseaseType(int CodeType)
        {
            if(!_appDB.DiseaseTypes.Any(u => u.Code == CodeType))
                throw new Exception("");

            return _appDB.DiseaseTypes.FirstOrDefault(u => u.Code == CodeType);
        }

        public Disease getDisease(Guid Id)
        {           
            return _appDB.Diseases.Include(u => u.DiseaseType).First(u => u.Id == Id);
        }
    }
}
