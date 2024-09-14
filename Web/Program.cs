using Statiq.App;
using Statiq.Common;
using Statiq.Web;
using System;
using System.Threading.Tasks;

await Bootstrapper
    .Factory
    .CreateWeb(args)
    .AddSetting(WebKeys.Xref, Config.FromDocument(doc => doc.Destination.FileNameWithoutExtension))
    .RunAsync();