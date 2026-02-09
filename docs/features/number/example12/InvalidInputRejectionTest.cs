
namespace InvalidInputRejectionTest
{
	class InvalidInputRejectionTest
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=== INVALID INPUT REJECTION TEST ===\n");
			var sorter = new HumanSort();

			// Run all categories
			RunCategory(sorter, GetCurrencyTestCases(), "Currency Symbols and Codes");
			RunCategory(sorter, GetPercentageTestCases(), "Percentages");
			RunCategory(sorter, GetFileSizeTestCases(), "File Sizes");
			RunCategory(sorter, GetVersionTestCases(), "Version Numbers");
			RunCategory(sorter, GetDateTestCases(), "Dates");
			RunCategory(sorter, GetIpAddressTestCases(), "IP Addresses");
			RunCategory(sorter, GetInvalidScientificTestCases(), "Invalid Scientific Notation");
			RunCategory(sorter, GetInvalidBaseNumberTestCases(), "Invalid Base Numbers");

			// Valid numbers should be accepted
			RunCategory(sorter, GetValidNumberTestCases(), "Valid Numbers", shouldAccept: true);

			Console.WriteLine("\n=== TEST COMPLETED ===");
		}

		static void RunCategory(HumanSort sorter, List<string> inputs, string name, bool shouldAccept = false)
		{
			Console.WriteLine($"CATEGORY: {name}");
			Console.WriteLine(new string('-', 40));

			int accepted = 0;
			int rejected = 0;

			foreach (var input in inputs)
			{
				bool isAccepted = IsAccepted(sorter, input);
				if (isAccepted)
					accepted++;
				else
					rejected++;

				string status = isAccepted ? "ACCEPTED" : "REJECTED";
				Console.WriteLine($"{status}: {input}");
			}

			Console.WriteLine($"→ Accepted: {accepted}, Rejected: {rejected}");

			if (shouldAccept)
			{
				if (accepted == inputs.Count)
					Console.WriteLine("✅ All valid inputs accepted.");
				else
					Console.WriteLine($"❌ {inputs.Count - accepted} valid inputs were rejected!");
			}
			else
			{
				if (rejected == inputs.Count)
					Console.WriteLine("✅ All invalid inputs rejected.");
				else
					Console.WriteLine($"❌ {accepted} invalid inputs were incorrectly accepted!");
			}

			Console.WriteLine();
		}

		static bool IsAccepted(HumanSort sorter, string input)
		{
			try
			{
				var result = sorter.Sort(
						new List<string> { input },
						HumanSort.ColumnType.Number,
						true,
						null,
						out var parsedList
				);

				// Accepted if parsed value is non-null
				return parsedList != null &&
							 parsedList.Count > 0 &&
							 parsedList[0].parsed != null;
			}
			catch
			{
				// Any exception → treated as rejection
				return false;
			}
		}

		// --- Test Data (only input strings now) ---

		static List<string> GetCurrencyTestCases() => new()
				{
						"$100", "€50", "£75", "¥1000", "₹500", "₽1000",
						"100$", "50 €", "75£",
						"USD100", "100USD", "EUR50", "GBP75", "JPY1000", "INR500",
						"$100.50", "€50,00", "£1,000.50", "(€100)", "-$50", "+¥100",
						"$$100", "$ $100", "100USD50", "US100D", "$", "USD"
				};

		static List<string> GetPercentageTestCases() => new()
				{
						"50%", "25.5%", "100 %", "50percent", "25 pct", "10% ", " %50",
						"(50%)", "-25%", "+75%", "0%", "100.0%", "50%%", "50 % 50", "%", "percent"
				};

		static List<string> GetFileSizeTestCases() => new()
				{
						"10KB", "5MB", "1.5GB", "500 TB", "0.5MB", "1024KB",
						"1KiB", "2MiB", "10 KB", "5mb", "1GB ", "-10MB", "(5GB)",
						"10.5.5GB", "KB"
				};

		static List<string> GetVersionTestCases() => new()
				{
						"1.2.3", "v1.0", "2.5.1-beta", "3.4.5.6", "1.0.0-alpha+build",
						"2023.12.31", "1.2.3.4.5", "v2", "release-1.5", "1.2-rc1",
						"1.0.0.0", "0.0.1", "999.999.999", "1.2."
				};

		static List<string> GetDateTestCases() => new()
				{
						"2023-12-31", "12/31/2023", "31/12/2023", "2023/12/31",
						"Dec 31, 2023", "31-Dec-2023", "2023.12.31", "12-31-23",
						"31/12/23", "2023-W52", "2023-366", "23/12/31", "31/12", "12/2023"
				};

		static List<string> GetIpAddressTestCases() => new()
				{
						"192.168.1.1", "10.0.0.1", "255.255.255.255", "0.0.0.0",
						"127.0.0.1", "8.8.8.8", "1.1.1.1", "192.168.0.0",
						"192.168.1.255", "300.400.500.600", "192.168.1", "192.168.1.1.1",
						"192-168-1-1", "192.168.001.001", "abc.def.ghi.jkl"
				};

		static List<string> GetInvalidScientificTestCases() => new()
				{
						"1.23e", "e5", "1.23e5e6", "1.23e 5", "1.23e5.6",
						"1.23e-", "1.23e+", "e"
				};

		static List<string> GetInvalidBaseNumberTestCases() => new()
				{
						"0x", "0b", "0o", "0xGHIJ", "0b210", "0o89",
						"0x1.5", "0b1.1", "0o7.7", "0x 10", "0b 101", "0o 77",
						"x10", "b101", "o77", "0X", "0B", "0O"
				};

		static List<string> GetValidNumberTestCases() => new()
				{
						"100", "-50", "3.14159", "-2.71828", "0", "0.0",
						"1.23e5", "-4.56e-3", "0xFF", "0o77", "0b1010",
						"1,000", "1 000", ".5", "5.", "(123)", "+456"
				};
	}
}