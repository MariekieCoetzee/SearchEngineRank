using System;

namespace SearchEngineRank.Models
{
    public class SearchResult
    {
        public SearchResult()
        {

        }
        public string Name { get; set; }
        public string DomainName { get; set; }
        public string Url { get; set; }
        public int Position { get; set; }
    }

    [Serializable]
    public class SearchEngineNotFoundException : Exception
    {
        public SearchEngineNotFoundException() { }
        public SearchEngineNotFoundException(string message) : base(message) { }
        public SearchEngineNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
    [Serializable]
    public class BaseDomainNotFoundException : Exception
    {
        public BaseDomainNotFoundException() { }
        public BaseDomainNotFoundException(string message) : base(message) { }
        public BaseDomainNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
    [Serializable]
    public class ConstructURLException : Exception
    {
        public ConstructURLException() { }
        public ConstructURLException(string message) : base(message) { }
        public ConstructURLException(string message, Exception inner) : base(message, inner) { }
    }
    [Serializable]
    public class ParsePageContentException : Exception
    {
        public ParsePageContentException() { }
        public ParsePageContentException(string message) : base(message) { }
        public ParsePageContentException(string message, Exception inner) : base(message, inner) { }
    }
}
