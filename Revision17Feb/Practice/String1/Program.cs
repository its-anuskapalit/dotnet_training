using System;
class Program
{
    public static string Reverse(string input)
    {
        string result = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            result += input[i];
        }
        return result;

    }
    public static void CountLetters(string input)
    {
        int vowel = 0;
        int con = 0;
        string vowels = "AEIOUaeiou";
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLetter(input[i]))
            {
                if (vowels.Contains(input[i]))
                {
                    vowel++;
                }
                else
                {
                    con++;
                }
            }

        }
    }
    public static bool IsPalindrome(string input)
    {
        input = input.Replace(" ", "").ToLower();
        string result = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            result += input[i];
        }
        bool outp = false;
        if (result == input)
        {
            outp = true;
        }
        return outp;
    }
    public static string RemoveDuplicate(string input)
    {
        HashSet<char> result = new HashSet<char>();
        string resultS = "";
        foreach (char c in input)
        {
            if (!result.Contains(c))
            {
                result.Add(c);
                resultS += c;
            }
        }
        return resultS;
    }
    public static char FirstNonRepeating(string input)
    {
        // TODO:
        // 1. Count frequency of each character
        // 2. Loop again and return first char with count 1
        // 3. If none found return '\0'
        Dictionary<char, int> result = new Dictionary<int, char>();
        foreach (char i in input)
        {
            if (!result.ContainsKey(i))
            {
                result[i] = 1;
            }
            else
            {
                result[i]++;
            }
        }
        foreach (char c in input)
        {
            if (result[c] == 1)
            {
                return c;
            }
        }
        return '\0';
    }
    public static Dictionary<char, int> GetFrequency(string input)
    {
        // TODO:
        // 1. Create Dictionary<char,int>
        // 2. Traverse string
        // 3. Increase count properly
        // 4. Return dictionary
        Dictionary<char, int> result = new Dictionary<char, int>();
        foreach (char c in input)
        {
            if (!result.ContainsKey(c))
            {
                result[c] = 1;
            }
            else
            {
                result[c]++;
            }
        }
        return result;
    }
    public static string LongestWord(string sentence)
    {
        // TODO:
        // 1. Remove punctuation if needed
        // 2. Split by space
        // 3. Compare length
        // 4. Return longest word
        string[] input = sentence.Split(" ");
        int max = input[0].Length;
        string output = input[0];
        foreach (string i in input)
        {
            if (max < i.Length)
            {
                max = i.Length;
                output = i;
            }
        }
        return output;
    }
    public static string CapitalizeWords(string sentence)
    {
        // TODO:
        // 1. Split sentence
        // 2. Capitalize first letter
        // 3. Join back
        // 4. Return result
        string[] input = sentence.Split(" ");
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i].Length > 0)
            {
                input[i] = char.ToUpper(input[i][0]) + input[i].Substring(1);
            }
        }
        return string.Join(" ", input);
    }

    public static bool IsAnagram(string s1, string s2)
    {
        // TODO:
        // 1. Remove spaces
        // 2. Convert to lowercase
        // 3. Compare character counts
        // 4. Return true/false
        // s1.ToLower(s1).Replace(" ","");
        // s2=string.ToLower(s2).Replace(" ","");
        // char[] arr1=s1.ToCharArray();
        // char[] arr2=s2.ToCharArray();
        // Array.Sort(arr1);
        // Array.Sort(arr2);
        // return new string(arr1)==new string(arr2);

        s1 = s1.Replace(" ", "").ToLower();
        s2 = s2.Replace(" ", "").ToLower();
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach (char c in s1)
        {
            if (!dict.ContainsKey(c))
            {
                dict[c] = 1;
            }
            else
            {
                dict[c]++;
            }
        }
        foreach (char c in s2)
        {
            if (!dict.ContainsKey(c))
            {
                return false;
            }
            else
            {
                dict[c]--;
            }
            if (dict[c] < 0)
            {
                return false;
            }
        }
        return true;

    }
    public static string CompressString(string input)
    {
        // TODO:
        // Example: aaabbc → a3b2c1
        // 1. Traverse string
        // 2. Count consecutive characters
        // 3. Append char + count
        // 4. Return compressed string
        if (input == "")
        {
            return "";
        }
        string result = "";
        int count = 1;
        for (int i = 0; i < input.Length - 1; i++)
        {
            if (input[i] == input[i + 1])
            {
                count++;
            }
            else
            {
                result += input[i] + count.ToString();
                count = 1;
            }
        }
        result += input[input.Length - 1] + count.ToString();
        return result;


    }
    public static int LongestUniqueSubstring(string input)
    {
    // TODO:
    // 1. Use sliding window technique
    // 2. Track seen characters
    // 3. Update max length
    // 4. Return max length
        int max=0;
        for(int i=0;i< input.Length; i++)
        {
            string temp="";
            for(int j = i; j < input.Length; j++)
            {
                if (temp.Contains(input[j]))
                {
                    break;
                }
                temp+=input[j];
            }
            if(max< temp.Length)
            {
                max=temp.Length;  
            }
        }
        return max;

    }   
}

