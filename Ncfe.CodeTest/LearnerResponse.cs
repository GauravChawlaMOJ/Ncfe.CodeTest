namespace Ncfe.CodeTest
{
    public class LearnerResponse
    {
        public LearnerResponse(int learnerId)
        {
            Learner = new Learner(learnerId);
        }
        public bool IsArchived { get; set; }

        public Learner Learner { get; set; }
        
    }
}
