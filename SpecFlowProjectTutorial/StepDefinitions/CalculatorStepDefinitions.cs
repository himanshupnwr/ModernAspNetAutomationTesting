using System.Runtime.Intrinsics.X86;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.CommonModels;

namespace SpecFlowProjectTutorial.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            Console.WriteLine($"{ nameof(GivenTheFirstNumberIs)} : {number}");
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            Console.WriteLine($"{nameof(GivenTheSecondNumberIs)} : {number}");
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Console.WriteLine($"{nameof(WhenTheTwoNumbersAreAdded)} : ");
        }

        [Then("the result should be int (.*)")]
        public void ThenTheResultShouldBeInt(int result)
        {
            Console.WriteLine($"{nameof(ThenTheResultShouldBeInt)} : {result}");
        }

        [Then("the result should be string (.*)")]
        public void ThenTheResultShouldBeString(string result)
        {
            Console.WriteLine($"{nameof(ThenTheResultShouldBeString)} : {result}");
        }

        [Given(@"I Input following numbers to the calculator")]
        public void GivenInputFollowingNumbersToTheCalculator(Table table)
        {
            var data = table.CreateSet<Calculation>();

            foreach (var item in data)
            {
                Console.WriteLine($"The number is {item.Numbers}");
            }
        }

        [Then(@"I see the result and few more details")]
        public void ThenISeeTheResultAndFewMoreDetails(Table table)
        {
            //install package specflow dynamic assist to use dynamic
            dynamic data = table.CreateDynamicInstance();

            foreach (var item in data)
            {
                Console.WriteLine($"The result is going to hold the value{data.Results} with Logo {data.Logo}");
            }
        }


        private record Calculation
        {
            public int Numbers { get; set; }
        }
    }
}