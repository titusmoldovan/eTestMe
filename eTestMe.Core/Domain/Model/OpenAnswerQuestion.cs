namespace eTestMe.Core.Domain.Model
{
    public class OpenAnswerQuestion : Question
    {
        double _givenPercentage = -1;
        public double GivenPercentage { get => _givenPercentage; set => _givenPercentage = value; }
       
        public override double CorrectnessPercentage => GivenPercentage * TestPercentage;

        public string Answer { get; set; }
    }
}
