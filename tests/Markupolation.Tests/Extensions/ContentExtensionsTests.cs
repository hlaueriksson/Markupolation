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
        public void Each_index()
        {
            var items = new[] { "a", "b" };
            var result = items.Each((x, i) => div(id(i), x));
            result.ToString().Should().Be("<div id=\"0\">a</div><div id=\"1\">b</div>");

            result = Enumerable.Empty<string>().Each((x, i) => div(id(i), x));
            result.ToString().Should().BeEmpty();

            ((IEnumerable<string>)null).Each((x, i) => div(id(i), x));
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
        public void IfNull_otherwise()
        {
            int? item = null;
            item.IfNull(then: div("null"), otherwise: x => div(x)).ToString()
                .Should().Be("<div>null</div>");

            item = 1;
            item.IfNull(then: div("null"), otherwise: x => div(x)).ToString()
                .Should().Be("<div>1</div>");
            item.IfNull(then: div("null"), otherwise: null).ToString()
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
        public void IfNotNull_otherwise()
        {
            int? item = null;
            item.IfNotNull(then: x => div(x), otherwise: div("null")).ToString()
                .Should().Be("<div>null</div>");

            item = 1;
            item.IfNotNull(then: x => div(x), otherwise: div("null")).ToString()
                .Should().Be("<div>1</div>");
            item.IfNotNull(then: null, otherwise: div("null")).ToString()
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
        public void IfNullOrEmpty_otherwise()
        {
            string item = null;
            item.IfNullOrEmpty(then: div("null"), otherwise: x => div(x)).ToString()
                .Should().Be("<div>null</div>");

            item = "";
            item.IfNullOrEmpty(then: div("null"), otherwise: x => div(x)).ToString()
                .Should().Be("<div>null</div>");

            item = "foo";
            item.IfNullOrEmpty(then: div("null"), otherwise: x => div(x)).ToString()
                .Should().Be("<div>foo</div>");
            item.IfNullOrEmpty(then: div("null"), otherwise: null).ToString()
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
        public void IfNotNullOrEmpty_otherwise()
        {
            string item = null;
            item.IfNotNullOrEmpty(then: x => div(x), otherwise: div("null")).ToString()
                .Should().Be("<div>null</div>");

            item = "";
            item.IfNotNullOrEmpty(then: x => div(x), otherwise: div("null")).ToString()
                .Should().Be("<div>null</div>");

            item = "foo";
            item.IfNotNullOrEmpty(then: x => div(x), otherwise: div("null")).ToString()
                .Should().Be("<div>foo</div>");
            item.IfNotNullOrEmpty(then: null, otherwise: div("null")).ToString()
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
        public void IfEmpty_otherwise()
        {
            var items = new[] { 1, 2 };
            items.IfEmpty(then: div("empty"), otherwise: x => div(x.Count())).ToString()
                .Should().Be("<div>2</div>");
            items.IfEmpty(then: div("empty"), otherwise: null).ToString()
                .Should().BeEmpty();

            Enumerable.Empty<int>().IfEmpty(then: div("empty"), otherwise: x => div(x.Count())).ToString()
                .Should().Be("<div>empty</div>");

            ((IEnumerable<int>)null).IfEmpty(then: div("empty"), otherwise: x => div(x.Count())).ToString()
                .Should().Be("<div>empty</div>");
        }

        [Test]
        public void IfNotEmpty()
        {
            var items = new[] { 1, 2 };
            items.IfNotEmpty(x => div(x.Count())).ToString()
                .Should().Be("<div>2</div>");
            items.IfNotEmpty(null).ToString()
                .Should().BeEmpty();

            Enumerable.Empty<int>().IfNotEmpty(x => div(x.Count())).ToString()
                .Should().BeEmpty();

            ((IEnumerable<int>)null).IfNotEmpty(x => div(x.Count())).ToString()
                .Should().BeEmpty();
        }

        [Test]
        public void IfNotEmpty_otherwise()
        {
            var items = new[] { 1, 2 };
            items.IfNotEmpty(then: x => div(x.Count()), otherwise: div("empty")).ToString()
                .Should().Be("<div>2</div>");
            items.IfNotEmpty(then: null, otherwise: div("empty")).ToString()
                .Should().BeEmpty();

            Enumerable.Empty<int>().IfNotEmpty(then: x => div(x.Count()), otherwise: div("empty")).ToString()
                .Should().Be("<div>empty</div>");

            ((IEnumerable<int>)null).IfNotEmpty(then: x => div(x.Count()), otherwise: div("empty")).ToString()
                .Should().Be("<div>empty</div>");
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
        public void IfHasValue_otherwise()
        {
            int? item = null;
            item.IfHasValue(then: x => div(x), otherwise: div("null")).ToString()
                .Should().Be("<div>null</div>");

            item = 1;
            item.IfHasValue(then: x => div(x), otherwise: div("null")).ToString()
                .Should().Be("<div>1</div>");
            item.IfHasValue(then: null, otherwise: div("null")).ToString()
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

        [Test]
        public void IfMatch_otherwise()
        {
            var item = "FooBar";
            item.IfMatch(m => m.Length == 6, then: x => div(x), otherwise: x => section(x)).ToString()
                .Should().Be("<div>FooBar</div>");

            item.IfMatch(m => m.EndsWith("Foo"), then: x => div(x), otherwise: x => section(x)).ToString()
                .Should().Be("<section>FooBar</section>");

            item.IfMatch(null, then: x => div(x), otherwise: x => section(x)).ToString()
                .Should().BeEmpty();
            item.IfMatch(m => m.Length == 6, then: null, otherwise: x => section(x)).ToString()
                .Should().BeEmpty();
            item.IfMatch(m => m.EndsWith("Foo"), then: x => div(x), otherwise: null).ToString()
                .Should().BeEmpty();
        }
    }
}
