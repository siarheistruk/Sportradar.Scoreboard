using Sportradar.Scoreboard.Factories;

namespace Sportradar.Scoreboard.Tests.Factories
{
    internal class MatchFactoryTests
    {
        [Test]
        public void CreateMatch_Always_ReturnsNewMatch()
        {
            var matchFactory = new MatchFactory();

            var actual = matchFactory.CreateMatch("Team1", "Team2");

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.HomeTeamName, Is.EqualTo("Team1"));
            Assert.That(actual.GuestTeamName, Is.EqualTo("Team2"));
        }
    }
}
