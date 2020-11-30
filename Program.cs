using Statiq.App;
using Statiq.Common;
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
            .AddSetting(WebKeys.Xref, Config.FromDocument(doc => doc.Destination.FileNameWithoutExtension))
            .RunAsync();
    }
}
