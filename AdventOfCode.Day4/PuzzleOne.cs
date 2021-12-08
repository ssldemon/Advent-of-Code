using System;
namespace AdventOfCode.Day4;
public class PuzzleOne
{        
    public static void FinalAnswer()
    {
        List<string[,]> Boards = CommonBingoFunctions.PopulateBingCards();
        var pulls = CommonBingoFunctions.BingoBallPulls();
        bool test = true;
        int finalAnswer = 0;
        int pullCount = 0;

        while (test)
        {
            foreach (var board in Boards)
            {
                CommonBingoFunctions.PullBingoEntry(board, pulls[pullCount]);

                if (CommonBingoFunctions.CheckForWinner(board) == true)
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