using ForFrontAutomation.Core;
using NUnit.Framework;

namespace ForFront.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(4, 10, 7, 5, "Left", "FLFLFRFFLF", 5, 7, "Right")]
        public void TestForSpidersMovement(int currentxAxis, int currentYAxis, int MaxXAxis, int MaxYAxis, string CurrentDirection, string Command, int expectedX, int expectedY, string expectedDirection)
        {
            //creat a spider instance
            Spider spiderManRodent = new Spider(currentxAxis, currentYAxis, MaxXAxis, MaxYAxis, CurrentDirection);

            //call the spider to pprocess a new command
            spiderManRodent.ProcessCommand(Command);

            Assert.AreEqual(expectedX, spiderManRodent.XAxis, spiderManRodent.YAxis);
            Assert.AreEqual(expectedY, spiderManRodent.YAxis);
            Assert.AreEqual(expectedDirection, spiderManRodent.CurrentDirection);

        }

        [TestCase(4, 10, 0, 0, "Left", "FLFLFRFFLF", false)]
        public void TestForValidPositioning(int currentxAxis, int currentYAxis, int MaxXAxis, int MaxYAxis, string CurrentDirection, string Command, bool expectedOutcome)
        {
            //creat a spider instance
            Spider spiderManRodent = new Spider(currentxAxis, currentYAxis, MaxXAxis, MaxYAxis, CurrentDirection);
            //call the spider to pprocess a new command
            bool isAValidCommand = spiderManRodent.IsValidStartingPosition(currentxAxis, currentYAxis, MaxXAxis, MaxYAxis);

            Assert.AreEqual(expectedOutcome, isAValidCommand);

        }
    }
}