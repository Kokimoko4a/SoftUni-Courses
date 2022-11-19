using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe = new Axe(2, 2);
        private Dummy dummy = new Dummy(3, 3);



        [Test]
        public void IsConstructorWorking()
        {

            int attack = 2;
            int durability = 2;
            Axe axe3 = new Axe(2, 2);

            Assert.AreEqual(attack, axe3.AttackPoints);
            Assert.AreEqual(durability, axe3.DurabilityPoints);
        }

        [Test]
        public void Test1()
        {
            axe.Attack(dummy);
            Assert.AreEqual(1, axe.DurabilityPoints);
        }

        [Test]
        public void Test2()
        {
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => { axe.Attack(dummy);});
            // Assert.That<InvalidOperationException>(() => { dummy.TakeAttack(axe.AttackPoints);});
        }

        [Test]
        public void Test3()
        {
            Axe axe2 = new Axe(2, -1);

            Assert.Throws<InvalidOperationException>(() => { axe2.Attack(dummy); });
        }

    }
}