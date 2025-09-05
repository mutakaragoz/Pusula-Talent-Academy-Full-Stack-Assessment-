using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

    public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
    {
        
        if (numbers == null || numbers.Count == 0)
        {
            return "[]"; 
        }

        List<int> maxSubArray = new List<int>();
        int maxSum = int.MinValue;

        List<int> currentSubArray = new List<int>();
        int currentSum = 0;

        foreach (int number in numbers)
        {
            if (currentSubArray.Count == 0 || number > currentSubArray.Last())
            {
                currentSubArray.Add(number);
                currentSum += number;
            }
            else
            {
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSubArray = new List<int>(currentSubArray);
                }
                currentSubArray.Clear();
                currentSubArray.Add(number);
                currentSum = number;
            }
        }

    if (currentSum > maxSum)
    {
        maxSubArray = new List<int>(currentSubArray);
    }

    return JsonSerializer.Serialize(maxSubArray);
    }
