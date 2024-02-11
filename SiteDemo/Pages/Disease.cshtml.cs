using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteDemo.Service;
using ViewsDisease;

namespace SiteDemo.Pages
{
    public class DiseaseModel : PageModel
    {
        DiseaseProxy diseaseProxy;
        public DiseaseModel(DiseaseProxy diseaseProxy)
        { 
            this.diseaseProxy = diseaseProxy;
            viewsDiseases = new();
            viewsDiseasesType = new();
        }

        public List<ViewDiseases> viewsDiseases;
        public List<ViewDiseasesType> viewsDiseasesType;


        public void OnGet()
        {
            viewsDiseases =diseaseProxy.GetViewDiseases();
            viewsDiseasesType = diseaseProxy.diseaseProxyType.GetDiseaseType();
        }
    }
}
