
namespace NumberParserOWASPSecurityTest
{
	class NumberParserOWASPSecurityTest
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=== NUMBER PARSER SECURITY TEST (OWASP-style) ===\n");
			var sorter = new HumanSort();

			// Define test categories
			RunCategory(sorter, GetValidNumbers(), "Valid Numbers", shouldBeAccepted: true);
			RunCategory(sorter, GetSqlInjection(), "SQL Injection", shouldBeAccepted: false);
			RunCategory(sorter, GetXssAttacks(), "XSS / Script Attacks", shouldBeAccepted: false);
			RunCategory(sorter, GetHtmlXml(), "HTML/XML", shouldBeAccepted: false);
			RunCategory(sorter, GetBase64Payloads(), "Base64 Payloads", shouldBeAccepted: false);
			RunCategory(sorter, GetUrlEncodedAttacks(), "URL-Encoded Attacks", shouldBeAccepted: false);
			RunCategory(sorter, GetControlUnicode(), "Control/Invisible Unicode", shouldBeAccepted: false);
			RunCategory(sorter, GetExtremeLength(), "Extreme Length", shouldBeAccepted: false);
			RunCategory(sorter, GetStructuredData(), "Structured Data Fragments", shouldBeAccepted: false);
			RunCategory(sorter, GetMixedMalicious(), "Mixed Malicious Patterns", shouldBeAccepted: false);

			Console.WriteLine("\n=== SECURITY TEST COMPLETED ===");
		}

		static void RunCategory(HumanSort sorter, List<string> inputs, string name, bool shouldBeAccepted)
		{
			Console.WriteLine($"CATEGORY: {name}");
			Console.WriteLine(new string('-', 40));

			int accepted = 0;
			int rejected = 0;

			foreach (var input in inputs)
			{
				bool isAccepted = IsAcceptedAsNumber(sorter, input);
				if (isAccepted) accepted++; else rejected++;

				string status = isAccepted ? "ACCEPTED" : "REJECTED";
				Console.WriteLine($"{status}: {Truncate(input, 50)}");
			}

			Console.WriteLine($"→ Accepted: {accepted}, Rejected: {rejected}");

			if (shouldBeAccepted)
			{
				if (accepted == inputs.Count)
					Console.WriteLine("✅ All valid numbers accepted.");
				else
					Console.WriteLine($"❌ {inputs.Count - accepted} valid numbers were rejected!");
			}
			else
			{
				if (rejected == inputs.Count)
					Console.WriteLine("✅ All malicious inputs correctly rejected.");
				else
					Console.WriteLine($"❌ {accepted} malicious inputs were incorrectly ACCEPTED! ⚠️ SECURITY RISK");
			}

			Console.WriteLine();
		}

		static bool IsAcceptedAsNumber(HumanSort sorter, string input)
		{
			try
			{
				var result = sorter.Sort(
						new List<string> { input },
						HumanSort.ColumnType.Number,
						ascending: true,
						nullHandling: HumanSort.NullHandling.NullsFirst,
						out var parsedList
				);

				return parsedList != null &&
							 parsedList.Count > 0 &&
							 parsedList[0].parsed != null;
			}
			catch
			{
				// Any exception → treat as rejection
				return false;
			}
		}

		static string Truncate(string s, int maxLength)
		{
			if (string.IsNullOrEmpty(s) || s.Length <= maxLength) return s;
			return s.Substring(0, maxLength - 3) + "...";
		}

		// ===== VALID NUMBERS (should be ACCEPTED) =====
		static List<string> GetValidNumbers() => new()
				{
						"123", "-456", "789.01", "0", "0.0",
						"1.23e5", "-4.56e-3",
						"0xFF", "0b1010", "0o755",
						"1,234", "1 234",
						"(123)", "+456",
						"  123  ", "999999999999999"
				};

		// ===== MALICIOUS INPUTS (should be REJECTED) =====

		static List<string> GetSqlInjection() => new()
				{
						"123; DROP TABLE users",
						"456 OR 1=1",
						"789' OR '1'='1",
						"SELECT * FROM users",
						"123 UNION SELECT * FROM users",
						"123); DELETE FROM users",
						"456' OR username LIKE '%admin%",
						"1 AND SLEEP(5)",
						"123; UPDATE users SET password='hacked'"
				};

		static List<string> GetXssAttacks() => new()
				{
						"123<script>alert('xss')</script>",
						"<script>alert(456)</script>",
						"789 onload=alert('xss')",
						"javascript:alert('123')",
						"123\"><script>alert('xss')</script>",
						"<img src=x onerror=alert('456')>",
						"789\" onmouseover=\"alert('xss')\"",
						"123'+alert('xss')+'",
						"eval('alert(456)')"
				};

		static List<string> GetHtmlXml() => new()
				{
						"123<div>content</div>",
						"<xml>456</xml>",
						"789<![CDATA[ content ]]>",
						"<svg onload=alert(1)>",
						"123<!-- comment -->",
						"<?xml version=\"1.0\"?>",
						"<!DOCTYPE html>",
						"456<style>body{color:red}</style>"
				};

		static List<string> GetBase64Payloads() => new()
				{
						"MTIzPHNjcmlwdD5hbGVydCgneHNzJyk8L3NjcmlwdD4=",
						"NDU2IE9SIDE9MQ==",
						"Nzg5JTIwU0VMRUNUJTIwKiUyMEZST00lMjB1c2Vycw==",
						"c2VsZWN0ICogZnJvbSB1c2Vycw==",
						"PGltZyBzcmM9eCBvbmVycm9yPWFsZXJ0KDEpPg=="
				};

		static List<string> GetUrlEncodedAttacks() => new()
				{
						"123%3B%20DROP%20TABLE%20users",
						"456%27%20OR%20%271%27%3D%271",
						"%3Cscript%3Ealert%28789%29%3C%2Fscript%3E",
						"javascript%3Aalert%28%27123%27%29",
						"123%22%3E%3Cscript%3Ealert%28%27xss%27%29%3C%2Fscript%3E"
				};

		static List<string> GetControlUnicode() => new()
				{
						"123\u0000null_terminated",
						"456\u202Eright-to-left_override",
						"789\uFEFFzero_width_no-break_space",
						"\u200B123zero_width_space",
						"456\u200Czero_width_non-joiner"
				};

		static List<string> GetExtremeLength() => new()
				{
						new string('1', 1000) + " AND 1=1",
						new string('9', 500) + "<script>alert('xss')</script>" + new string('9', 500),
						new string('A', 2000),
						new string('1', 500) + ";" + new string('2', 500)
				};

		static List<string> GetStructuredData() => new()
				{
						"123 {\"key\": \"value\"}",
						"456 <user><id>1</id></user>",
						"789 [1,2,3,4,5]",
						"123 {key: 'value'}",
						"456 <?xml?><data>malicious</data>"
				};

		static List<string> GetMixedMalicious() => new()
				{
						"123';--",
						"456 OR '1'='1' --",
						"789) UNION SELECT null,null--",
						"123\"><svg/onload=alert(1)>",
						"456'+AND+1=0+UNION+SELECT+'admin','hash'--",
						"123; EXEC xp_cmdshell('format C:')"
				};
	}
}


