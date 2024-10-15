using Statiq.App;
using Statiq.Common;
using Statiq.Web;
using System;
using System.Threading.Tasks;
using Web;

await Bootstrapper
    .Factory
    .CreateWeb(args)
    .AddSetting(WebKeys.Xref, Config.FromDocument(doc => doc.Destination.FileNameWithoutExtension))
    .AddShortcode<InstagramShortcode>("instagram")
    .AddShortcode<LinkedinShortcode>("linkedin")
    .RunAsync();