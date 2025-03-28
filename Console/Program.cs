// See https://aka.ms/new-console-template for more information

namespace GithubActionsLab;

public class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("The Quick Calculator");
		var loop = true;
		while (loop)
		{
			try
			{
				Func<string, string, double> operation;
				Console.WriteLine("1) Add (x+y)");
				Console.WriteLine("2) Subtract (x-y)");
				Console.WriteLine("3) Multiply (x*y)");
				Console.WriteLine("4) Divide (x/y)");
				Console.WriteLine("5) Power (x^y)");
				Console.WriteLine("6) Quit");
				var operationSelection = GetInput("Select your operation: ");
				switch (operationSelection)
				{
					case "1":
						operation = Add;
						break;
					case "2":
						operation = Subtract;
						break;
					case "3":
						operation = Multiply;
						break;
					case "4":
						operation = Divide;
						break;
					case "5":
						operation = Power;
						break;
					case "6":
						loop = false;
						continue;
					default:
						throw new ArgumentException("You did not select a valid option!");
				}

				var x = GetInput("Enter x: ");
				var y = GetInput("Enter y: ");
				var result = operation(x, y);
				Console.WriteLine($"Result: {result}");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}

	private static string GetInput(string prompt)
	{
		Console.Write(prompt);

		return Console.ReadLine()?.Trim() ?? throw new InvalidOperationException();
	}

	public static double Add(string x, string y)
	{
		return double.Parse(x) + double.Parse(y);
	}

	public static double Subtract(string x, string y)
	{
		return double.Parse(x) - double.Parse(y);
	}

	public static double Multiply(string x, string y)
	{
		return double.Parse(x) * double.Parse(y);
	}

	public static double Divide(string x, string y)
	{
		return double.Parse(x) / double.Parse(y);
	}

	// Implement this method following a similar pattern as above
	public static double Power(string x, string y)
	{
		return Math.Pow(double.Parse(x) , double.Parse(y));
	}
[TestClass]
    public class SubtractionTests
    {
        [TestMethod]
        public void Subtract_Valid()
        {
            Assert.AreEqual(-1, Program.Subtract("1", "2"));
            Assert.AreEqual(1, Program.Subtract("3", "2"));
            Assert.AreEqual(-2, Program.Subtract("5", "7"));
        }

        [TestMethod]
        public void Subtract_Invalid()
        {
            Assert.ThrowsException<FormatException>(() => Program.Subtract("1", "a"));
            Assert.ThrowsException<FormatException>(() => Program.Subtract("a", "1"));
            Assert.ThrowsException<FormatException>(() => Program.Subtract("a", "a"));
        }

        [TestMethod]
        public void Subtract_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Program.Subtract("1", null));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Subtract(null, "1"));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Subtract(null, null));
        }
    }

    [TestClass]
    public class DivisionTests
    {
        [TestMethod]
        public void Divide_Valid()
        {
            // For floating point comparisons, you can include a delta (tolerance)
            Assert.AreEqual(0.5, Program.Divide("1", "2"), 1e-9);
            Assert.AreEqual(1.5, Program.Divide("3", "2"), 1e-9);
            Assert.AreEqual(0.7142857142857143, Program.Divide("5", "7"), 1e-9);
        }

        [TestMethod]
        public void Divide_Invalid()
        {
            Assert.ThrowsException<FormatException>(() => Program.Divide("1", "a"));
            Assert.ThrowsException<FormatException>(() => Program.Divide("a", "1"));
            Assert.ThrowsException<FormatException>(() => Program.Divide("a", "a"));
        }

        [TestMethod]
        public void Divide_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Program.Divide("1", null));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Divide(null, "1"));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Divide(null, null));
        }

        [TestMethod]
        public void Divide_ByZero()
        {
            // Dividing by zero using double.Parse will result in Infinity (or -Infinity) without throwing an exception
            Assert.AreEqual(double.PositiveInfinity, Program.Divide("1", "0"));
        }
    }

    [TestClass]
    public class PowerTests
    {
        [TestMethod]
        public void Power_Valid()
        {
            Assert.AreEqual(8, Program.Power("2", "3"));
            Assert.AreEqual(9, Program.Power("3", "2"));
            Assert.AreEqual(16, Program.Power("4", "2"));
        }

        [TestMethod]
        public void Power_Invalid()
        {
            Assert.ThrowsException<FormatException>(() => Program.Power("1", "a"));
            Assert.ThrowsException<FormatException>(() => Program.Power("a", "1"));
            Assert.ThrowsException<FormatException>(() => Program.Power("a", "a"));
        }

        [TestMethod]
        public void Power_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Program.Power("1", null));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Power(null, "1"));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Power(null, null));
        }
    }
}
