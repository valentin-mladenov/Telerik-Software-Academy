using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Refactor the following examples to produce code with well-named identifiers in C#:
//class Hauptklasse
//{
//  enum Пол { ултра_Батка, Яка_Мацка };

//  class чуек
//  {
//	public Пол пол { get; set; }
//	public string име_на_Чуека { get; set; }
//	public int Възраст { get; set; }
//  }
//  public void Make_Чуек(int магическия_НомерНаЕДИНЧОВЕК)
//  {
//	  чуек new_Чуек = new чуек();
//	  new_Чуек.Възраст = магическия_НомерНаЕДИНЧОВЕК;
//	  if (магическия_НомерНаЕДИНЧОВЕК % 2 == 0)
//	  {
//		  new_Чуек.име_на_Чуека = "Батката";
//		  new_Чуек.пол = Пол.ултра_Батка;
//	  }
//	  else
//	  {
//		  new_Чуек.име_на_Чуека = "Мацето";
//		  new_Чуек.пол = Пол.Яка_Мацка;
//	  }
//  }
//}

class People
{
	enum Sex { Male, Female };

	class Person
	{
		//Fields should be private.
		public Sex sex { get; set; }
		public string personName { get; set; }
		public int age { get; set; }

		//Constructor is missing... Only renameing.
	}

	public void CreatePerson(int age)
	{
		Person person = new Person();
		person.age = age;

		if (age % 2 == 0)
		{
			person.personName = "Батката"; //Only the string for the name is allowed.
			person.sex = Sex.Male;
		}
		else
		{
			person.personName = "Мацето"; //Only the string for the the name is allowed.
			person.sex = Sex.Female;
		}
	}
}
