using SortingAlgorithms;
using SortingAlgorithmsApp;
using SortingAlgorithmsApp.Comparers;

Console.WriteLine("1.Bubble Sort - Salary\n" +
    "2.Insertion Sort - FirstName\n" +
    "3.Merge Sort - LastName\n" +
    "4.Quick Sort - Salary\n");

Console.WriteLine("Seçiniz:");
string option = Console.ReadLine();
Sort(option);

static void Sort(string option)
{
    using (var context = new SortingAppDbContext())
    {
        var list = context.Employees.ToArray();

        switch (option)
        {
            case "1":
                BubbleSort.Sort(list, comparer: new CompareBySalary());
                foreach (var item in list) { Console.WriteLine(item); } break;

            case "2":
                InsertionSort.Sort(list, compare: new CompareByFirstName());
                foreach (var item in list) { Console.WriteLine(item); } break;

            case "3":
                MergeSort.Sort(list, comparer: new CompareByLastName());
                foreach (var item in list) { Console.WriteLine(item); }
                break;
            case "4":
                QuickSort.Sort(list, comparer: new CompareBySalary());
                foreach (var item in list) { Console.WriteLine(item); }
                break;

            default:
                break;
        }
    }
}

