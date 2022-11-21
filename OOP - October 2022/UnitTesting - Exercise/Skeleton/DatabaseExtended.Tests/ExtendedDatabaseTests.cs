namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ExtendedDatabaseTests
    {


        [Test]
        public void DoesPersonConstructorWorks()
        {
            Person person = new Person(123, "koki");

            Assert.AreEqual(123, person.Id);
            Assert.AreEqual("koki", person.UserName);
        }


        [Test]
        public void DoesDBConstructorWorks()
        {
            Person[] people = new Person[16];
            Person person1 = new Person(123, "Koki");
            Person person2 = new Person(1233, "oki");
            Person person3 = new Person(12333, "ki");
            Person person4 = new Person(1234, "i");
            Person person5 = new Person(1235, "qKoki");
            Person person6 = new Person(1236, "wKoki");
            Person person7 = new Person(1237, "eKoki");
            Person person8 = new Person(1238, "Kroki");
            Person person9 = new Person(1239, "Kotki");
            Person person10 = new Person(12310, "Koyki");
            Person person11 = new Person(12312, "Kokui");
            Person person12 = new Person(12313, "Kokii");
            Person person13 = new Person(12315, "Kokio");
            Person person14 = new Person(12316, "Kokoi");
            Person person15 = new Person(12317, "Kokpi");
            Person person16 = new Person(12318, "Kokik");

            people[0] = person1;
            people[1] = person2;
            people[2] = person3;
            people[3] = person4;
            people[4] = person5;
            people[5] = person6;
            people[6] = person7;
            people[7] = person8;
            people[8] = person9;
            people[9] = person10;
            people[10] = person11;
            people[11] = person12;
            people[12] = person13;
            people[13] = person14;
            people[14] = person15;
            people[15] = person16;
            Database database = new Database(people);
            FieldInfo field = database.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(x => x.Name == "persons");

            Person[] peopleInDataBase = (Person[])field.GetValue(database);

            Assert.AreEqual(people, peopleInDataBase);
        }

        [Test]
        public void DoesAddRangeMethodWorks()
        {
            Person[] people = new Person[16];
            Person person1 = new Person(123, "Koki");
            Person person2 = new Person(1233, "oki");
            Person person3 = new Person(12333, "ki");
            Person person4 = new Person(1234, "i");
            Person person5 = new Person(1235, "qKoki");
            Person person6 = new Person(1236, "wKoki");
            Person person7 = new Person(1237, "eKoki");
            Person person8 = new Person(1238, "Kroki");
            Person person9 = new Person(1239, "Kotki");
            Person person10 = new Person(12310, "Koyki");
            Person person11 = new Person(12312, "Kokui");
            Person person12 = new Person(12313, "Kokii");
            Person person13 = new Person(12315, "Kokio");
            Person person14 = new Person(12316, "Kokoi");
            Person person15 = new Person(12317, "Kokpi");
            Person person16 = new Person(12318, "Kokik");

            people[0] = person1;
            people[1] = person2;
            people[2] = person3;
            people[3] = person4;
            people[4] = person5;
            people[5] = person6;
            people[6] = person7;
            people[7] = person8;
            people[8] = person9;
            people[9] = person10;
            people[10] = person11;
            people[11] = person12;
            people[12] = person13;
            people[13] = person14;
            people[14] = person15;
            people[15] = person16;

            Database database = new Database(people);
            FieldInfo field = database.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(x => x.Name == "persons");
            Person[] peopleInDataBase = (Person[])field.GetValue(database);

            Assert.AreEqual(people, peopleInDataBase);
        }

        [Test]
        public void DoesAddRangeThrowAnException()
        {
            Person[] people = new Person[17];
            Person person1 = new Person(123, "Koki");
            Person person2 = new Person(1233, "oki");
            Person person3 = new Person(12333, "ki");
            Person person4 = new Person(1234, "i");
            Person person5 = new Person(1235, "qKoki");
            Person person6 = new Person(1236, "wKoki");
            Person person7 = new Person(1237, "eKoki");
            Person person8 = new Person(1238, "Kroki");
            Person person9 = new Person(1239, "Kotki");
            Person person10 = new Person(12310, "Koyki");
            Person person11 = new Person(12312, "Kokui");
            Person person12 = new Person(12313, "Kokii");
            Person person13 = new Person(12315, "Kokio");
            Person person14 = new Person(12316, "Kokoi");
            Person person15 = new Person(12317, "Kokpi");
            Person person16 = new Person(12318, "Kokik");
            Person person17 = new Person(125323522318, "Kocfffdskik");

            people[0] = person1;
            people[1] = person2;
            people[2] = person3;
            people[3] = person4;
            people[4] = person5;
            people[5] = person6;
            people[6] = person7;
            people[7] = person8;
            people[8] = person9;
            people[9] = person10;
            people[10] = person11;
            people[11] = person12;
            people[12] = person13;
            people[13] = person14;
            people[14] = person15;
            people[15] = person16;
            people[16] = person17;


            Assert.Throws<ArgumentException>(() => {
                Database database = new Database(people);
            });
        }

        [Test]
        public void DoesAddMethodWorks()
        {
            Person[] people = new Person[16];
            Person person1 = new Person(123, "Koki");
            Person person2 = new Person(1233, "oki");
            Person person3 = new Person(12333, "ki");
            Person person4 = new Person(1234, "i");
            Person person5 = new Person(1235, "qKoki");
            Person person6 = new Person(1236, "wKoki");
            Person person7 = new Person(1237, "eKoki");
            Person person8 = new Person(1238, "Kroki");
            Person person9 = new Person(1239, "Kotki");
            Person person10 = new Person(12310, "Koyki");
            Person person11 = new Person(12312, "Kokui");
            Person person12 = new Person(12313, "Kokii");
            Person person13 = new Person(12315, "Kokio");
            Person person14 = new Person(12316, "Kokoi");
            Person person15 = new Person(12317, "Kokpi");
            Person person16 = new Person(12318, "Kokik");
          //  Person person17 = new Person(125323522318, "Kocfffdskik");*/

            people[0] = person1;
            people[1] = person2;
            people[2] = person3;
            people[3] = person4;
            people[4] = person5;
            people[5] = person6;
            people[6] = person7;
            people[7] = person8;
            people[8] = person9;
            people[9] = person10;
            people[10] = person11;
            people[11] = person12;
            people[12] = person13;
            people[13] = person14;
            people[14] = person15;

            Person[] people1= new Person[15];

            for (int i = 0; i < people.Length-1; i++)
            {
                people1[i] = people[i];
            }

            Database database = new Database(people1);
            database.Add(person16);

            people[15] = person16;

            FieldInfo field = database.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(x => x.Name == "persons");
            Person[] peopleInDataBase = (Person[])field.GetValue(database);

            Assert.AreEqual(people, peopleInDataBase);
        }

        [Test]
        public void DoesAddMethodThrowsAnExceptionWhenNoSpace()
        {
            Person[] people = new Person[16];
            Person person1 = new Person(123, "Koki");
            Person person2 = new Person(1233, "oki");
            Person person3 = new Person(12333, "ki");
            Person person4 = new Person(1234, "i");
            Person person5 = new Person(1235, "qKoki");
            Person person6 = new Person(1236, "wKoki");
            Person person7 = new Person(1237, "eKoki");
            Person person8 = new Person(1238, "Kroki");
            Person person9 = new Person(1239, "Kotki");
            Person person10 = new Person(12310, "Koyki");
            Person person11 = new Person(12312, "Kokui");
            Person person12 = new Person(12313, "Kokii");
            Person person13 = new Person(12315, "Kokio");
            Person person14 = new Person(12316, "Kokoi");
            Person person15 = new Person(12317, "Kokpi");
            Person person16 = new Person(12318, "Kokik");

            people[0] = person1; 
            people[1] = person2; 
            people[2] = person3; 
            people[3] = person4; 
            people[4] = person5; 
            people[5] = person6; 
            people[6] = person7; 
            people[7] = person8; 
            people[8] = person9; 
            people[9] = person10; 
            people[10] = person11; 
            people[11] = person12; 
            people[12] = person13; 
            people[13] = person14; 
            people[14] = person15; 
            people[15] = person16; 

            Database database = new Database(people);
            Assert.Throws<InvalidOperationException>(() => { database.Add(new Person(44455767568, "okidqs givgvbti")); });
        }

        [Test]
        public void DoesDBThorwsAnExceptionWhenNameDuplicates()
        {
            Person[] people = new Person[16];
            people[0] = new Person(123, "koki");
            Database database = new Database(people);
            Assert.Throws<InvalidOperationException>(() => { database.Add(  new Person(124,"koki"));});
        }

        [Test]
        public void DoesDBThorwsAnExceptionWhenIDDuplicates()
        {
            Person[] people = new Person[16];
            people[0] = new Person(123, "koki");
            Database database = new Database(people);
            Assert.Throws<InvalidOperationException>(() => { database.Add(new Person(123, "kokif")); });
        }

    }
}