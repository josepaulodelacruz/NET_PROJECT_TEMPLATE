using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using TestProjectRazor.Services;
using TestProjectRazor.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TestProjectRazor.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IUserService _service;

        [BindProperty]
        public User User { get; set; }

        public EditModel(IConfiguration config, IUserService service)
        {
            _config = config;
            _service = service;
        }

        public async Task OnGetAsync(int id)
        {
            User = await _service.GetById(_config, id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _service.UpdateUser(_config, User, id);

            return RedirectToPage("./Index");
        }
    }
}
