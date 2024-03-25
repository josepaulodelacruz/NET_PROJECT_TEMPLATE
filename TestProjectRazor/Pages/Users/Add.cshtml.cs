using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TestProjectRazor.Models;
using Microsoft.Extensions.Configuration;
using TestProjectRazor.Services;

namespace TestProjectRazor.Pages.Users
{
    public class AddModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IUserService _service;
        
        [BindProperty]
        public User NewUser { get; set; }

        public AddModel(IConfiguration config, IUserService service)
        {
            _config = config;
            _service = service;
        }

        public async void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.AddUser(_config, NewUser);

            return RedirectToPage("./Index");
        }
    }
}
