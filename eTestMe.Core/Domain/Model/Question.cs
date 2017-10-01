namespace eTestMe.Core.Domain.Model
{
    public abstract class Question
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public double TestPercentage { get; set; } 

        public abstract double CorrectnessPercentage { get; }
    }
}
