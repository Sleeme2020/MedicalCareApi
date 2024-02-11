using Microsoft.Extensions.Caching.Memory;
using ViewsDisease;

namespace SiteBlazorServer
{
    public class DiseaseProxyType
    {
        IMemoryCache cache;
        HttpClient client;
        
        public DiseaseProxyType(IMemoryCache cacheSystem)
        {
            cache = cacheSystem;
            client = new HttpClient();
        }

        public ViewDiseasesType GetDiseaseType(int CodeType)
        {
            var Dis = cache.Get($"DISType_{CodeType}") as ViewDiseasesType;
            if (Dis is not null) return Dis;

            var httpResult = client.GetAsync("http://localhost:5014/Diseases").GetAwaiter().GetResult().Content.ReadFromJsonAsync<ViewDiseasesType>();
            httpResult.Wait();
            var Result = httpResult.Result;
            if (Result is null) new Exception();
                

            cache.Set($"DISType_{CodeType}", Result, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15)));

            return Result;
        }

        //Избыточное кеширование
        public List<ViewDiseasesType> GetDiseaseType()
        {
            var Dis = cache.Get("ALL_DisieseType") as List<ViewDiseasesType>;
            if (Dis is not null) return Dis;

            var httpResult = client.GetAsync("http://localhost:5014/Diseases").GetAwaiter().GetResult().Content.ReadFromJsonAsync<List<ViewDiseases>>();
           

            httpResult.Wait();
            var Result = httpResult.Result;
            List<ViewDiseasesType> newList = new();
            newList.AddRange(Result.Select(u => u.DiseasesType).ToArray());
            if (Result is null) new Exception();
            cache.Set("ALL_DisieseType", newList, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(35)));
            return newList;
        }

        public bool Contrains(int Id)
        {
           return cache.TryGetValue(Id, out var result);
        }
        public void AddViewDiseasesType (ViewDiseasesType viewDiseasesType)
        {
            cache.Set($"DISType_{viewDiseasesType.CodeType}", viewDiseasesType, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15)));
          
        }

    }



    public class DiseaseProxy
    {
        IMemoryCache cache;
        HttpClient client;
        public DiseaseProxyType diseaseProxyType { get; init; }
        public DiseaseProxy(IMemoryCache cacheSystem, DiseaseProxyType diseaseProxy) 
        {
            cache = cacheSystem;
            client = new HttpClient();
            this.diseaseProxyType = diseaseProxy;
        }

        public ViewDiseases GetViewDiseases(int id)
        {
            var Dis= cache.Get($"DIS_{id}") as ViewDiseases;
            if (Dis is not null) return Dis;

            var httpResult =client.GetAsync("http://localhost:5014/Diseases").GetAwaiter().GetResult().Content.ReadFromJsonAsync<ViewDiseases>();
            httpResult.Wait();
            var Result = httpResult.Result;
            if (Result is null) new Exception();
            if (diseaseProxyType.Contrains(Result.DiseasesType.CodeType))
                Result.DiseasesType = diseaseProxyType.GetDiseaseType(Result.DiseasesType.CodeType);
            else
                diseaseProxyType.AddViewDiseasesType(Result.DiseasesType);

            cache.Set($"DIS_{id}", Result, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15)));

            return Result;

        }

        //Избыточное кеширование
        public List<ViewDiseases> GetViewDiseases()
        {
            var Dis = cache.Get("ALL_Disiese") as List<ViewDiseases>;
            if (Dis is not null) return Dis;

            var httpResult = client.GetAsync("http://localhost:5014/Diseases").GetAwaiter().GetResult().Content.ReadFromJsonAsync<List<ViewDiseases>>();
            httpResult.Wait();
            var Result = httpResult.Result;
            if (Result is null) new Exception();
            foreach(var res in Result)
            {
                if (diseaseProxyType.Contrains(res.DiseasesType.CodeType))
                    res.DiseasesType = diseaseProxyType.GetDiseaseType(res.DiseasesType.CodeType);
                else
                    diseaseProxyType.AddViewDiseasesType(res.DiseasesType);

            }                        

            cache.Set("ALL_Disiese", Result, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(35)));

            return Result;
        }

        //public bool Contrains(int Id)
        //{

        //}

    }
}
