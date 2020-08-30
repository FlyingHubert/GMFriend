using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Markdig;

namespace BusinessLogic.Notes.Markdown
{
    public class MarkdownService : IMarkdownService
    {
        public string ToStyledHTML(string input)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var stream = assembly.GetManifestResourceStream(
                assembly.GetManifestResourceNames().Single(s => s.Contains("markdown.css")));

            var reader = new StreamReader(stream);

            var html = Markdig.Markdown.ToHtml(input);


            var result = $"<head><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'></head>\r\n" +
                         $"<style>{reader.ReadToEnd()}</style>\r\n" +
                         $"{html}";

            return result;
        }
    }
}