namespace Task.Models.Requests
{
    public class ImageRequest
    {
        public List<ImageTask> Images { get; set; } = new();
    }

    public class ImageTask
    {
        public string ImageId { get; set; } = string.Empty;

        public List<EffectParameter> Effects { get; set; } = new();
    }

}
