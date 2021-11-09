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
            item.IfNull(div("null")).ToString()
                .Should().Be("<div>null</div>");

            item = 1;
            item.IfNull(div("null")).ToString()
                .Should().BeEmpty();
        }

        [Test]
        public void IfNotNull()
        {
            int? item = null;
            item.IfNotNull(x => div(x)).ToString()
                .Should().BeEmpty();

            item = 1;
            item.IfNotNull(x => div(x)).ToString()
                .Should().Be("<div>1</div>");

            item.IfNotNull(null).ToString()
                .Should().BeEmpty();
        }

        [Test]
        public void IfNullOrEmpty()
        {
            string item = null;
            item.IfNullOrEmpty(div("null")).ToString()
                .Should().Be("<div>null</div>");

            item = "";
            item.IfNullOrEmpty(div("null")).ToString()
                .Should().Be("<div>null</div>");

            item = "foo";
            item.IfNullOrEmpty(div("null")).ToString()
                .Should().BeEmpty();
        }

        [Test]
        public void IfNotNullOrEmpty()
        {
            string item = null;
            item.IfNotNullOrEmpty(x => div(x)).ToString()
                .Should().BeEmpty();

            item = "";
            item.IfNotNullOrEmpty(x => div(x)).ToString()
                .Should().BeEmpty();

            item = "foo";
            item.IfNotNullOrEmpty(x => div(x)).ToString()
                .Should().Be("<div>foo</div>");

            item.IfNotNullOrEmpty(null).ToString()
                .Should().BeEmpty();
        }

        [Test]
        public void IfEmpty()
        {
            var items = new[] { 1, 2 };
            items.IfEmpty(div("empty")).ToString()
                .Should().BeEmpty();

            Enumerable.Empty<int>().IfEmpty(div("empty")).ToString()
                .Should().Be("<div>empty</div>");

            ((IEnumerable<int>)null).IfEmpty(div("empty")).ToString()
                .Should().Be("<div>empty</div>");
        }

        [Test]
        public void IfNotEmpty()
        {
            var items = new[] { 1, 2 };
            items.IfNotEmpty(x => div(x.Count())).ToString()
                .Should().Be("<div>2</div>");

            Enumerable.Empty<int>().IfNotEmpty(x => div(x.Count())).ToString()
                .Should().BeEmpty();

            ((IEnumerable<int>)null).IfNotEmpty(x => div(x.Count())).ToString()
                .Should().BeEmpty();

            items.IfNotEmpty(null).ToString()
                .Should().BeEmpty();
        }

        [Test]
        public void IfHasValue()
        {
            int? item = null;
            item.IfHasValue(x => div(x)).ToString()
                .Should().BeEmpty();

            item = 1;
            item.IfHasValue(x => div(x)).ToString()
                .Should().Be("<div>1</div>");

            item.IfHasValue(null).ToString()
                .Should().BeEmpty();
        }

        [Test]
        public void IfNotHasValue()
        {
            int? item = null;
            item.IfNotHasValue(div("null")).ToString()
                .Should().Be("<div>null</div>");

            item = 1;
            item.IfNotHasValue(div("null")).ToString()
                .Should().BeEmpty();
        }

        [Test]
        public void IfMatch()
        {
            var item = "FooBar";
            item.IfMatch(m => m.Length == 6, x => div(x)).ToString()
                .Should().Be("<div>FooBar</div>");

            item.IfMatch(m => m.EndsWith("Foo"), x => div(x)).ToString()
                .Should().BeEmpty();

            item.IfMatch(null, x => div(x)).ToString()
                .Should().BeEmpty();

            item.IfMatch(m => m.Length == 6, null).ToString()
                .Should().BeEmpty();
        }
    }
}
