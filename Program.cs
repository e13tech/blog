using Statiq.App;
using Statiq.Common;
using Statiq.Web;

await Bootstrapper
  .Factory
  .CreateDefault(args)
  .AddWeb()
  // Add a setting that will ensure that markdown xref links resolve successfully
  .AddSetting(WebKeys.Xref, Config.FromDocument(doc => NormalizedPath.ReplaceInvalidPathChars(((string)doc.Destination.FileNameWithoutExtension))))
  //.AddTabGroupShortCode()
  .RunAsync();