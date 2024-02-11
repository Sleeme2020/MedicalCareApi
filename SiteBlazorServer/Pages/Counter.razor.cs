using Microsoft.AspNetCore.Components;

namespace SiteBlazorServer.Pages
{
    public class CounterComponent:ComponentBase
    {
       

       protected int currentCount = 0;

        protected void IncrementCount()
        {
            currentCount++;
            
        }
        
        
    }
}
