using Task.Plugins.Implementations;
using Task.Plugins.Interfaces;

namespace Task.Configs
{
    public class PluginRegistry
    {
        private static readonly Dictionary<string, IImagePlugin> _plugins = new();
        public static IEnumerable<string> GetAvailablePlugins() => _plugins.Keys;

        static PluginRegistry()
        {
            Register(new ResizePlugin());
            Register(new BlurPlugin());
        }

        private static void Register(IImagePlugin plugin)
        {
            _plugins[plugin.Name] = plugin;
        }

        public static IImagePlugin? GetPlugin(string name)
        {
            _plugins.TryGetValue(name, out var plugin);

            return plugin;
        }

    
    }
}
