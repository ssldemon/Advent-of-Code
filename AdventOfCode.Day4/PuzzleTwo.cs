using System;
namespace AdventOfCode.Day4
{
    public class PuzzleTwo
    {
        CommonBingoFunctions bingoFunctions = new();

        public void FinalAnswer()
        {
            
            List<string[,]> Boards = bingoFunctions.PopulateBingCards();

            var pulls = bingoFunctions.BingoBallPulls();
            int finalAnswer = 0;
            int winCount = 0;
            int boardWinOn = 0;

            foreach (var board in Boards)
            {
                for (int i = 0; i < pulls.Count(); i++)
                {
                    bingoFunctions.PullBingoEntry(board, pulls[i]);

                    if (bingoFunctions.CheckForWinner(board) == true)
                    {
                        boardWinOn = i;
                        if(boardWinOn > winCount)
                        { 
                            winCount = boardWinOn;
                            boardWinOn = 0;
                            finalAnswer = getNumbers(board) * Int32.Parse(pulls[i]);
                        }

                        break;
                    }
                }
            }            

            Console.WriteLine($"Actual final answer: {finalAnswer}");
        }

        private int getNumbers(string[,] board)
        {
            int numbers = 0;

            foreach (var entry in board)
            {
                if (entry != "x") numbers += Int32.Parse(entry);
            }

            return numbers;
        }
    }
}