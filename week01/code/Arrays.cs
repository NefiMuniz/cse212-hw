using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // 1 A way to validate the inputs when the user provide it

        // 2 Create an array
        var multiples = new double[length];

        // 3 looping to calculate each multiple
        for (int i = 0; i < length; i++)
        {
            // calculation
            multiples[i] = number * (i + 1);
        }

        // 4 results
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // 1 Determine the effective rotation with modulo
        int rotation = amount % data.Count;

        // 2 Create a temp list to store rotated data
        var rotated = new List<int>(data.Count);

        // 3 Iterate and add the elements
        for (int i = data.Count - rotation; i < data.Count; i++)
        {
            rotated.Add(data[i]);
        }

        // 4 Add the remaining from original list to the rotated one
        for (int i = 0; i < data.Count - rotation; i++)
        {
            rotated.Add(data[i]);
        }

        // 5 Replace the original list with the rotated list elements
        for (int i = 0; i < data.Count; i++)
        {
            data[i] = rotated[i];
        }
    }
}
