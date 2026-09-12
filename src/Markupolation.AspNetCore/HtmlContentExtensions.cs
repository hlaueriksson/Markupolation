using System.IO;
using Microsoft.AspNetCore.Html;

namespace Markupolation.AspNetCore;

/// <summary>
/// Bridges <see cref="Content"/> into Razor.
/// </summary>
public static class HtmlContentExtensions
{
    /// <summary>
    /// Wraps the content as <see cref="IHtmlContent"/>, so a Razor view can render it with
    /// <c>@content.ToHtmlContent()</c> without encoding it a second time.
    /// </summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><see cref="IHtmlContent"/></returns>
    public static IHtmlContent ToHtmlContent(this Content content) => new HtmlContent(content);

    private sealed class HtmlContent : IHtmlContent
    {
        private readonly Content _content;

        internal HtmlContent(Content content) => _content = content;

        public void WriteTo(TextWriter writer, System.Text.Encodings.Web.HtmlEncoder encoder)
        {
            // Already encoded on the way in; Razor's encoder must not run over it again.
            writer?.Write(_content?.Value);
        }
    }
}
