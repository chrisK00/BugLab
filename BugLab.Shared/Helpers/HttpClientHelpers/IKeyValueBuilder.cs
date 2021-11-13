namespace BugLab.Shared.Helpers.HttpClientHelpers
{
    public interface IKeyValueBuilder
    {
        IKeyValueBuilder WithParam(string key, string value);
        IKeyValueBuilder WithParam<T>(string key, T value);
        string Build();
    }
}
