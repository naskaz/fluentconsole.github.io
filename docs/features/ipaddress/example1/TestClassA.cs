using IntelliDataSort;

namespace TestClassA
{
    class TestClassA
    {
        static void Mains(string[] args)
        {
            Console.WriteLine("TEST 1: CLASS A IP ADDRESSES (1.0.0.0 to 126.255.255.255)");
            Console.WriteLine("=========================================================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "10.0.0.1",
                "10.0.0.100",
                "10.0.1.1",
                "10.1.0.1",
                "10.255.255.255",
                "126.0.0.1",
                "126.255.255.255",
                "1.0.0.0",
            };

            Console.WriteLine("Input Data:");
            DisplayList(data);

            Console.WriteLine("\nAscending Sort:");
            var asc = sorter.Sort(
                data,
                HumanSort.ColumnType.IpAddress,
                true,
                HumanSort.NullHandling.NullsFirst,
                out _
            );
            DisplayList(asc);

            Console.WriteLine("\nDescending Sort:");
            var desc = sorter.Sort(
                data,
                HumanSort.ColumnType.IpAddress,
                false,
                HumanSort.NullHandling.NullsFirst,
                out _
            );
            DisplayList(desc);

            Console.WriteLine("\n=== TEST COMPLETED ===");
        }

        static void DisplayList(IReadOnlyList<string> list)
        {
            foreach (var item in list)
                Console.WriteLine($"  {item}");
        }
    }
}
