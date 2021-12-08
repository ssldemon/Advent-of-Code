using System;
namespace AdventOfCode.Day4
{
    public class PuzzleOne
    {
        CommonBingoFunctions bingoFunctions = new CommonBingoFunctions();
        
        public void FinalAnswer()
        {
            List<string[,]> Boards = bingoFunctions.PopulateBingCards();
            var pulls = bingoFunctions.BingoBallPulls();
            bool test = true;
            int finalAnswer = 0;
            int pullCount = 0;

            while (test)
            {
                foreach (var board in Boards)
                {
                    bingoFunctions.PullBingoEntry(board, pulls[pullCount]);

                    if (bingoFunctions.CheckForWinner(board) == true)
                    {
                        foreach (var entry in board)
                        {
                            if (entry != "x") finalAnswer += Int32.Parse(entry);
                        }
                        finalAnswer = finalAnswer * Int32.Parse(pulls[pullCount]);
                        test = false;
                        Console.WriteLine($"{finalAnswer}");
                        break;
                    }
                }
                pullCount++;
            }
        }
    }
}