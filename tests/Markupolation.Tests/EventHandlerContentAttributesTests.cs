using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests
{
    public class EventHandlerContentAttributesTests
    {
        [Test]
        public void Attribute()
        {
            var result = onload("console.log('onload');");
            result.ToString().Should().Be("onload=\"console.log('onload');\"");
        }
    }
}
