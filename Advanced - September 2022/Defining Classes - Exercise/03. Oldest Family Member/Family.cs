using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
		private List<Person> people;

		public List<Person> People
		{
			get { return people; }
			set { people = value; }
		}

		 public void AddMemeber(Person member)
		{
			People.Add(member);	
		}

		public string GetOldestMember()
		{
			int age = People.Max(x=>x.Age);
			Person person = People.FirstOrDefault(x => x.Age == age);
			return person.Name + " " + person.Age;
			
		}

    }
}
