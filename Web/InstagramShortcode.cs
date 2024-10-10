using Statiq.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web
{
    public class InstagramShortcode : IShortcode
    {
        public Task<IEnumerable<ShortcodeResult>> ExecuteAsync(KeyValuePair<string, string>[] args, string content, IDocument document, IExecutionContext context)
        {
            var code = args.FirstOrDefault().Value;
            
            return
            Task.FromResult<IEnumerable<ShortcodeResult>>([
                new ShortcodeResult($"<div class=\"instagram-container\"><blockquote class=\"instagram-media\" data-instgrm-permalink=\"https://www.instagram.com/p/{code}/\" data-instgrm-version=\"13\"></blockquote></div>")
            ]);
        }
    }
}
