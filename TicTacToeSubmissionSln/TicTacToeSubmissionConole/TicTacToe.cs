using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private int[] _boardPosition = new int[9] {-1,-1,-1,-1,-1,-1,-1,-1,-1};
        private int _rounds;

        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10,6);
            _boardRenderer.Render();
        }

        private void PlayMove(PlayerEnum player)

        {
            Console.SetCursorPosition(2, 19);
            //change to num
            if (player == PlayerEnum.X)
            {
                Console.WriteLine("Player X");
            }


            else
            {
                Console.WriteLine("Player O");
            }

            Console.SetCursorPosition(2, 20);

            Console.Write("Please Enter Row: ");
            var row = Console.ReadLine();

            Console.SetCursorPosition(2, 22);


            Console.Write("Please Enter Column: ");
            var column = Console.ReadLine();

            // store move in array
            int rowNumber = int.Parse(row);
            int columnNumber = int.Parse(column);
            int arrayPos = (rowNumber * 3) + columnNumber;

            _boardPosition[arrayPos] = (int)player;
        }

            // Add move to the board
          /*if (player == PlayerEnum.X)
            {
                _boardRenderer.AddMove(rowNumber, columnNumber, PlayerEnum.X, true);
            }

            else
            {
          _boardRenderer.AddMove(rowNumber, columnNumber, PlayerEnum.O, true);
            }
        */
                  
           public bool CheckIfPlayerWins(PlayerEnum player)
        {   
            int playerValue = (int)player;

            if ((_boardPosition[0] == playerValue) && (_boardPosition[1] == playerValue) && (_boardPosition[2] == playerValue))
                return true;
            if ((_boardPosition[3] == playerValue) && (_boardPosition[4] == playerValue ) && (_boardPosition[5] == playerValue))
                return true;
            if ((_boardPosition[6] == playerValue) && (_boardPosition[7] == playerValue) && (_boardPosition[8] == playerValue))
                return true;
            if ((_boardPosition[0] == playerValue) && (_boardPosition[3] == playerValue) && (_boardPosition[6] == playerValue))
                return true;
            if ((_boardPosition[1] == playerValue) && (_boardPosition[4] == playerValue) && (_boardPosition[7] == playerValue))
                return true;
            if ((_boardPosition[2] == playerValue) && (_boardPosition[5] == playerValue) && (_boardPosition[8] == playerValue))
                return true;
            if ((_boardPosition[0] == playerValue) && (_boardPosition[4] == playerValue) && (_boardPosition[8] == playerValue))
                return true;
            if ((_boardPosition[2] == playerValue) && (_boardPosition[4] == playerValue) && (_boardPosition[6] == playerValue))
                return true;

            return false;
        }

        public void Run()
        {
            _rounds = 0;
            bool playerXWins=false;
            bool playerOWins=false;

            while (_rounds < 4)
            {
                // change to num
                PlayMove(PlayerEnum.X);

                playerXWins = CheckIfPlayerWins(PlayerEnum.X);

                if (playerXWins)
                {
                    Console.WriteLine("PlayerEnum X Wins!!!");
                    break;
                }

                // change to num

                PlayMove(PlayerEnum.O);
                playerOWins = CheckIfPlayerWins(PlayerEnum.O);

                if (playerOWins)
                {
                    Console.WriteLine("Player O Wins!!!");
                }

                _rounds++;

            }

            if (!playerXWins && !playerOWins)
            {
                Console.WriteLine("The game is draw"); 
            }
           
        }
      

    }
}
