using System;
using System.Collections.Generic;

namespace eTestMe.Core.Domain.Model
{
    public class MultipleAnswerQuestion : Question
    {
        public Dictionary<string, bool> CorrectAnswer;
        public Dictionary<string, bool> Answer;

        public override double CorrectnessPercentage => ComputePercentage();
        public bool AllowPartialAnswer { get; set; }

        double ComputePercentage()
        {
			var enumerator = CorrectAnswer.GetEnumerator();

			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Value != Answer[enumerator.Current.Key])
				{
                    return 0;
				}
			}

            return TestPercentage;
        }
    }
}
