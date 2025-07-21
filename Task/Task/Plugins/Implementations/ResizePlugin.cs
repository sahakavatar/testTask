using Task.Plugins.Interfaces;

namespace Task.Plugins.Implementations
{
    public class ResizePlugin : IImagePlugin
    {
        public string Name => "resize";

        public void Apply(string imageId, Dictionary<string, object>? parameters = null)
        {
            var size = parameters?["size"] ?? "default";
            Console.WriteLine($"[ResizePlugin] Resizing image {imageId} to {size}px");
        }
    }
}
