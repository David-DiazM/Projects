namespace AlgoExpertQuestions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { -2, -1 };
            SortedSquaredArray(array);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------//
        //Two Numbers Question

        //public static int[] TwoNumberSum(int[] array, int targetSum)
        //{
        //    // Write your code here.
        //    //iterate through array once
        //    for (int i = 0; i < array.Length - 1; i++)
        //    {
        //        //iterate through array again for second number
        //        for (int j = i + 1; j < array.Length; j++)
        //        {
        //            if (array[i] + array[j] == targetSum)
        //            {
        //                Console.WriteLine($"{array[i]}, {array[j]}");
        //            }
        //        }
        //    }
        //    return new int[0];
        //}

        //------------------------------------------------------------------------------------------------------------------------------------------//
        //Palindrome Detector

        //public static bool IsPalindrome(string str)
        //{
        //    char[] normal = str.ToCharArray();
        //    char[] reversed = str.ToCharArray();
        //    Array.Reverse(reversed);
        //    bool success = true;
        //    // Write your code here.
        //    for (int i = 0; i < normal.Length; i++)
        //    {
        //        if(!normal[i].Equals(reversed[i]))
        //        {
        //            success = false;
        //        }
        //    }
        //    Console.WriteLine(success);
        //    return success;
        //}

        //------------------------------------------------------------------------------------------------------------------------------------------//
        //Sequence Checker

        //public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        //{
        //    // Write your code here.
        //    var position = 0;
        //    var counter = 0;

        //    foreach(var item in array )
        //    {
        //        if (item == sequence[position])
        //        {
        //            counter++;
        //            if(position < sequence.Count - 1)
        //            {
        //                position++;
        //            }
        //            if(counter == sequence.Count)
        //            {
        //                break;
        //            }
        //        }
        //    }
        //    Console.WriteLine(counter == sequence.Count);
        //    return counter == sequence.Count;
        //}

        //------------------------------------------------------------------------------------------------------------------------------------------//
        //Sorted Square Array

        //public static int[] SortedSquaredArray(int[] array)
        //{
        //    // Write your code here.
        //    List<int> temp = new List<int>();

        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        temp.Add(array[i] * array[i]);
        //    }
        //    int[] answer = temp.ToArray();

        //    Array.Sort(answer);
        //    return answer;
        //}
    }
}