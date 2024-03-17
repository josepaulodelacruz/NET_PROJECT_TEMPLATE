using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TestProjectRazor.Services
{
    public interface IUserService
    {
        Task<IEnumerable<string>> Get();
    }

    public class UserService : IUserService
    {
        public async Task<IEnumerable<string>> Get()
        {
            return new string[]
            {
                "Value1",
                "Value2",
                "Value3",
            };
        }
    }
}
