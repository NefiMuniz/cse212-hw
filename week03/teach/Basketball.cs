/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row

        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            else
            {
                players[playerId] = points;
            }
        }

        var sortedPlayers = players.OrderByDescending(p => p.Value).ToList();

        Console.WriteLine("Top 10 Players by Points:");
        Console.WriteLine("Rank | Player ID      | Total Points");
        Console.WriteLine("-----------------------------------");

        for (int i = 0; i < Math.Min(10, sortedPlayers.Count); i++)
        {
            var (playerId, totalPoints) = sortedPlayers[i];
            Console.WriteLine($"{i + 1,4} | {playerId,-14} | {totalPoints,12}");
        }
    }
}