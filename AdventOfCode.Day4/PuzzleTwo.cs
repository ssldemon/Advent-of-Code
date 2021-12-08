using System;
namespace AdventOfCode.Day4;

public class PuzzleTwo
{
    public static void FinalAnswer()
    {
        List<string[,]> Boards = CommonBingoFunctions.PopulateBingCards();

        var pulls = CommonBingoFunctions.BingoBallPulls();
        int finalAnswer = 0;
        int winCount = 0;

        foreach (var board in Boards)
        {
            for (int i = 0; i < pulls.Count(); i++)
            {
                CommonBingoFunctions.PullBingoEntry(board, pulls[i]);

                if (CommonBingoFunctions.CheckForWinner(board) == true)
                {
                    if(i > winCount)
                    { 
                        winCount = i;
                        finalAnswer = CommonBingoFunctions.GetFinalNumbers(board) * Int32.Parse(pulls[i]);
                    }

                    break;
                }
            }
        }            

        Console.WriteLine($"{finalAnswer}");
    }
}