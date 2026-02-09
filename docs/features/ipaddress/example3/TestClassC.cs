using IntelliDataSort;

namespace TestClassC
{
    class TestClassC
    {
        static void Mains(string[] args)
        {
            Console.WriteLine("TEST 3: CLASS C IP ADDRESSES (192.0.0.0 to 223.255.255.255)");
            Console.WriteLine("===========================================================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "192.0.0.1",
                "192.168.0.1",
                "192.168.1.1",
                "192.168.10.1",
                "192.168.100.1",
                "192.168.255.255",
                "223.255.255.254",
                "223.255.255.255",
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
