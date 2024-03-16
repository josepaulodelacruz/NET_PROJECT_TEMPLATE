using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProjectRazor.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Route("test-connection")]
        public string[] TestConnection()
        {
            return new string[]
            {
                "TEST",
                "Connection",
                "Jose"
            };


        }
    }
}
