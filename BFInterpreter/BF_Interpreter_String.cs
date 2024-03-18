using System;
public static class Kata
{
    public static string BrainLuck(string program, string input)
    {

        string ans = "";
        const long memoryLength = 5000;
        byte[] tape = new byte[memoryLength];
        uint tapePointer = 0;
        int currentCodePointer = 0;
        int inputStringPointer = 0;
        int bracketCount = 0;
        while (currentCodePointer < program.Length)
        {
            char c = program[currentCodePointer];
            switch (c)
            {
                case '+':
                    tape[tapePointer]++;
                    break;
                case '-':
                    tape[tapePointer]--;
                    break;
                case '>':
                    tapePointer++;
                    break;
                case '<':
                    tapePointer--;
                    break;
                case '.':
                    ans += ((char)tape[tapePointer]);
                    break;
                case ',':
                    tape[tapePointer] = (byte)input[inputStringPointer++];
                    break;
                case '[':
                    if (tape[tapePointer] == 0)
                    {
                        bracketCount++;
                        while (program[currentCodePointer] != ']' || bracketCount != 0)
                        {
                            currentCodePointer++;
                            if (program[currentCodePointer] == '[') bracketCount++;
                            else if (program[currentCodePointer] == ']') bracketCount--;
                        }
                    }
                    break;
                case ']':
                    if (tape[tapePointer] != 0)
                    {
                        bracketCount++;
                        while (program[currentCodePointer] != '[' || bracketCount != 0)
                        {
                            currentCodePointer--;
                            if (program[currentCodePointer] == ']') bracketCount++;
                            else if (program[currentCodePointer] == '[') bracketCount--;
                        }
                    }
                    break;
            }
            currentCodePointer++;
        }
        return ans;
    }
    static void Main()
    {
        Console.WriteLine(BrainLuck(",+[-.,+]", "Codewars"));
    }
}
