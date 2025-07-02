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
        // PLAN:
        // Step 1: Create a new array of type double with the given 'length'.
        // Step 2: Loop from 0 to length - 1 using a for loop.
        // Step 3: For each index i, calculate the multiple: number * (i + 1).
        // Step 4: Store that value in the array at position i.
        // Step 5: After the loop ends, return the filled array.

        // IMPLEMENTATION:
        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // Step 1: Use GetRange to get the last 'amount' elements from the list.
        // Step 2: Use GetRange to get the remaining elements from the beginning up to (Count - amount).
        // Step 3: Clear the original list.
        // Step 4: Add the slice from Step 1 (end values) to the list.
        // Step 5: Add the slice from Step 2 (start values) to the list.

        // IMPLEMENTATION:
        List<int> rightPart = data.GetRange(data.Count - amount, amount);
        List<int> leftPart = data.GetRange(0, data.Count - amount);
        data.Clear();
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
