using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenId
{
	/// <summary>Provides functionality for generating alpha-numeric ids of various lengths.</summary>
	public static class IdGenerator
	{
		#region Member Variables

		/// <summary>The default allowed characters.</summary>
		private static readonly List<char> _DefaultChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToList();

		/// <summary>The allowed characters.</summary>
		private static List<char> _AllowedChars = new List<char>(_DefaultChars);

		#endregion Member Variables

		#region Methods

		#region EnsureAllowedChars
		/// <summary>Ensures that the internal collection of allowable characters is valid for generation.</summary>
		private static void EnsureAllowedChars()
		{
			if (_AllowedChars == null || _AllowedChars.Count == 0)
			{
				_AllowedChars = new List<char>(_DefaultChars);
			}
		}
		#endregion EnsureAllowedChars

		#region Add
		/// <summary>Adds the specified characters to the list of allowed characters.</summary>
		/// <param name="chars">The characters to allow.</param>
		public static void Add(params char[] chars)
		{
			if (chars != null)
			{
				foreach (var c in chars)
				{
					if (!_AllowedChars.Contains(c))
					{
						_AllowedChars.Add(c);
					}
				}
			}
		}
		#endregion Add

		#region Remove
		/// <summary>Removes the specified characters from the list of allowed characters.</summary>
		/// <param name="chars">The characters to disallow.</param>
		public static void Remove(params char[] chars)
		{
			if (chars != null)
			{
				foreach (var c in chars)
				{
					if (_AllowedChars.Contains(c))
					{
						_AllowedChars.Remove(c);
					}
				}
			}
		}
		#endregion Remove

		#region Generate
		/// <summary>Generates an id with the specified length.</summary>
		/// <param name="length">The length of the id to generate.</param>
		/// <returns>A <see cref="string"/> with the newly generated id.</returns>
		public static string Generate(int length = 10)
		{
			EnsureAllowedChars();
			length = length < 5 ? 5 : length;

			var sb = new StringBuilder();
			while (sb.Length < length)
			{
				sb.Append(_AllowedChars.OrderBy(ac => Guid.NewGuid()).First());
			}
			return sb.ToString();
		}
		#endregion Generate

		#endregion Methods
	}
}
