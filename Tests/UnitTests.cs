namespace GithubActionsLab;

[TestClass]
public class Addition
{
	[TestMethod]
	public void Add_Valid_Patino()
	{
		Assert.AreEqual(3, Program.Add("1", "2"));
		Assert.AreEqual(5, Program.Add("3", "2"));
		Assert.AreEqual(12, Program.Add("5", "7"));
	}

	[TestMethod]
	public void Add_Invalid_Patino()
	{
		Assert.ThrowsException<FormatException>(() => Program.Add("1", "a"));
		Assert.ThrowsException<FormatException>(() => Program.Add("a", "1"));
		Assert.ThrowsException<FormatException>(() => Program.Add("a", "a"));
	}

	[TestMethod]
	public void Add_Null_Patino()
	{
		Assert.ThrowsException<ArgumentNullException>(() => Program.Add("1", null));
		Assert.ThrowsException<ArgumentNullException>(() => Program.Add(null, "1"));
		Assert.ThrowsException<ArgumentNullException>(() => Program.Add(null, null));
	}
}


[TestClass]
public class MultiplicationTests
    {
	[TestMethod]
	public void Multiply_Valid()
        {
            Assert.AreEqual(2, Program.Multiply("1", "2"));
            Assert.AreEqual(6, Program.Multiply("3", "2"));
            Assert.AreEqual(35, Program.Multiply("5", "7"));
        }

        [TestMethod]
        public void Multiply_Invalid()
        {
            Assert.ThrowsException<FormatException>(() => Program.Multiply("1", "a"));
            Assert.ThrowsException<FormatException>(() => Program.Multiply("a", "1"));
            Assert.ThrowsException<FormatException>(() => Program.Multiply("a", "a"));
        }

        [TestMethod]
        public void Multiply_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Program.Multiply("1", null));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Multiply(null, "1"));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Multiply(null, null));
        }
    }
