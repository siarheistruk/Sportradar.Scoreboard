using Moq;
using Sportradar.Scoreboard.Data.Dto;
using Sportradar.Scoreboard.Data.Repository;
using Sportradar.Scoreboard.Factories;
using Sportradar.Scoreboard.Formatters;
using System.Collections.Immutable;

namespace Sportradar.Scoreboard.Tests
{
    internal class MatchOperatorTests
    {
        [Test]
        public void StartMatch_MatchIsCreated_MatchIsAddedToRepository()
        {
            var matchFactoryMock = new Mock<IMatchFactory>();
            var matchRepositoryMock = new Mock<IMatchRepository>();
            matchFactoryMock
                .Setup(x => x.CreateMatch(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new Models.Match
                {
                    Id = 1,
                });
            var matchOperator = new MatchOperator(matchRepositoryMock.Object, matchFactoryMock.Object, new MatchesSummaryFormatter());

            var actual = matchOperator.StartMatch("Team1", "Team2");

            matchFactoryMock.Verify(x => x.CreateMatch(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            matchRepositoryMock.Verify(x => x.Add(It.IsAny<MatchDto>()), Times.Once);
        }

        [Test]
        public void StartMatch_MatchIsNotCreated_MatchIsNotAddedToRepository()
        {
            var matchFactoryMock = new Mock<IMatchFactory>();
            var matchRepositoryMock = new Mock<IMatchRepository>();
            var matchOperator = new MatchOperator(matchRepositoryMock.Object, matchFactoryMock.Object, new MatchesSummaryFormatter());

            var actual = matchOperator.StartMatch("", null);


            matchFactoryMock.Verify(x => x.CreateMatch(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            matchRepositoryMock.Verify(x => x.Add(It.IsAny<MatchDto>()), Times.Never);
        }

        [Test]
        public void UpdateMatch_Always_CallsUpdateInRepository()
        {
            var matchRepositoryMock = new Mock<IMatchRepository>();
            var matchOperator = new MatchOperator(matchRepositoryMock.Object, new MatchFactory(), new MatchesSummaryFormatter());

            matchOperator.UpdateMatch(0, 2, 3);

            matchRepositoryMock.Verify(x => x.Update(It.IsAny<UpdateMatchDto>()), Times.Once);
        }

        [Test]
        public void FinishMatch_Always_CallsDeleteMatchFromRepository()
        {
            var matchRepositoryMock = new Mock<IMatchRepository>();
            var matchOperator = new MatchOperator(matchRepositoryMock.Object, new MatchFactory(), new MatchesSummaryFormatter());

            matchOperator.FinishMatch(0);

            matchRepositoryMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetMatchesSummary_Always_CallsGetFromRepositoryAndFormatsMatch()
        {
            var matchRepositoryMock = new Mock<IMatchRepository>();
            matchRepositoryMock
                .Setup(x => x.GetAll())
                .Returns(new List<MatchDto>());
            var matchesSummaryFormatterMock = new Mock<IMatchesSummaryFormatter>();
            var matchOperator = new MatchOperator(matchRepositoryMock.Object, new MatchFactory(), matchesSummaryFormatterMock.Object);

            var actual = matchOperator.GetMatchesSummary();

            matchRepositoryMock.Verify(x => x.GetAll(), Times.Once);
            matchesSummaryFormatterMock.Verify(x => x.FormatMatches(It.IsAny<IEnumerable<Models.Match>>()), Times.Once);
        }
    }
}
