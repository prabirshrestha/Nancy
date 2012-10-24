namespace Nancy.Tests.Unit.HttpParser
{
    using System;
    using System.IO;
    using Nancy.HttpParser;
    using Xunit;
    using Xunit.Extensions;

    public class ReadAsRequestFixture
    {
        [Fact]
        public void When_stream_is_null_throws_argument_null_exception()
        {
            // given
            Stream stream = null;

            // when/then
            var exception = Assert.Throws<ArgumentNullException>(() => stream.ReadAsRequest());
            exception.ParamName.ShouldEqual("stream");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void When_scheme_is_empty_or_whitespace_throws_argument_null_exception(string scheme)
        {
            // Given
            Stream stream = new MemoryStream();

            // when/then
            var exception = Assert.Throws<ArgumentNullException>(() => stream.ReadAsRequest(scheme: scheme));
            exception.ParamName.ShouldEqual("scheme");
        }
    }
}