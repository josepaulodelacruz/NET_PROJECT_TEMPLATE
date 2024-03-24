using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TestProjectRazor.Services;
using TestProjectRazor.Models;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectRazor.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _service;
        private readonly IConfiguration _config;

        public IEnumerable<User> ListOfUsers { get; set; }

        public IndexModel(IUserService service, IConfiguration config)
        {
            _config = config;
            _service = service;
        }



        public async Task OnGetAsync()
        {
            ListOfUsers = await _service.Get(_config);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _service.DeleteUserById(_config, id);

            return RedirectToPage();
        }
    }
}
