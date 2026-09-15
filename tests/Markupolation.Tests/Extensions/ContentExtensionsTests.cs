using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests;

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

        result = ((IEnumerable<int>)null).Each(x => div(x));
        result.ToString().Should().BeEmpty();

        result = items.Each((Func<int, Content>)null);
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

        result = ((IEnumerable<string>)null).Each((x, i) => div(id(i), x));
        result.ToString().Should().BeEmpty();

        result = items.Each((Func<string, int, Content>)null);
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
    public void IfNull_reference_type()
    {
        // The reference-type overload, exercised separately from the Nullable<T> one above -
        // string.IfNull is what a nullable website/email/etc. actually calls in practice.
        string item = null;
        item.IfNull(div("null")).ToString()
            .Should().Be("<div>null</div>");

        item = "value";
        item.IfNull(div("null")).ToString()
            .Should().BeEmpty();

        // A bare non-nullable value type is now a compile error (CS0453) rather than a permanent
        // no-op: IfNull<T> is split into a `where T : class` and a `where T : struct` (Nullable<T>)
        // overload, so `5.IfNull(...)` no longer compiles at all. Uncommenting the next line
        // demonstrates that:
        // 5.IfNull(div("null"));
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
    public void IfNull_reference_type_otherwise()
    {
        string item = null;
        item.IfNull(then: div("null"), otherwise: x => div(x)).ToString()
            .Should().Be("<div>null</div>");

        item = "value";
        item.IfNull(then: div("null"), otherwise: x => div(x)).ToString()
            .Should().Be("<div>value</div>");
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

    [Test]
    public void If()
    {
        true.If(div("yes")).ToString()
            .Should().Be("<div>yes</div>");

        false.If(div("yes")).ToString()
            .Should().BeEmpty();
    }

    [Test]
    public void If_otherwise()
    {
        true.If(then: div("yes"), otherwise: div("no")).ToString()
            .Should().Be("<div>yes</div>");

        false.If(then: div("yes"), otherwise: div("no")).ToString()
            .Should().Be("<div>no</div>");
    }

    [Test]
    public void If_lazy()
    {
        var then = 0;

        true.If(() => { then++; return div("yes"); }).ToString()
            .Should().Be("<div>yes</div>");
        then.Should().Be(1);

        false.If(() => { then++; return div("yes"); }).ToString()
            .Should().BeEmpty();
        then.Should().Be(1, "the delegate must not be invoked when the condition is not met");

        true.If((Func<Content>)null).ToString()
            .Should().BeEmpty();
    }

    [Test]
    public void If_lazy_otherwise()
    {
        int then = 0, otherwise = 0;

        true.If(() => { then++; return div("yes"); }, () => { otherwise++; return div("no"); }).ToString()
            .Should().Be("<div>yes</div>");
        then.Should().Be(1);
        otherwise.Should().Be(0, "only the branch that is taken is invoked");

        false.If(() => { then++; return div("yes"); }, () => { otherwise++; return div("no"); }).ToString()
            .Should().Be("<div>no</div>");
        then.Should().Be(1, "only the branch that is taken is invoked");
        otherwise.Should().Be(1);

        true.If(null, () => div("no")).ToString()
            .Should().BeEmpty();
        false.If(() => div("yes"), null).ToString()
            .Should().BeEmpty();
    }

    [Test]
    public void IfNull_lazy()
    {
        var then = 0;
        int? item = null;

        item.IfNull(() => { then++; return div("null"); }).ToString()
            .Should().Be("<div>null</div>");
        then.Should().Be(1);

        item = 1;
        item.IfNull(() => { then++; return div("null"); }).ToString()
            .Should().BeEmpty();
        then.Should().Be(1, "the delegate must not be invoked when the value is not null");

        item = null;
        item.IfNull((Func<Content>)null).ToString()
            .Should().BeEmpty();
    }

    [Test]
    public void IfNull_lazy_otherwise()
    {
        int then = 0, otherwise = 0;
        int? item = null;

        item.IfNull(() => { then++; return div("null"); }, x => { otherwise++; return div(x); }).ToString()
            .Should().Be("<div>null</div>");
        then.Should().Be(1);
        otherwise.Should().Be(0);

        item = 1;
        item.IfNull(() => { then++; return div("null"); }, x => { otherwise++; return div(x); }).ToString()
            .Should().Be("<div>1</div>");
        then.Should().Be(1, "only the branch that is taken is invoked");
        otherwise.Should().Be(1);

        item.IfNull(() => div("null"), null).ToString()
            .Should().BeEmpty();
    }

    [Test]
    public void IfNotNull_lazy_otherwise()
    {
        var otherwise = 0;
        int? item = null;

        item.IfNotNull(x => div(x), () => { otherwise++; return div("null"); }).ToString()
            .Should().Be("<div>null</div>");
        otherwise.Should().Be(1);

        item = 1;
        item.IfNotNull(x => div(x), () => { otherwise++; return div("null"); }).ToString()
            .Should().Be("<div>1</div>");
        otherwise.Should().Be(1, "the fallback must not be invoked when the value is not null");

        item.IfNotNull(null, () => div("null")).ToString()
            .Should().BeEmpty();
    }

    [Test]
    public void IfNullOrEmpty_lazy()
    {
        var then = 0;

        ((string)null).IfNullOrEmpty(() => { then++; return div("null"); }).ToString()
            .Should().Be("<div>null</div>");
        "".IfNullOrEmpty(() => { then++; return div("null"); }).ToString()
            .Should().Be("<div>null</div>");
        then.Should().Be(2);

        "foo".IfNullOrEmpty(() => { then++; return div("null"); }).ToString()
            .Should().BeEmpty();
        then.Should().Be(2, "the delegate must not be invoked when the value is not empty");

        "".IfNullOrEmpty((Func<Content>)null).ToString()
            .Should().BeEmpty();
    }

    [Test]
    public void IfNullOrEmpty_lazy_otherwise()
    {
        int then = 0, otherwise = 0;

        ((string)null).IfNullOrEmpty(() => { then++; return div("null"); }, x => { otherwise++; return div(x); }).ToString()
            .Should().Be("<div>null</div>");
        then.Should().Be(1);
        otherwise.Should().Be(0);

        "foo".IfNullOrEmpty(() => { then++; return div("null"); }, x => { otherwise++; return div(x); }).ToString()
            .Should().Be("<div>foo</div>");
        then.Should().Be(1, "only the branch that is taken is invoked");
        otherwise.Should().Be(1);

        "foo".IfNullOrEmpty(() => div("null"), null).ToString()
            .Should().BeEmpty();
    }

    [Test]
    public void IfNotNullOrEmpty_lazy_otherwise()
    {
        var otherwise = 0;

        ((string)null).IfNotNullOrEmpty(x => div(x), () => { otherwise++; return div("null"); }).ToString()
            .Should().Be("<div>null</div>");
        otherwise.Should().Be(1);

        "foo".IfNotNullOrEmpty(x => div(x), () => { otherwise++; return div("null"); }).ToString()
            .Should().Be("<div>foo</div>");
        otherwise.Should().Be(1, "the fallback must not be invoked when the value is not empty");

        "foo".IfNotNullOrEmpty(null, () => div("null")).ToString()
            .Should().BeEmpty();
    }

    [Test]
    public void IfEmpty_lazy()
    {
        var then = 0;

        Enumerable.Empty<int>().IfEmpty(() => { then++; return div("empty"); }).ToString()
            .Should().Be("<div>empty</div>");
        ((IEnumerable<int>)null).IfEmpty(() => { then++; return div("empty"); }).ToString()
            .Should().Be("<div>empty</div>");
        then.Should().Be(2);

        new[] { 1 }.IfEmpty(() => { then++; return div("empty"); }).ToString()
            .Should().BeEmpty();
        then.Should().Be(2, "the delegate must not be invoked when the sequence is not empty");

        Enumerable.Empty<int>().IfEmpty((Func<Content>)null).ToString()
            .Should().BeEmpty();
    }

    [Test]
    public void IfEmpty_lazy_otherwise()
    {
        int then = 0, otherwise = 0;

        Enumerable.Empty<int>().IfEmpty(() => { then++; return div("empty"); }, x => { otherwise++; return div(x.Count()); }).ToString()
            .Should().Be("<div>empty</div>");
        then.Should().Be(1);
        otherwise.Should().Be(0);

        new[] { 1, 2 }.IfEmpty(() => { then++; return div("empty"); }, x => { otherwise++; return div(x.Count()); }).ToString()
            .Should().Be("<div>2</div>");
        then.Should().Be(1, "only the branch that is taken is invoked");
        otherwise.Should().Be(1);

        new[] { 1 }.IfEmpty(() => div("empty"), null).ToString()
            .Should().BeEmpty();
    }

    [Test]
    public void IfNotEmpty_lazy_otherwise()
    {
        var otherwise = 0;

        Enumerable.Empty<int>().IfNotEmpty(x => div(x.Count()), () => { otherwise++; return div("empty"); }).ToString()
            .Should().Be("<div>empty</div>");
        otherwise.Should().Be(1);

        new[] { 1, 2 }.IfNotEmpty(x => div(x.Count()), () => { otherwise++; return div("empty"); }).ToString()
            .Should().Be("<div>2</div>");
        otherwise.Should().Be(1, "the fallback must not be invoked when the sequence is not empty");

        new[] { 1 }.IfNotEmpty(null, () => div("empty")).ToString()
            .Should().BeEmpty();
    }

    [Test]
    public void IfHasValue_lazy_otherwise()
    {
        var otherwise = 0;
        int? item = null;

        item.IfHasValue(x => div(x), () => { otherwise++; return div("null"); }).ToString()
            .Should().Be("<div>null</div>");
        otherwise.Should().Be(1);

        item = 1;
        item.IfHasValue(x => div(x), () => { otherwise++; return div("null"); }).ToString()
            .Should().Be("<div>1</div>");
        otherwise.Should().Be(1, "the fallback must not be invoked when the value has a value");

        item.IfHasValue(null, () => div("null")).ToString()
            .Should().BeEmpty();
    }
}
