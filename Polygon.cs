using GMap.NET;
using System.Collections.Generic;

namespace PolygonValidator
{
	public class Polygon
	{
		public const string Id = "id: ";
		public const string NamePrefix = "Name: ";
		public const string AverageDepthPrefix = "s gl: ";
		public const string CoastlinePrefix = "br l: ";
		public const string SquarePrefix = "s: ";
		public const string SizePrefix = "raz: ";

		public string Name { get; set; }

		public string AverageDepth { get; set; }

		public string Coastline { get; set; }

		public string Square { get; set; }

		public string Size { get; set; }

		public List<PointLatLng> Points { get; set; }

		public static string GetValueFromString(string key, string input)
		{
			int index = input.IndexOf(key);
			string cleanPath = (index < 0)
				? input
				: input.Remove(index, key.Length);

			return cleanPath;
		}
	}
}
