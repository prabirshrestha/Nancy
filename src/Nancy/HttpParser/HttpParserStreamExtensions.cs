namespace Nancy.HttpParser
{
    using System;
    using System.IO;

    public static class HttpParserStreamExtensions
    {
        public static Request ReadAsRequest(this Stream stream, string scheme = "http")
        {
            throw new NotImplementedException();
        }
    }
}