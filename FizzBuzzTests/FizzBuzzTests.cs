using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzLib;
using System.Collections.Generic;

namespace FizzBuzzTests
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void GetFizzBuzzTest_VerifyFizz_NoDivBy3NumbersFnd()
        {
            // Verify no numbers divisible by 3 are printed.
            var fizzBuzzLib = new FizzBuzz();
            var specialCases = new Dictionary<int, string>();
            specialCases[3] = " Fizz";
            var results = fizzBuzzLib.GetFizzBuzz(specialCases);
            var rows = GetRows(results);
            Assert.AreEqual(rows.Length, 100);
            foreach (var row in rows)
            {
                int rowValue;
                if (int.TryParse(row, out rowValue))
                {
                    if (rowValue % 3 == 0)
                    {
                        Assert.Fail("Row found with number divisible by 3");
                    }
                }
            }
        }

        [TestMethod]
        public void GetFizzBuzzTest_VerifyFizz_GoodNumbersPrintedCheck()
        {
            // Verify the sum of printed numbers are correct for not div by 3.
            var fizzBuzzLib = new FizzBuzz();
            var specialCases = new Dictionary<int, string>();
            specialCases[3] = " Fizz";
            var results = fizzBuzzLib.GetFizzBuzz(specialCases);
            var rows = GetRows(results);
            Assert.AreEqual(rows.Length, 100);
            int printedNumberCount = 0;
            foreach (var row in rows)
            {
                int rowValue;
                if (int.TryParse(row, out rowValue))
                {
                    printedNumberCount++;
                }
            }
            var printCount = Math.Ceiling(100d * 2 / 3);
            Assert.AreEqual(printedNumberCount, printCount);
        }

        [TestMethod]
        public void GetFizzBuzzTest_VerifyFizzBuzz_NoDivByNumbersFnd()
        {
            // Verify for fizz and buzz no divisible numbers are printed.
            var fizzBuzzLib = new FizzBuzz();
            var specialCases = new Dictionary<int, string>();
            specialCases[3] = " Fizz";
            specialCases[5] = " Buzz";
            var results = fizzBuzzLib.GetFizzBuzz(specialCases);
            var rows = GetRows(results);
            Assert.AreEqual(rows.Length, 100);
            foreach (var row in rows)
            {
                int rowValue;
                if (int.TryParse(row, out rowValue))
                {
                    if (rowValue % 3 == 0)
                    {
                        Assert.Fail("Row found with number divisible by 3");
                    }
                    if (rowValue % 5 == 0)
                    {
                        Assert.Fail("Row found with number divisible by 5");
                    }
                }
            }
        }

        [TestMethod]
        public void GetFizzBuzzTest_VerifyFizzBuzz__GoodNumbersPrintedCheck()
        {
            // verify for fizz and buzz the sum of numbers printed is correct
            var fizzBuzzLib = new FizzBuzz();
            var specialCases = new Dictionary<int, string>();
            specialCases[3] = " Fizz";
            specialCases[5] = " Buzz";
            var results = fizzBuzzLib.GetFizzBuzz(specialCases);
            var rows = GetRows(results);
            Assert.AreEqual(rows.Length, 100);
            int printedNumberCount = 0;
            foreach (var row in rows)
            {
                int rowValue;
                if (int.TryParse(row, out rowValue))
                {
                    printedNumberCount++;
                }
            }

            var fizzCount = Math.Floor(100d * 1 / 3);
            var buzzCount = Math.Floor(100d * 1 / 5);
            var intersection = Math.Floor(100d * 1 / 15);

            var printCount = 100 - fizzCount - buzzCount + intersection;
            Assert.AreEqual(printedNumberCount, printCount);
        }

        [TestMethod]
        public void GetFizzBuzzTest_VerifyFizz_ByPositionChecks()
        {
            // Verify every row divisible by 3 shows "Fizz"
            var fizzBuzzLib = new FizzBuzz();
            var specialCases = new Dictionary<int, string>();
            specialCases[3] = " Fizz";
            var results = fizzBuzzLib.GetFizzBuzz(specialCases);
            var rows = GetRows(results);
            Assert.AreEqual(rows.Length, 100);
            for (int i = 1; i <= 100; i++)
            {
                // adjust position by one since rows is zero based and numbers are 1-100.
                var row = rows[i - 1];
                if (i % 3 == 0 && !row.Contains("Fizz"))
                {
                    Assert.Fail("Fizz row is missing");
                }
            }
        }

        [TestMethod]
        public void GetFizzBuzzTest_VerifyFizz_ByPositionChecksNegative()
        {
            // Verify every row not divisible by 3 does not show "Fizz"
            var fizzBuzzLib = new FizzBuzz();
            var specialCases = new Dictionary<int, string>();
            specialCases[3] = " Fizz";
            var results = fizzBuzzLib.GetFizzBuzz(specialCases);
            var rows = GetRows(results);
            Assert.AreEqual(rows.Length, 100);
            for (int i = 1; i <= 100; i++)
            {
                // adjust position by one since rows is zero based and numbers are 1-100.
                var row = rows[i - 1];
                if (i % 3 != 0 && row.Contains("Fizz"))
                {
                    Assert.Fail("Fizz row is invalid");
                }
            }
        }

        [TestMethod]
        public void GetFizzBuzzTest_VerifyFizzBuzzCantalope_ByPositionChecks()
        {
            // verify each row divisible by input keys shows correct string
            var fizzBuzzLib = new FizzBuzz();
            var specialCases = new Dictionary<int, string>();
            specialCases[3] = " Fizz";
            specialCases[5] = " Buzz";
            specialCases[7] = " Cantalope";
            var results = fizzBuzzLib.GetFizzBuzz(specialCases);
            var rows = GetRows(results);
            Assert.AreEqual(rows.Length, 100);
            for (int i = 1; i <= 100; i++)
            {
                // adjust position by one since rows is zero based and numbers are 1-100.
                var row = rows[i - 1];
                if (i % 3 == 0 && !row.Contains("Fizz"))
                {
                    Assert.Fail("Fizz row is not fizzy");
                }
                if (i % 5 == 0 && !row.Contains("Buzz"))
                {
                    Assert.Fail("Buzz row is not buzzy");
                }
                if (i % 7 == 0 && !row.Contains("Cantalope"))
                {
                    Assert.Fail("Fruity row is not fruity");
                }
            }
        }

        [TestMethod]
        public void GetFizzBuzzTest_VerifyFizzBuzzCantalope_ByPositionChecksNegative()
        {
            // verify each number not divisible by input keys does NOT show matching text
            var fizzBuzzLib = new FizzBuzz();
            var specialCases = new Dictionary<int, string>();
            specialCases[3] = " Fizz";
            specialCases[5] = " Buzz";
            specialCases[7] = " Cantalope";
            var results = fizzBuzzLib.GetFizzBuzz(specialCases);
            var rows = GetRows(results);
            Assert.AreEqual(rows.Length, 100);

            for (int i = 1; i <= 100; i++)
            {
                // adjust position by one since rows is zero based and numbers are 1-100.
                var row = rows[i - 1];
                if (i % 3 != 0 && row.Contains("Fizz"))
                {
                    Assert.Fail("Fizz row is invalid");
                }
                if (i % 5 != 0 && row.Contains("Buzz"))
                {
                    Assert.Fail("Buzz row is invalid");
                }
                if (i % 7 != 0 && row.Contains("Cantalope"))
                {
                    Assert.Fail("Fruity row is invalid");
                }
            }
        }

        private static string[] GetRows(string results)
        {
            var rows = results.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return rows;
        }
    }
}
