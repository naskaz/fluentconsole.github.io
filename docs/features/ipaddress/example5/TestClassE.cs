using IntelliDataSort;

namespace TestClassE
{
    class TestClassE
    {
        static void Mains(string[] args)
        {
            Console.WriteLine(
                "TEST 5: CLASS E IP ADDRESSES (240.0.0.0 to 255.255.255.255) - Reserved"
            );
            Console.WriteLine(
                "========================================================================\n"
            );

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "240.0.0.1",
                "240.0.0.255",
                "255.255.255.254",
                "255.255.255.255",
                "245.100.50.25",
                "250.200.150.100",
                "240.255.255.255",
                "255.0.0.0",
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