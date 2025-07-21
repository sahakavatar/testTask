using Task.Plugins.Interfaces;

namespace Task.Plugins.Implementations
{
    public class BlurPlugin : IImagePlugin
    {
        public string Name => "blur";

        public void Apply(string imageId, Dictionary<string, object>? parameters = null)
        {
            object intensity = "default";

            if (parameters != null && parameters.TryGetValue("intensity", out var value))
            {
                intensity = value;
            }

            Console.WriteLine($"[BlurPlugin] Applying blur to image {imageId} with intensity {intensity}");
        }
    }
}
