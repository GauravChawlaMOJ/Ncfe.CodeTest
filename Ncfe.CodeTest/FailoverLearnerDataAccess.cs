namespace Ncfe.CodeTest
{
    public class FailoverLearnerDataAccess
    {
        public static LearnerResponse GetLearnerById(int id)
        {
            // retrieve learner from database
            LearnerResponse learnerResponse = new LearnerResponse(id);
            return learnerResponse;
        }
    }
}
