using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ncfe.CodeTest
{
    public class LearnerService
    {
        public Learner GetLearner(int learnerId, bool isLearnerArchived)
        {
            var archivedDataService = new ArchivedDataService();
            LearnerResponse learnerResponse = GetLearnerResponse(learnerId);

            if (isLearnerArchived || learnerResponse.IsArchived)
            {
                return archivedDataService.GetArchivedLearner(learnerId);
            }
                    return learnerResponse.Learner;
        }

        private bool isFailOverModeEnabled()
        {
            var failoverRespository = new FailoverRepository();
            var failoverEntries = failoverRespository.GetFailOverEntries();
            var failedRequests = failoverEntries.FindAll(x => x.DateTime > DateTime.Now.AddMinutes(-10)).Count();
            AppSettingsReader reader = new AppSettingsReader();
            bool IsFailoverModeEnabled = (bool)reader.GetValue("IsFailoverModeEnabled", typeof(bool));
            int MaxFailedRequests = (int)reader.GetValue("MaxFailedRequests", typeof(int));
            if (IsFailoverModeEnabled && failedRequests > MaxFailedRequests)//100
            {
                return true;
            }
            return false;
        }

        private LearnerResponse GetLearnerResponse(int learnerId)
        {
            LearnerResponse learnerResponse;
            if (isFailOverModeEnabled())
            {
                learnerResponse = FailoverLearnerDataAccess.GetLearnerById(learnerId);
            }
            else
            {
                var dataAccess = new LearnerDataAccess();
                learnerResponse = dataAccess.LoadLearner(learnerId);
            }
            return learnerResponse;
        }

    }
}
