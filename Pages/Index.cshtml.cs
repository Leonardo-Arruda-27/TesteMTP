using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteMTP.Controllers;

namespace TesteMTP.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            
            return Page();
        }
    }
}
