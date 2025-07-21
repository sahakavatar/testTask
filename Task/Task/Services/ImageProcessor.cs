using Microsoft.Extensions.Logging;
using Task.Configs;
using Task.Models;
using Task.Models.Requests;
using Task.Models.Responses;
using Task.Plugins;

namespace Task.Services
{
    public class ImageProcessor
    {
        private readonly ILogger<ImageProcessor> _logger;

        public ImageProcessor(ILogger<ImageProcessor> logger)
        {
            _logger = logger;
        }

        public BatchProcessingResult Process(ImageRequest request)
        {
            var batchResult = new BatchProcessingResult();

            foreach (var image in request.Images)
            {
                var result = new ImageProcessingResult { ImageId = image.ImageId };

                foreach (var effect in image.Effects)
                {
                    var plugin = PluginRegistry.GetPlugin(effect.Plugin);

                    if (plugin == null)
                    {
                        string msg = $"Error: Plugin '{effect.Plugin}' not found.";
                        _logger.LogWarning(msg);
                        result.Messages.Add(msg);
                        continue;
                    }

                    try
                    {
                        plugin.Apply(image.ImageId, effect.Parameters);
                        result.Messages.Add($"Applied '{effect.Plugin}' plugin.");
                    }
                    catch (Exception ex)
                    {
                        string msg = $"Error: Plugin '{effect.Plugin}' failed - {ex.Message}";
                        _logger.LogError(ex, msg);
                        result.Messages.Add(msg);
                    }
                }

                batchResult.Results.Add(result);
            }

            return batchResult;
        }
    }
}
