using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests
{
    public class ElementsTests
    {
        [Test]
        public void NormalElement()
        {
            var result = a(href("https://html.spec.whatwg.org/multipage/"), "Read the HTML Living Standard");
            result.ToString().Should().Be("<a href=\"https://html.spec.whatwg.org/multipage/\">Read the HTML Living Standard</a>");

            result = a(href("https://html.spec.whatwg.org/multipage/"), $"Read the {b($"HTML {i("Living")}")} Standard");
            result.ToString().Should().Be("<a href=\"https://html.spec.whatwg.org/multipage/\">Read the <b>HTML <i>Living</i></b> Standard</a>");
        }

        [Test]
        public void VoidElement()
        {
            var result = img(id("main-logo"), crossorigin(null), src("https://resources.whatwg.org/logo.svg"));
            result.ToString().Should().Be("<img id=\"main-logo\" crossorigin src=\"https://resources.whatwg.org/logo.svg\" />");

            result = img(id("main-logo"), crossorigin(null), src("https://resources.whatwg.org/logo.svg"), "Child");
            result.ToString().Should().Be("<img id=\"main-logo\" crossorigin src=\"https://resources.whatwg.org/logo.svg\" />");
        }

        [Test]
        public void Element_()
        {
            base_().ToString().Should().Be("<base />");
            object_().ToString().Should().Be("<object></object>");
        }
    }
}
