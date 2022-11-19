using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe = new Axe(1, 100);
        private Dummy dummy = new Dummy(10, 15);

        [SetUp]

        public void SetUp()
        {
            axe = new Axe(1, 100);
            dummy = new Dummy(10, 15);
        }

        [Test]
        public void DummyLossesHealth()
        {
            int currHealth = dummy.Health;
            dummy.TakeAttack(axe.AttackPoints);
            Assert.AreEqual(currHealth - axe.AttackPoints, dummy.Health);
        }

        [Test]
        public void DeadDummyException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 11; i++)
                {
                    dummy.TakeAttack(axe.AttackPoints);
                };
            });
        }

        [Test]
        public void CanDeadDummyGiveXP()
        {

            for (int i = 0; i < 10; i++)
            {
                dummy.TakeAttack(axe.AttackPoints);
            }

            int xp = dummy.GiveExperience();


            Assert.AreEqual(15, xp);
        }

        [Test]
        public void AliveCannotGiveXP()
        {
            Assert.Throws<InvalidOperationException>(() => { dummy.GiveExperience(); });
        }
    }
}