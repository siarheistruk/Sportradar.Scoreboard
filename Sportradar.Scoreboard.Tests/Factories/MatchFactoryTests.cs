using Sportradar.Scoreboard.Factories;

namespace Sportradar.Scoreboard.Tests.Factories
{
    internal class MatchFactoryTests
    {
        [Test]
        public void CreateMatch_InputDataNotNullOrEmpty_ReturnsNewMatch()
        {
            var matchFactory = new MatchFactory();

            var actual = matchFactory.CreateMatch("Team1", "Team2");

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.HomeTeamName, Is.EqualTo("Team1"));
            Assert.That(actual.GuestTeamName, Is.EqualTo("Team2"));
        }

        [Test]
        public void CreateMatch_InputDataIsNull_ReturnsNull()
        {
            var matchFactory = new MatchFactory();

            var actual = matchFactory.CreateMatch(null, "Team2");

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void CreateMatch_InputDataIsEmpty_ReturnsNull()
        {
            var matchFactory = new MatchFactory();

            var actual = matchFactory.CreateMatch("", "Team2");

            Assert.That(actual, Is.Null);
        }
    }
}
