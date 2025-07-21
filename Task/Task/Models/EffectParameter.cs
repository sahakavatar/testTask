namespace Task.Models
{

    public class EffectParameter
    {
        public string Plugin { get; set; } = string.Empty;

        public Dictionary<string, object>? Parameters { get; set; }
    }
}
