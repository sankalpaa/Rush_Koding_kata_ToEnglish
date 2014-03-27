using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace ToEnglish
{
    public class ToEnglish
    {
	    [TestCase(1, "one")]
	    [TestCase(2, "two")]
	    [TestCase(3, "three")]
	    [TestCase(4, "four")]
	    [TestCase(5, "five")]
	    [TestCase(6, "six")]
	    [TestCase(7, "seven")]
	    [TestCase(8, "eight")]
	    [TestCase(9, "nine")]
	    [TestCase(10, "ten")]
	    [TestCase(11, "eleven")]
	    [TestCase(12, "twelve")]
	    [TestCase(13, "thirteen")]
	    [TestCase(14, "fourteen")]
	    [TestCase(15, "fifteen")]
	    [TestCase(16, "sixteen")]
	    [TestCase(17, "seventeen")]
	    [TestCase(18, "eighteen")]
	    [TestCase(19, "nineteen")]
	    [TestCase(20, "twenty")]
	    [TestCase(21, "twenty one")]
	    [TestCase(29, "twenty nine")]
	    [TestCase(30, "thirty")]
	    [TestCase(40, "fourty")]
	    [TestCase(50, "fifty")]
	    [TestCase(60, "sixty")]
	    [TestCase(70, "seventy")]
	    [TestCase(80, "eighty")]
	    [TestCase(90, "ninety")]
		[TestCase(100, "one hundred")]
		[TestCase(110, "one hundred and ten")]
		[TestCase(556, "five hundred and fifty six")]
		[TestCase(7000, "seven thousand")]
		[TestCase(11812, "eleven thousand eight hundred and twelve")]
		[TestCase(13014, "thirteen thousand and fourteen")]
		[TestCase(100000, "one hundred thousand")]
		[TestCase(1000000, "one million")]
	    public void IntegerShouldReturnTextValue(int number, string numberText)
	    {
		    number.ToEnglish().Should().BeEquivalentTo(numberText);
	    }
    }

	public static class IntegerToEnglish
	{
		static StringBuilder numberToEnglish = new StringBuilder();
		static Dictionary<int, string> numberInText = new Dictionary<int, string>
				{
					{1, "one"},
					{2, "two"},
					{3, "three"},
					{4, "four"},
					{5, "five"},
					{6, "six"},
					{7, "seven"},
					{8, "eight"},
					{9, "nine"},
					{10, "ten"},
					{11, "eleven"},
					{12, "twelve"},
					{13, "thirteen"},
					{14, "fourteen"},
					{15, "fifteen"},
					{16, "sixteen"},
					{17, "seventeen"},
					{18, "eighteen"},
					{19, "nineteen"},
				};
		static Dictionary<int, string> tens = new Dictionary<int, string>
				{
					{20, "twenty"},
					{30, "thirty"},
					{40, "fourty"},
					{50, "fifty"},
					{60, "sixty"},
					{70, "seventy"},
					{80, "eighty"},
					{90, "ninety"},
				};

		private static Dictionary<int, string> tenthOf = new Dictionary<int, string>
			{
				{1000000," million"},
				{100000," hundred thousand"},
				{1000," thousand"},
				{100," hundred"}
			};

		public static string ToEnglish(this int number)
		{
			numberToEnglish.Clear();

			foreach (var keyValuePair in tenthOf)
			{
				if (number >= keyValuePair.Key)
				{
					number = SetSectionNumericText(keyValuePair.Key, number);
				}
			}

			if (number >= 20)
			{
				int divideResult = number/10;
				numberToEnglish.Append(numberToEnglish.Length > 1 ? " and " : "");
				numberToEnglish.Append(tens[divideResult*10]);
				number %= 10;
			}
			if (number != 0)
			{
				numberToEnglish.Append(numberToEnglish.Length > 1 ? " " : "");
				numberToEnglish.Append(numberToEnglish.Length > 1 && number > 9 ? "and " : "");
				numberToEnglish.Append(numberInText[number]);
			}
			return numberToEnglish.ToString();
		}

		private static int SetSectionNumericText(int diviser, int number)
		{
			int divideResult = number / diviser;
			numberToEnglish.Append(numberToEnglish.Length > 1 ? " " : "");
			numberToEnglish.Append(numberInText[divideResult]);
			numberToEnglish.Append(tenthOf[diviser]);
			number %= diviser;
			return number;
		}
	}
}
