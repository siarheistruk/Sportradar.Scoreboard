using Sportradar.Scoreboard.Data.Repository;
using Sportradar.Scoreboard.Factories;
using System.Runtime.InteropServices;

namespace Sportradar.Scoreboard.Tests
{
    internal class MatchOperatorTests
    {
        [Test]
        public void StartMatch_InputParametersNotNullOrEmpty_StartsNewMatchAndReturnsMatchId()
        {
            var matchRepository = new MatchRepository();
            var matchOperator = new MatchOperator(matchRepository, new MatchFactory());

            var actual = matchOperator.StartMatch("Team1", "Team2");

            Assert.That(actual, Is.EqualTo(0));
            Assert.That(matchRepository.GetAll().Count, Is.EqualTo(1));
        }

        [Test]
        public void StartMatch_InputParametersNullOrEmpty_DoNotStartNewRoundAndReturnsInvalidId()
        {
            var matchRepository = new MatchRepository();
            var matchOperator = new MatchOperator(matchRepository, new MatchFactory());

            var actual = matchOperator.StartMatch("", null);

            Assert.That(actual, Is.EqualTo(-1));
            Assert.That(matchRepository.GetAll().Count, Is.EqualTo(0));
        }

        [Test]
        public void UpdateMatch_MatchExists_UpdatesMatch()
        {
            var matchId = 1;
            var matchRepository = new MatchRepository();
            var matchOperator = new MatchOperator(matchRepository, new MatchFactory());
            matchOperator.StartMatch("Team1", "Team2");
            matchOperator.StartMatch("Team2", "Team3");
            matchOperator.StartMatch("Team4", "Team5");

            matchOperator.UpdateMatch(matchId, 2, 3);

            Assert.That(matchRepository.GetAll().FirstOrDefault(x => x.Id == matchId)?.HomeTeamScore, Is.EqualTo(2));
            Assert.That(matchRepository.GetAll().FirstOrDefault(x => x.Id == matchId)?.GuestTeamScore, Is.EqualTo(3));
        }

        [Test]
        public void UpdateMatch_MatchDoesNotExists_NothingIsUpdated()
        {
            var matchId = 1;
            var matchRepository = new MatchRepository();
            var matchOperator = new MatchOperator(matchRepository, new MatchFactory());
            matchOperator.StartMatch("Team1", "Team2");
            var previos = matchRepository.GetAll();

            matchOperator.UpdateMatch(matchId, 2, 3);

            Assert.That(matchRepository.GetAll().FirstOrDefault(x => x.Id == matchId), Is.Null);
            CollectionAssert.AreEqual(previos, matchRepository.GetAll());
        }

        [Test]
        public void DeleteMatch_MatchExist_DeletesMatch()
        {
            var matchId = 1;
            var matchRepository = new MatchRepository();
            var matchOperator = new MatchOperator(matchRepository, new MatchFactory());
            matchOperator.StartMatch("Team1", "Team2");
            matchOperator.StartMatch("Team3", "Team4");

            matchOperator.FinishMatch(matchId);

            Assert.That(matchRepository.GetAll().FirstOrDefault(x => x.Id == matchId), Is.Null);
            Assert.That(matchRepository.GetAll().Count, Is.EqualTo(1));
        }

        [Test]
        public void DeleteMatch_MatchDoesNotExist_NothingIsDeleted()
        {
            var matchId = 1;
            var matchRepository = new MatchRepository();
            var matchOperator = new MatchOperator(matchRepository, new MatchFactory());
            matchOperator.StartMatch("Team1", "Team2");
            var previos = matchRepository.GetAll();

            matchOperator.FinishMatch(matchId);

            CollectionAssert.AreEqual(previos, matchRepository.GetAll());
        }

        [Test]
        public void GetMatchesSummary_Always_ReturnsCorrectMatchesResult()
        {
            var matchRepository = new MatchRepository();
            var matchOperator = new MatchOperator(matchRepository, new MatchFactory());
            matchOperator.StartMatch("Team1", "Team2");
            matchOperator.StartMatch("Team3", "Team4");
            matchOperator.StartMatch("Team5", "Team6");
            matchOperator.StartMatch("Team7", "Team8");
            matchOperator.StartMatch("Team9", "Team10");
            matchOperator.UpdateMatch(0, 4, 4);
            matchOperator.UpdateMatch(1, 1, 1);
            matchOperator.UpdateMatch(2, 2, 0);
            matchOperator.UpdateMatch(3, 3, 3);
            matchOperator.UpdateMatch(4, 5, 3);

            var actual = matchOperator.GetMatchesSummary();

            Assert.That(actual[0].Id, Is.EqualTo(4));
            Assert.That(actual[0].Id, Is.EqualTo(0));
            Assert.That(actual[0].Id, Is.EqualTo(3));
            Assert.That(actual[0].Id, Is.EqualTo(2));
            Assert.That(actual[0].Id, Is.EqualTo(1));
        }
    }
}
