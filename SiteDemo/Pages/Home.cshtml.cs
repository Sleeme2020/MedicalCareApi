using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SiteDemo.Pages
{
    public class HomeModel : PageModel
    {
        public string NowTime { get; set; }
        public void OnGet()
        {
            NowTime = DateTime.Now.ToString();
        }
    }
}
