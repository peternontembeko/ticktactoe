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
        private int[] _boardPosition = new int[9];
        private int _rounds;

        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10,6);
            _boardRenderer.Render();
        }

         private void PlayMove(int player)

        { 
            Console.SetCursorPosition(2, 19);
            //change to num
            if (player == 1)
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

            _boardPosition[arrayPos] = player;

            // Add move to the board
            if (player == 1)
            {
                _boardRenderer.AddMove(rowNumber, columnNumber, PlayerEnum.X, true);
            }

            else
            {
                _boardRenderer.AddMove(rowNumber, columnNumber, PlayerEnum.O, true);
            } 
        }
                  
           public bool CheckIfPlayerWins(int player)
        {
            if ((_boardPosition[0] == player) && (_boardPosition[1] == player) && (_boardPosition[2] == player))
                return true;
            if ((_boardPosition[3] == player) && (_boardPosition[4] == player) && (_boardPosition[5] == player))
                return true;
            if ((_boardPosition[6] == player) && (_boardPosition[7] == player) && (_boardPosition[8] == player))
                return true;
            if ((_boardPosition[0] == player) && (_boardPosition[3] == player) && (_boardPosition[6] == player))
                return true;
            if ((_boardPosition[1] == player) && (_boardPosition[4] == player) && (_boardPosition[7] == player))
                return true;
            if ((_boardPosition[2] == player) && (_boardPosition[5] == player) && (_boardPosition[8] == player))
                return true;
            if ((_boardPosition[0] == player) && (_boardPosition[4] == player) && (_boardPosition[8] == player))
                return true;
            if ((_boardPosition[2] == player) && (_boardPosition[4] == player) && (_boardPosition[6] == player))
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
                PlayMove(1);

                playerXWins = CheckIfPlayerWins(1);

                if (playerXWins)
                {
                    Console.WriteLine("PlayerEnum X Wins!!!");
                    break;
                }

                // change to num

                PlayMove(2);
                playerOWins = CheckIfPlayerWins(2);

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
