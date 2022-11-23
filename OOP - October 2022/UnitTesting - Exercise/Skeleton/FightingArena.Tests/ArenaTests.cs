namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    [TestFixture]
    public class ArenaTests
    {
        private Warrior warrior;
        private Warrior warrior2;
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Kaloyan", 50, 100);
            warrior2 = new Warrior("Bobi", 50, 30);
            arena = new Arena();
        }

        [Test]
        public void EnrollWorks()
        {
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            Assert.AreEqual(2,arena.Count);
        }

        [Test]
        public void EnrollThrowsAnExWhenNameDuplicates()
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => { arena.Enroll(warrior); });
        }

        [Test]
        public void FightThrowExWhenAttackerOrDeffenderDoesNotExist()
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => { arena.Fight("Kaloyan", "Bobi"); });
            Assert.Throws<InvalidOperationException>(() => { arena.Fight("Bobi", "Kaloyan"); });
        }

        [Test]
        public void FightWorks()
        {

            Warrior pesho = new Warrior("Pesho", 120, 40);
            Warrior d = new Warrior("d", 40, 40);

            arena.Enroll(pesho);
            arena.Enroll(d);

            int expectedMyHP = pesho.HP - d.Damage;

            arena.Fight("Pesho", "d");

           

            Assert.AreEqual(expectedMyHP, pesho.HP);

            Assert.AreEqual(0, d.HP);
        }
    }
}
