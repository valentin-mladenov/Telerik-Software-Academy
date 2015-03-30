// Command pattern demo
namespace CommandDesignPattern
{

	class Invoker
	{
		private Command command;
		public void SetCommand(Command command)
		{
			this.command = command;
		}

		public void ExecuteCommand()
		{
			command.Execute();
		}
	} 

	class Receiver
	{
		public void Action()
		{
			Console.WriteLine("Called ...");
		}
	}

	abstract class Command
	{
		protected Receiver receiver;
		public Command(Receiver receiver)
		{
			this.receiver = receiver;
		}
		public abstract void Execute();
	}

	class ConcreteCommand : Command
	{
		public ConcreteCommand(Receiver receiver)
			: base(receiver)
		{
		}
		public override void Execute()
		{
			receiver.Action();
		}
	}


	class Program
	{
		static void Main()
		{
			Receiver receiver = new Receiver(); 
			// Remember that you don´t really need an receiver if you don´t want it.
			Command command = new ConcreteCommand(receiver);
			Invoker invoker = new Invoker(); // creating requesting object
			invoker.SetCommand(command); //configuration command according her type 
			invoker.ExecuteCommand(); 
			Console.ReadLine();  // used only for suspension of the console
		}

	}
}