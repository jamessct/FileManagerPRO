using System;

namespace ConsoleApplication
{
    public class ConsoleAnimation
    {
        private int currentAnimationFrame;

        public ConsoleAnimation()
        {
            SpinnerAnimationFrames = new[]
                {
                    "....................",
                    "*...................",
                    "**..................",
                    "***.................",
                    "****................",
                    "*****...............",
                    "******..............",
                    "*******.............",
                    "********............",
                    "*********...........",
                    "**********..........",
                    "***********.........",
                    "************........",
                    "*************.......",
                    "**************......",
                    "***************.....",
                    "****************....",
                    "*****************...",
                    "******************..",
                    "*******************.",
                    "********************"
                };
        }

        public string[] SpinnerAnimationFrames { get; set; }

        public bool animation()
        {
            Console.CursorVisible = false;
            var originalX = Console.CursorLeft;
            var originalY = Console.CursorTop;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(SpinnerAnimationFrames[currentAnimationFrame]);
            Console.ForegroundColor = ConsoleColor.White;

            currentAnimationFrame++;
            if(currentAnimationFrame == SpinnerAnimationFrames.Length)
            {
                currentAnimationFrame = 0;
            }

            Console.SetCursorPosition(originalX, originalY);
            return currentAnimationFrame!=0?true:false;
        }
    }
}