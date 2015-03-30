using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Refactor the following examples to produce code with well-named C# identifiers:
//class class_123
//{
//	const int max_count = 6;		//Deleted.
//	class InClass_class_123
//	{
//		void Метод_нА_class_InClass_class_123(bool promenliva)
//		{
//			string promenlivaKatoString = promenliva.ToString();
//			Console.WriteLine(promenlivaKatoString);
//		}
//	}
//	public static void Метод_За_Вход()
//	{
//		class_123.InClass_class_123 инстанция =
//		  new class_123.InClass_class_123();
//		инстанция.Метод_нА_class_InClass_class_123(true);
//	}
//}

class Person //not sure for the purpose of the class. Use the name only to make any sense.
{
	//the const "max_count" has been deleted.
	class Student //not sure for the purpose of the class. Use the name only to make any sense.
	{
		public void PrintBoolValue(bool input)
		{
			string inputToString = input.ToString();
			Console.WriteLine(inputToString);
		}
	}

	public static void Main()
	{
		Person.Student person =
		  new Person.Student();
		person.PrintBoolValue(true);
	}
}