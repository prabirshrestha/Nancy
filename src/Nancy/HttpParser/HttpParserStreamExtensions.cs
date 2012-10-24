namespace Nancy.HttpParser
{
    using System;
    using System.IO;

    public static class HttpParserStreamExtensions
    {
        public static Request ReadAsRequest(this Stream stream, string scheme = "http")
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (string.IsNullOrWhiteSpace(scheme))
            {
                throw new ArgumentNullException("scheme");
            }

            throw new NotImplementedException();
        }
    }
}