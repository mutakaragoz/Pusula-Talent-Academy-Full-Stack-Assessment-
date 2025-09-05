using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System.Text;


    public static string LongestVowelSubsequenceAsJson(List<string> words)
    {
        if (words == null || words.Count == 0)
        {
            return "[]";
        }


        var output = new List<object>();

        for (int i = 0; i < words.Count; i++)
        {
            StringBuilder currentSubseq = new StringBuilder();
            StringBuilder maxSubseq = new StringBuilder();
            int maxWovel = 0;
            foreach (char character in words[i])
            {
                if (character == 'a' || character == 'e' || character == 'i' || character == 'o' || character == 'u')

                {
                    currentSubseq.Append(character);
                }
                else
                {
                    if (currentSubseq.Length > maxSubseq.Length)
                    {
                        maxSubseq.Clear();
                        maxSubseq.Append(currentSubseq);
                        maxWovel = maxSubseq.Length;
                    }

                    currentSubseq.Clear();
                }
            }
            if (currentSubseq.Length > maxSubseq.Length)
            {
                maxSubseq.Clear();
                maxSubseq.Append(currentSubseq);
                maxWovel = maxSubseq.Length;
            }
            output.Add(new { word = words[i], sequence = maxSubseq.ToString(), length = maxSubseq.Length });
        }
        return JsonSerializer.Serialize(output);
    }



