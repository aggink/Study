using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.Crocodile17.Task1;
using Study.Lab1.Logic.Interfaces.Crocodile17.Task1;

namespace Study.Lab1.Logic.Crocodile17
{
	public class Crocodile17Service : IRunService
	{
		public void RunTask1()
		{
			var r1 = new RationalNumber(1, 2);
			var r2 = new RationalNumber(-7, 4);
			var r3 = new RationalNumber(-3, -1);
			var r4 = new RationalNumber(6, 9);
			var r5 = new RationalNumber(10, -5);

			var amount = r1 + r2;
			var difference = r1 - r2;
			var product = r1 * r2;
			var quotient = r1 / r2;

			Console.Write(
				$"r1: {r1}, r2: {r2}, r3: {r3}, r4: {r4}, r5: {r5} \n" +
				$"used format: numerator/denominator\n" +
				$"-r1 = {-r1}\n" +
				$"r1 + r2 = {amount}\n" +
				$"r1 - r2 = {difference}\n" +
				$"r1 * r2 = {product}\n" +
				$"r1 / r2 = {quotient}\n" +
				$"r1 == r2 ? {r1 == r2} \n" +
				$"r1 > r2 ? {r1 > r2} \n" +
				$"r3 < r2 ? {r3 < r2} \n" +
				$"r3 >= r4 ? {r3 >= r4} \n" +
				$"r1 <= r5 ? {r1 <= r5} \n"
				);
		}

		public void RunTask2() { throw new NotImplementedException(); }

		public void RunTask3() { throw new NotImplementedException(); }
	}
}
