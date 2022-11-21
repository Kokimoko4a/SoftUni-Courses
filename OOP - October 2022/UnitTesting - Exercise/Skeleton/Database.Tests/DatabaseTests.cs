namespace Database.Tests
{
    using NUnit.Compatibility;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database = new Database(new int []{ 1, 2, 3 });

        [SetUp]

        public void SetUp()
        {
            database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
        }

        [Test]
        public void TestConstructor()
        {
            int[] array = new int[] { 1, 2, 3 ,4,5,6,7,8,9,10,11,12,13,14,15,26};

            Database database2 = new Database(array);

            FieldInfo field = database2.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "data");

            int[] dataOfDataBase = (int[])field.GetValue(database2);
         
            Assert.AreEqual(array, dataOfDataBase);
        }

        [Test]
        public void DoesAddMethodWrks()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            database.Add(16);

            FieldInfo field = database.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "data");

            int[] dataOfDataBase = (int[])field.GetValue(database);

            Assert.AreEqual(array, dataOfDataBase);
        }

        [Test]
        public void DoesAddMethodThrowsAnExceptionWhenFull() 
        {
            database.Add(16);

            Assert.Throws<InvalidOperationException>(() => { database.Add(17); } );
        }

        [Test]

        public void DoesRemoveMethodThrowsAnExceptionWhenCountIs0()
        {
            Database database4 = new Database(new int[] {1 } );

            database4.Remove();

            Assert.Throws<InvalidOperationException>(() => { database4.Remove(); });
        }

        [Test]
        public void DoesRemoveMethodWorks()
        {

            Database database2 = new Database(new int[] { 1, 2 });
            database2.Remove();

            Assert.AreEqual(1, database2.Count);
        }

        [Test]
        public void DoesFetchMethodWorskPropperly()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 ,16};

            database.Add(16);

            Assert.AreEqual(array, database.Fetch());
        }

    }
}
