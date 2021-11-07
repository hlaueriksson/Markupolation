using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests
{
    public class ContentExtensionsTests
    {
        [Test]
        public void Each()
        {
            var items = new[] { 1, 2 };
            var result = items.Each(x => div(x));
            result.ToString().Should().Be("<div>1</div><div>2</div>");

            result = Enumerable.Empty<int>().Each(x => div(x));
            result.ToString().Should().BeEmpty();

            ((IEnumerable<int>)null).Each(x => div(x));
            result.ToString().Should().BeEmpty();
        }

        [Test]
        public void IfNull()
        {
            int? item = null;
            var result = item.IfNull(div("null"));
            result.ToString().Should().Be("<div>null</div>");

            item = 1;
            result = item.IfNull(div("null"));
            result.ToString().Should().BeEmpty();
        }

        [Test]
        public void IfNotNull()
        {
            int? item = null;
            var result = item.IfNotNull(x => div(x));
            result.ToString().Should().BeEmpty();

            item = 1;
            result = item.IfNotNull(x => div(x));
            result.ToString().Should().Be("<div>1</div>");

            result = item.IfNotNull(null);
            result.ToString().Should().BeEmpty();
        }

        [Test]
        public void IfNullOrEmpty()
        {
            string item = null;
            var result = item.IfNullOrEmpty(div("null"));
            result.ToString().Should().Be("<div>null</div>");

            item = "";
            result = item.IfNullOrEmpty(div("null"));
            result.ToString().Should().Be("<div>null</div>");

            item = "foo";
            result = item.IfNullOrEmpty(div("null"));
            result.ToString().Should().BeEmpty();
        }

        [Test]
        public void IfNotNullOrEmpty()
        {
            string item = null;
            var result = item.IfNotNullOrEmpty(x => div(x));
            result.ToString().Should().BeEmpty();

            item = "";
            result = item.IfNotNullOrEmpty(x => div(x));
            result.ToString().Should().BeEmpty();

            item = "foo";
            result = item.IfNotNullOrEmpty(x => div(x));
            result.ToString().Should().Be("<div>foo</div>");

            result = item.IfNotNullOrEmpty(null);
            result.ToString().Should().BeEmpty();
        }

        [Test]
        public void IfEmpty()
        {
            var items = new[] { 1, 2 };
            var result = items.IfEmpty(div("empty"));
            result.ToString().Should().BeEmpty();

            result = Enumerable.Empty<int>().IfEmpty(div("empty"));
            result.ToString().Should().Be("<div>empty</div>");

            ((IEnumerable<int>)null).IfEmpty(div("empty"));
            result.ToString().Should().Be("<div>empty</div>");
        }

        [Test]
        public void IfNotEmpty()
        {
            var items = new[] { 1, 2 };
            var result = items.IfNotEmpty(x => div(x.Count()));
            result.ToString().Should().Be("<div>2</div>");

            result = Enumerable.Empty<int>().IfNotEmpty(x => div(x.Count()));
            result.ToString().Should().BeEmpty();

            ((IEnumerable<int>)null).IfNotEmpty(x => div(x.Count()));
            result.ToString().Should().BeEmpty();

            result = items.IfNotEmpty(null);
            result.ToString().Should().BeEmpty();
        }

        [Test]
        public void IfHasValue()
        {
            int? item = null;
            var result = item.IfHasValue(x => div(x));
            result.ToString().Should().BeEmpty();

            item = 1;
            result = item.IfHasValue(x => div(x));
            result.ToString().Should().Be("<div>1</div>");

            result = item.IfHasValue(null);
            result.ToString().Should().BeEmpty();
        }

        [Test]
        public void IfNotHasValue()
        {
            int? item = null;
            var result = item.IfNotHasValue(div("null"));
            result.ToString().Should().Be("<div>null</div>");

            item = 1;
            result = item.IfNotHasValue(div("null"));
            result.ToString().Should().BeEmpty();
        }

        [Test]
        public void IfMatch()
        {
            var item = "FooBar";
            var result = item.IfMatch(m => m.Length == 6, x => div(x));
            result.ToString().Should().Be("<div>FooBar</div>");

            result = item.IfMatch(m => m.EndsWith("Foo"), x => div(x));
            result.ToString().Should().BeEmpty();

            result = item.IfMatch(null, x => div(x));
            result.ToString().Should().BeEmpty();

            result = item.IfMatch(m => m.Length == 6, null);
            result.ToString().Should().BeEmpty();
        }
    }
}
