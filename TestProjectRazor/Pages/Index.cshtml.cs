using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TestProjectRazor.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Debug.WriteLine("Hello, World! Jose");

        }
    }
}
