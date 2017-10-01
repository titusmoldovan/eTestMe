using System.Collections.Generic;
using System.Linq;

namespace eTestMe.Core.Domain.Model
{
    public class Test
    {
        double _result = -1;
        
        public IList<Question> Questions { get; private set; }

        public Test()
        {
            Questions = new List<Question>();
        }

        public void AddQuestion (Question question)
        {
            Questions.Add(question);
        }

        public double Result 
        { 
            get 
            {
                if(_result <0){
                    _result = ComputeResult();
                }

				return _result;
            }
            set 
            {
                _result = value;    
            }
        }

        double ComputeResult()
        {
            double result = 0;

            foreach(var q in Questions){
                result += q.CorrectnessPercentage;
            }

            return result/Questions.Count();
        }
    }
}
