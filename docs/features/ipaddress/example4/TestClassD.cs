using IntelliDataSort;

namespace TestClassD
{
    class TestClassD
    {
        static void Mains(string[] args)
        {
            Console.WriteLine(
                "TEST 4: CLASS D IP ADDRESSES (224.0.0.0 to 239.255.255.255) - Multicast"
            );
            Console.WriteLine(
                "=======================================================================\n"
            );

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "224.0.0.1",
                "224.0.0.18",
                "239.255.255.250",
                "239.255.255.255",
                "230.0.0.1",
                "235.100.50.25",
                "224.0.1.1",
                "224.0.1.39",
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