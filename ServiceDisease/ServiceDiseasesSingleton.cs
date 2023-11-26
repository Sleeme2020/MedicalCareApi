using ModelsDisease;

namespace ServiceDisease
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

        public async Task<Disease> UpdateDisease(Disease Diseases)
        {

            var t = await Task.Run(() => {
                return BuildServiseDisease().UpdDisease(Diseases);
            });
            if (t == null)
                throw new Exception("");
            return t;
        }

        public async Task<Disease> AddDisease(Disease Diseases)
        {
            var t = await Task.Run(() => {
                return BuildServiseDisease().AddDisease(Diseases);
            });
            return t;
        }

        public async Task<Disease> getDisease(Guid Id)
        {
            var t = await Task.Run(() => {
                return BuildServiseDisease().getDisease(Id);
            });
            return t;
        }

    }
}
