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

        /// <summary>
        /// unit testing for verifying the final result of an input
        /// </summary>
        /// <param name="currentxAxis">The current position of the spider on the X axis of the wall</param>
        /// <param name="currentYAxis">The current position of the spider on the Y axis of the wall</param>
        /// <param name="MaxXAxis">The Maximum unit value of the X axis determining the width of the wall</param>
        /// <param name="MaxYAxis">The Maximum unit value of the Y axis determining the height of the wall</param>
        /// <param name="CurrentDirection">The current direction the spider is facing i.e Left, Right, Up or Down</param>
        /// <param name="Command">The command to be followed by the spider</param>
        /// <param name="expectedX">The expected X coordinate of the spider after process execution</param>
        /// <param name="expectedY">The expected Y coordinate of the spider after process execution</param>
        /// <param name="expectedDirection">The direction of the spider after process execution</param>
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
            //check to see if the spider coordiantes are valid
            bool isAValidCommand = spiderManRodent.IsValidCoordinates();

            Assert.AreEqual(expectedOutcome, isAValidCommand);

        }
    }
}