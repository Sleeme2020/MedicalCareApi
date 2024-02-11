

using Microsoft.AspNetCore.Components;
using ViewsDisease;

namespace SiteBlazorServer.Pages
{
    public class DisiesModule:ComponentBase
    {
        [Inject] DiseaseProxy diseaseProxy { get; set; }
        public List<ViewDiseases> viewsDiseases;
        public List<ViewDiseasesType> viewsDiseasesType;

        public DisiesModule()
        {
            viewsDiseases = new();
            viewsDiseasesType = new();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            viewsDiseases = diseaseProxy.GetViewDiseases();
            viewsDiseasesType = diseaseProxy.diseaseProxyType.GetDiseaseType();

        }

    }
}
