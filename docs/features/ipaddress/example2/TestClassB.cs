using IntelliDataSort;

namespace TestClassB
{
    class TestClassB
    {
        static void Mains(string[] args)
        {
            Console.WriteLine("TEST 2: CLASS B IP ADDRESSES (128.0.0.0 to 191.255.255.255)");
            Console.WriteLine("===========================================================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "128.0.0.1",
                "128.0.255.255",
                "172.16.0.1",
                "172.16.255.255",
                "172.31.255.255",
                "191.255.0.1",
                "191.255.255.255",
                "172.20.10.1",
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