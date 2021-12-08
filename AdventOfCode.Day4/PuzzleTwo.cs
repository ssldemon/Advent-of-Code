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

            foreach (var board in Boards)
            {
                for (int i = 0; i < pulls.Count(); i++)
                {
                    bingoFunctions.PullBingoEntry(board, pulls[i]);

                    if (bingoFunctions.CheckForWinner(board) == true)
                    {
                        if(i > winCount)
                        { 
                            winCount = i;
                            finalAnswer = bingoFunctions.GetFinalNumbers(board) * Int32.Parse(pulls[i]);
                        }

                        break;
                    }
                }
            }            

            Console.WriteLine($"{finalAnswer}");
        }

       
    }
}