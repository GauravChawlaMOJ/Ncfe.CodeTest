using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ncfe.CodeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ncfe.CodeTest.Tests
{
    [TestClass()]
    public class LearnerServiceTests
    {
        [DataTestMethod]
        [DataRow(12, true)]
        [DataRow(1, false)]
        public void GetLearnerTest(int learnerId, bool isLearnerArchived)
        {
            LearnerService learnerService = new LearnerService();
            Learner result = learnerService.GetLearner(learnerId, isLearnerArchived);
            Assert.AreEqual(learnerId, result.Id);
        }
    }
}