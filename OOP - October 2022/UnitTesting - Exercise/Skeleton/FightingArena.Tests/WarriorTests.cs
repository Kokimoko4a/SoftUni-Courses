namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private Warrior warrior2;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Kaloyan", 50 ,100);
            warrior2 = new Warrior("Bobi", 50 ,30);
        }

        [Test]
        public void ConstructorWorks()
        {
            Warrior warrior = new Warrior("Koki",1,1);
            Assert.AreEqual(1, warrior.HP);
            Assert.AreEqual(1, warrior.Damage);
            Assert.AreEqual("Koki", warrior.Name);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NameSetterThrowsExWhenNameIsNullOrWS(string input)
        {
            Assert.Throws<ArgumentException>(() => { Warrior d = new Warrior(input, 1, 1); });
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void DamageSetterThrowsExWhenNameIsNullOrWS(int input)
        {
            Assert.Throws<ArgumentException>(() => { Warrior d = new Warrior("d", input, 1); });
        }


        [TestCase(-1)]
        public void HPSetterThrowsExWhenNameIsNullOrWS(int input)
        {
            Assert.Throws<ArgumentException>(() => { Warrior d = new Warrior("d", 1, input); });
        }

        [Test]
        public void WhenHPIs30OrBelowThrowEx()
        {
            Warrior pesho = new Warrior("Pesho", 12, 30);
            Warrior d = new Warrior("d", 12, 12);

            Assert.Throws<InvalidOperationException>(() => { pesho.Attack(warrior); });   
            Assert.Throws<InvalidOperationException>(() => { d.Attack(warrior); });   
        }

        [Test]
        public void WhenOpponentHPIs30OrBelowThrowEx()
        {
            Warrior pesho = new Warrior("Pesho", 12, 30);
            Warrior d = new Warrior("d", 12, 12);

            Assert.Throws<InvalidOperationException>(() => { warrior.Attack(pesho); });
            Assert.Throws<InvalidOperationException>(() => { warrior.Attack(d); });
        }


        [Test]
        public void WhenMyHPIsSmallerThanOpponentDamage()
        {
            Warrior pesho = new Warrior("Pesho", 120, 40);
            Warrior d = new Warrior("d", 40,40);

            Assert.Throws<InvalidOperationException>(() => { d.Attack(pesho); });;
        }


        [Test]
        public void AttackWorks()
        {
            Warrior pesho = new Warrior("Pesho", 120, 40);
            Warrior d = new Warrior("d", 40, 40);
            int expectedMyHP = pesho.HP - d.Damage;

            pesho.Attack(d);
            Assert.AreEqual(expectedMyHP, pesho.HP);

            Assert.AreEqual(0, d.HP);

            Warrior koki = new Warrior("koki", 120, 40);
            Warrior bobi = new Warrior("bobi", 40, 400);


            int expected = bobi.HP - koki.Damage;
            koki.Attack(bobi);

            Assert.AreEqual(expected, bobi.HP);

        }
    

        
    }
}