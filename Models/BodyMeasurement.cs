namespace BodyMeasurementsTracker.Models
{
    public class BodyMeasurement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Weight { get; set; }
        public float? Waist { get; set; }
        public float? BodyFat { get; set; }
        public float? Neck { get; set; }
        public float? Shoulder { get; set; }
        public float? Chest { get; set; }
        public float? Biceps { get; set; }
        public float? Forearm { get; set; }
        public float? Abdomen { get; set; }
        public float? Hips { get; set; }
        public float? Thighs { get; set; }
        public float? Calf { get; set; }
        public string? ProgressPicture { get; set; }
    }
}
