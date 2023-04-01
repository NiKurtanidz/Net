namespace FirstHW;
class Program
{
    static void Main(string[] args)
    {
        bool rerun = true;
        string inputNumbers = "no input";
        while (rerun)
        {
            Console.WriteLine("Please enter 10 integers separated by space: ");
            inputNumbers = Console.ReadLine();
            checkInputs(inputNumbers, out rerun);
        }

        int[] arr = FillArr(inputNumbers);

        arr = SortArr(arr);
        PrintDifference(arr[0], arr[9]);
        PrintOnlySomeElements(arr);
        SumOfAllElements(arr);
    }

    public static void checkInputs(string input, out bool rerun)
    {
       
        rerun = false;
        string[] tempArr = input.Split(" ");
        if(tempArr.Length != 10) {
            rerun = true;
            Console.WriteLine("Please enter exactly 10 numbers and separate by space \" \"." );
        }
        int number;
        foreach(string arrElement in tempArr)
        {
            bool isInt = Int32.TryParse(arrElement, out number);
            if (!isInt)
            {
                rerun = true;
                Console.WriteLine("Please enter only integers");
            }
        }
        Console.WriteLine();
    }

    public static int[] FillArr(string numbers)
    {
        int i = 0;
        int[] arr = new int[10];

        foreach (string number in numbers.Split(" "))
        {
            arr[i] = Int32.Parse(number);
            i++;
        }
        return arr;
    }

    static int[] SortArr(int[] arr)
    {
        int temp;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if (arr[j + 1] < arr[j])
                {
                    temp = arr[j + 1]; 
                    arr[j + 1] = arr[j]; 
                    arr[j] = temp; 
                }
            }
        }

        return arr;
    }

    static void PrintDifference(int min, int max)
    {
        Console.WriteLine($"Difference between min and max elements of the array is {(max - min)}");
    }

    static void PrintOnlySomeElements(int[] arr)
    {
        foreach(int element in arr){
            if(element % 6 == 0 || element % 2 == 1)
            {
                Console.Write(element + " ");
            }
        }
        Console.WriteLine();
    }

    static void SumOfAllElements(int[] arr)
    {
        int sum = 0;
        foreach(int ele in arr)
        {
            sum += ele;
        }
        Console.WriteLine($"Sum of all elements is {sum}");
    }
}

