using System;

/// <summary>
/// LeetCode: Rotate String
/// </summary>
namespace CodingInterview.Rotate_String
{
	class RotateString
	{
		public static bool IsRotate(string s, string m)
		{
			if (s.Length != m.Length)
				return false;

			string d = s + s;
			return d.IndexOf(m) > -1;
		}
	}
}
