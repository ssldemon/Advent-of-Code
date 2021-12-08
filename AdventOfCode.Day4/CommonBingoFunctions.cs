using System;
namespace AdventOfCode.Day4;
public class CommonBingoFunctions
{
    public static List<string[,]> PopulateBingCards()
    {
        string[] file = System.IO.File.ReadAllLines(@"Bingo.txt");

        var bingoPulls = file[0];
        var bingoCards = file.Skip(2).Where(val => !string.IsNullOrEmpty(val));
        string[,] bingoBoard = new string[5, 5];
        var bingoCardsTotal = bingoCards.Count() / 5;
        var BingoBoardList = new List<string[,]>();

        var allLines = file.Where(val => !string.IsNullOrEmpty(val));
        var i = 0;
        while (BingoBoardList.Count() < bingoCardsTotal)
        {
            string[,] _ = new string[5, 5];

            for (var col = 0; col < _.GetLength(0); col++)
            {
                for (var row = 0; row < _.GetLength(1); row++)
                {
                    var elements = bingoCards.ElementAt(i).Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (elements.Count() > 0)
                        _[row, col] = elements[row];
                }
                i++;
            }
            BingoBoardList.Add(_);
        }

        return BingoBoardList;
    }

    public static List<string> BingoBallPulls()
    {
        string[] file = System.IO.File.ReadAllLines(@"Bingo.txt");

        var bingoPulls = file[0];
        var test = bingoPulls.Split(",");
        List<string> BingoPullsFinal = test.ToList<string>();
            
        return BingoPullsFinal;
    }

    public static string[,] PullBingoEntry(string[,] card, string numberToRemove)
    {
        List<int> index = new();

        for(int col = 0; col < card.GetLength(0); col++)
        {
            for (int row = 0; row < card.GetLength(1); row++)
            {
                if (card[row, col] == numberToRemove)
                {
                    card.SetValue("x", row, col);
                }
            }
        }

        return card;
    }

    public static bool CheckForWinner(string[,] card)
    {
        for (int i = 0; i <= 4; i++)
        {
            List<string> row = new();
            List<string> column = new();

            foreach (int rowCount in Enumerable.Range(0, 5))
            {
                row.Add(card[rowCount, i]);
            }

            if (row.TrueForAll(x => x == "x")) return true;

            foreach (int columnCount in Enumerable.Range(0, 5))
            {
                column.Add(card[i, columnCount]);
            }

            if (column.TrueForAll(x => x == "x")) return true;
        }
            
        return false;
    }

    public static void BingoPrint(string[,] card)
    {
        Console.WriteLine();
        for (int col = 0; col < card.GetLength(0); col++)
        {
            for (int row = 0; row < card.GetLength(1); row++)
            {
                if (card[row, col].Length < 2)
                    Console.Write(" " + card[row, col] + "  ");
                else
                    Console.Write(card[row, col] + "  ");
            }
            Console.WriteLine();
        }
    }

    public static int GetFinalNumbers(string[,] board)
    {
        int numbers = 0;

        foreach (var entry in board)
        {
            if (entry != "x") numbers += Int32.Parse(entry);
        }

        return numbers;
    }

}