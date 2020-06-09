using NUnit.Framework;
using System.Collections;

namespace TurnUpPortal
{
    internal class TestDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("green", "color");
                yield return new TestCaseData("red", "color");

            }
        }
    }
}