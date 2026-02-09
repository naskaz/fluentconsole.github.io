using IntelliDataSort;

namespace TestAllClassesMixed
{
    class TestAllClassesMixed
    {
        static void Mains(string[] args)
        {
            Console.WriteLine("TEST 6: ALL IP CLASSES MIXED");
            Console.WriteLine("============================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                // Class A
                "10.0.0.1",
                "126.255.255.255",
                // Class B
                "128.0.0.1",
                "172.16.0.1",
                "191.255.255.255",
                // Class C
                "192.168.0.1",
                "192.168.1.1",
                "223.255.255.255",
                // Class D
                "224.0.0.1",
                "239.255.255.255",
                // Class E
                "240.0.0.1",
                "255.255.255.255",
                // Special IPs
                "0.0.0.0",
                "127.0.0.1",
                "169.254.0.1",
                "192.0.2.1",
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