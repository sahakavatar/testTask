namespace Task.Models.Responses
{
    public class ImageProcessingResult
    {
        public string ImageId { get; set; } = string.Empty;

        public List<string> Messages { get; set; } = new();

        public bool Success => Messages.All(m => !m.StartsWith("Error:"));
    }

}
