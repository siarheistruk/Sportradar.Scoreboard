using NUnit.Framework;
using Sportradar.Scoreboard.Data.Models;
using Sportradar.Scoreboard.Data.Repository;

namespace Sportradar.Scoreboard.Data.Tests.Repository
{
    internal class MatchRepositoryTests
    {
        [Test]
        public void Add_Always_ItemIsAdded()
        {
            var repository = new MatchRepository();
            var item = new MatchDto();

            repository.Add(item);

            Assert.That(repository.GetAll().First(), Is.EqualTo(item));
        }

        [Test]
        public void Add_Always_NewMatchIdIsReturned()
        {
            var repository = new MatchRepository();
            repository.Add(new MatchDto());
            repository.Add(new MatchDto());

            repository.Add(new MatchDto());

            Assert.That(repository.GetAll().First().Id, Is.EqualTo(2));
        }

        [Test]
        public void Delete_MatchWithPassedIdExistInRepository_MatchDeleted()
        {
            var repository = new MatchRepository();
            repository.Add(new MatchDto());
            repository.Add(new MatchDto());
            repository.Add(new MatchDto());

            repository.Delete(2);

            Assert.That(repository.GetAll().Count, Is.EqualTo(2));
            Assert.That(repository.GetAll().Any(x => x.Id == 2), Is.EqualTo(false));
        }

        [Test]
        public void Delete_MatchWithPassedIdDoesNotExistInRepository_NothingIsDeleted()
        {
            var repository = new MatchRepository();
            repository.Add(new MatchDto());
            repository.Add(new MatchDto());
            repository.Add(new MatchDto());

            repository.Delete(3);

            Assert.That(repository.GetAll().Count, Is.EqualTo(3));
            Assert.That(repository.GetAll().Any(x => x.Id == 2), Is.EqualTo(true));
        }

        [Test]
        public void Update_MatchWithPassedIdExistInRepository_MatchIsUpdated()
        {
            var repository = new MatchRepository();
            repository.Add(new MatchDto());
            var updateDto = new UpdateMatchDto();

            repository.Update(updateDto);

            Assert.That(repository.GetAll().FirstOrDefault(x => x.Id == updateDto.Id).HomeTeamScore, Is.EqualTo(updateDto.HomeTeamScore));
            Assert.That(repository.GetAll().FirstOrDefault(x => x.Id == updateDto.Id).GuestTeamScore, Is.EqualTo(updateDto.GuestTeamScore));
        }

        [Test]
        public void Update_MatchWithPassedIdDoesNotExistInRepository_NothingIsUpdated()
        {
            var repository = new MatchRepository();
            repository.Add(new MatchDto());
            var updateDto = new UpdateMatchDto();
            
            repository.Update(updateDto);
            
            Assert.That(repository.GetAll().FirstOrDefault(x => x.Id == updateDto.Id), Is.Null);
        }

        [Test]
        public void GetAll_Always_ReturnsCorrectArray()
        {
            var repository = new MatchRepository();
            var firstModel = new MatchDto();
            var secondModel = new MatchDto();
            repository.Add(firstModel);
            repository.Add(secondModel);
            repository.Add(new MatchDto());
            repository.Delete(2);

            var result = repository.GetAll();

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(firstModel));
            Assert.That(result[1], Is.EqualTo(firstModel));
        }
    }
}
