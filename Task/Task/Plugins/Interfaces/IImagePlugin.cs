namespace Task.Plugins.Interfaces
{
    public interface IImagePlugin
    {
        string Name { get; }

        void Apply(string imageId, Dictionary<string, object>? parameters = null);
    }
}
