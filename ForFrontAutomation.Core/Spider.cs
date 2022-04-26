using System;

namespace ForFrontAutomation.Core
{
    public class Spider
    {
        //this represents the spiders current position on the X axis
        public int XAxis { get; set; }
        //this represents the spiders currents position on the Y axis
        public int YAxis { get; set; }
        // defines the limit of the x axis
        public int MaxXAxis { get; set; }
        //defines the limit of the y axis
        public int MaxYAxis { get; set; }
        //Sets the index of the current orientation of the spider on the wall
        protected int CurrentPositionIndex { get; set; }

        // this allows us to automatically set the index in the array based off the direction entered
        public string CurrentDirection
        {
            get
            { return Orientation[CurrentPositionIndex]; }

            set
            {
                this.CurrentDirection = value;
            }
        }

        protected string[] Orientation = { "Up", "Right", "Down", "Left" };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CurrentXAxis">The current position of the spider on the X axis of the wall</param>
        /// <param name="CurrentYAxis">The current position of the spider on the Y axis of the wall</param>
        /// <param name="MaxX"> The Maximum unit value of the X axis determining the width of the wall</param>
        /// <param name="MaxY">The Maximum unit value of the Y axis determining the height of the wall</param>
        /// <param name="CurrentOrientation">The current direction the spider is facing i.e Left, Right, Up or Down</param>
        public Spider(int CurrentXAxis, int CurrentYAxis, int MaxX, int MaxY, string CurrentOrientation)
        {
            XAxis = CurrentXAxis;
            YAxis = CurrentYAxis;
            MaxXAxis = MaxX;
            MaxYAxis = MaxY;
            CurrentPositionIndex = Array.IndexOf(Orientation, CurrentOrientation);
        }

        public Spider() { }

        private void Turn(string orientation)
        {
            //now based on the orientation and its index in the Orientation array we can determine where it needs to turn to
            // The Spider can only turn Left or Right i.e Left from Up to Right or Left from Left to Down
            // Left turn being an anti-clockwise movement and a right turn being a clockwise movement
            if (orientation.Equals("L"))
            {
                // if it is a Left turn to reconfigure the direction of the spider we only need to move one index backwards in the array which has been orderd accordingly based on coordinated.
                //we also need to check the origin of the array since we ae moving backwards and then jump to the last element i.e from Up to Left
                if (CurrentPositionIndex == 0)
                {
                    CurrentPositionIndex = 3;
                }
                else
                {
                    CurrentPositionIndex--;
                }
            }
            else
            {
                // if it is a Right turn, to reconfigure the direction of the spider we only need to move one index forward in the array which has been orderd accordingly based on coordinated.
                //we will also need to check the boundaies of the array and move back to the default position on hitting max i.e from Left to Up
                if (CurrentPositionIndex == 3)
                {
                    CurrentPositionIndex = 0;
                }
                else
                {
                    CurrentPositionIndex++;
                }
            }
        }

        private void Move()
        {
            //chec what axis the spider is currenty oriented on Up and down represent the Y axis while X axis represents vertical.
            if (CurrentDirection.Equals("Up") || CurrentDirection.Equals("Down"))
            {
                //given that a grid goes 0 to N on the y axis as it moves from bottom up
                if (CurrentDirection.Equals("Up"))
                {
                    YAxis = (YAxis < MaxXAxis) ? YAxis + 1 : YAxis;
                }
                else
                    YAxis = (YAxis > 0) ? YAxis - 1 : YAxis;
            }
            else
            {
                //given that a grid goes 0 to N on the x axis as it moves from Left to right
                if (CurrentDirection.Equals("Right"))
                {
                    XAxis = (XAxis < MaxXAxis) ? XAxis + 1 : XAxis;
                }
                else
                    XAxis = (XAxis > 0) ? XAxis - 1 : XAxis;
            }
        }

        /// <summary>
        /// This method processes the users command for a spiders imput
        /// </summary>
        /// <param name="commandString"></param>
        public Spider ProcessCommand(string commandString)
        {
            char[] commands = commandString.ToCharArray();

            foreach (var command in commands)
            {
                //convert the command to a string required for the Orient method
                string action = command.ToString();

                //Based on principles 'F' is identified as a movement command and anything else is a direction change command
                if (action.Equals("F"))
                {
                    Move();
                }
                else
                {
                    Turn(action);
                }
            }

            return this;
        }

        public bool IsValidStartingPosition()
        {
            if (XAxis > MaxXAxis || YAxis > MaxYAxis)
                return false;
            else
                return true;
        }
    }
}
