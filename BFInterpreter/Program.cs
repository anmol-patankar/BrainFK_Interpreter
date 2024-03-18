namespace MyProject;
class Program
{
    static void Main()
    {
        const long memoryLength = 30000;
        byte[] tape = new byte[memoryLength];
        uint pointer = 0;
        char currentInput;
        string program = "+++++++++++>+>>>>++++++++++++++++++++++++++++++++++++++++++++>++++++++++++++++++++++++++++++++<<<<<<[>[>>>>>>+>+<<<<<<<-]>>>>>>>[<<<<<<<+>>>>>>>-]<[>++++++++++[-<-[>>+>+<<<-]>>>[<<<+>>>-]+<[>[-]<[-]]>[<<[>>>+<<<-]>>[-]]<<]>>>[>>+>+<<<-]>>>[<<<+>>>-]+<[>[-]<[-]]>[<<+>>[-]]<<<<<<<]>>>>>[++++++++++++++++++++++++++++++++++++++++++++++++.[-]]++++++++++<[->-<]>++++++++++++++++++++++++++++++++++++++++++++++++.[-]<<<<<<<<<<<<[>>>+>+<<<<-]>>>>[<<<<+>>>>-]<-[>>.>.<<<[-]]<<[>>+>+<<<-]>>>[<<<+>>>-]<<[<+>-]>[<+>-]<<<-]";
        int i = 0;
        int bracketCount = 0;
        while (i < program.Length)
        {
            char c = program[i];
            switch (c)
            {
                case '+':
                    tape[pointer]++;
                    break;
                case '-':
                    tape[pointer]--;
                    break;
                case '>':
                    pointer++;
                    break;
                case '<':
                    pointer--;
                    break;
                case '.':
                    Console.Write((char)tape[pointer]);
                    break;
                case ',':
                    tape[pointer] = (byte)Char.Parse(Console.ReadLine());
                    break;
                case '[':
                    if (tape[pointer] == 0)
                    {
                        bracketCount++;
                        while (program[i] != ']' || bracketCount != 0)
                        {
                            i++;
                            if (program[i] == '[') bracketCount++;
                            else if (program[i] == ']') bracketCount--;
                        }
                    }
                    break;
                case ']':
                    if (tape[pointer] != 0)
                    {
                        bracketCount++;
                        while (program[i] != '[' || bracketCount != 0)
                        {
                            i--;
                            //Console.WriteLine(i+" "+ tape[pointer]);
                            if (program[i] == ']') bracketCount++;
                            else if (program[i] == '[') bracketCount--;
                        }
                    }
                    break;
            }
            i++;
        }
    }
}