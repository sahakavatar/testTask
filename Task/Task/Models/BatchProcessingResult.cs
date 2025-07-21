using Task.Models.Responses;

namespace Task.Models
{
    public class BatchProcessingResult
    {
        public List<ImageProcessingResult> Results { get; set; } = new();
    }
}
