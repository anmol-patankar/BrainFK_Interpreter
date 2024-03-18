using System.Reflection.Metadata.Ecma335;

namespace MyProject;
class Program
{
    static void Main()
    {
        string TextOut() => ("+\tIncrement the byte at the data pointer.\r\n-\tDecrement the byte at the data pointer.\r\n>\tIncrement the data pointer.\r\n<\tDecrement the data pointer.\r\n.\tOutput the byte at the data pointer (ASCII format)\r\n,\tAccept one byte of input (ASCII format), storing its value in the byte at the data pointer.\r\n[\tIf the byte at the data pointer is zero jump it forward to the command after the matching ] command.\r\n]\tIf the byte at the data pointer is nonzero jump it back to the command after the matching [ command.");

        long memoryLength = 30000;
        byte[] data = new byte[memoryLength];
        uint dataPointer = 0;
        char currentInput;
        string program=Console.ReadLine();
        int count = 0;
        bool toContinue = true;
        while (toContinue)
        {
            currentInput = program[count];
            switch (currentInput)
            {
                case '+':
                    data[dataPointer]++;
                    break;
                case '-':
                    data[dataPointer]--;
                    break;
                case '>':
                    dataPointer++;
                    break;
                case '<':
                    dataPointer--;
                    break;
                case '.':
                    Console.WriteLine((char)data[dataPointer]);
                    break;
                case ',':
                    data[dataPointer]=(byte)Char.Parse(Console.ReadLine());
                    break;
                case '[':
                    //TODO
                    break;
                case ']':
                    //TODO
                    break;
                case 'e':
                    toContinue=false;
                    break;
                default:
                    break;
            }
            count++;
            //Console.WriteLine(TextOut());
        }

    }
}