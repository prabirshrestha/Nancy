namespace Nancy.Tests.Unit.HttpParser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
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

        [Fact]
        public void RelativeUrlGetFixture()
        {
            // given
            var rawRequestStream = new MemoryStream(Encoding.UTF8.GetBytes(@"GET / HTTP/1.1
User-Agent: Fiddler
Host: nancyfx.org

"));

            // when
            var result = rawRequestStream.ReadAsRequest();

            // then
            result.Method.ShouldEqual("GET");

            result.Url.Scheme.ShouldEqual("http");
            result.Url.Path.ShouldEqual("/");

            result.Headers.ShouldHaveCount(2);

            result.Body.Length.ShouldEqual(0L);
        }

        [Fact]
        public void RelativeUrlPostFixture()
        {
            // given
            var rawRequestStream = new MemoryStream(Encoding.UTF8.GetBytes(@"POST / HTTP/1.1
User-Agent: Fiddler
Host: nancyfx.org
Content-Length: 4

asdf"));

            // when
            var result = rawRequestStream.ReadAsRequest();

            // then
            result.Method.ShouldEqual("POST");

            result.Url.Scheme.ShouldEqual("http");
            result.Url.Path.ShouldEqual("/");

            result.Headers.ShouldHaveCount(3);

            using (var reader = new StreamReader(result.Body))
            {
                reader.ReadToEnd().ShouldEqual("asdf");
            }
        }
    }
}