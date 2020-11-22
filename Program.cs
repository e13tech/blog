using Statiq.App;
using Statiq.Web;
using System;
using System.Threading.Tasks;

namespace Blog
{
    public class Program
    {
        public static async Task<int> Main(string[] args) =>
          await Bootstrapper
            .Factory
            .CreateWeb(args)
            .RunAsync();
    }
}
