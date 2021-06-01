using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonValidator
{
	public class PolygonSerializer
	{
		private const string POLYGON = "\"POLYGON (({0}))\",{1},{2},{3},{4},{5},{6}\n";
		private string basicFormat = $"{Polygon.Id}{{0}}\n{Polygon.NamePrefix}{{1}}\n{Polygon.AverageDepthPrefix}{{2}}\n{Polygon.CoastlinePrefix}{{3}}\n{Polygon.SquarePrefix}{{4}}\n{Polygon.SizePrefix}{{5}}\n{{6}}\n\n\n";
		private string qgisHeader = $"WKT,id,Название,Ср гл (м),Бр л (км),Площ (км2),\"Размер, км\"\n";

		public string BasicFormat => basicFormat;
		public string QGISFormat { get; set; }

		public PolygonSerializer()
		{
		}

		public bool SavePolygons(string filename, List<Polygon> polygons)
		{
			StringBuilder polygonsData = new StringBuilder();
			int i = 1;

			polygons.ForEach(polygon =>
			{
				StringBuilder pointsData = new StringBuilder();
				polygon.Points.ForEach(point => pointsData.AppendLine(FormattableString.Invariant($"{point.Lat}\t{point.Lng}")));

				polygonsData.Append(string.Format(
					basicFormat,
					i++,
					polygon.Name,
					polygon.AverageDepth,
					polygon.Coastline,
					polygon.Square,
					polygon.Size,
					pointsData.ToString()));
			});

			File.WriteAllText(filename, polygonsData.ToString());

			return true;
		}

		public bool SavePolygonsAsQGIS(string filename, List<Polygon> polygons)
		{
			StringBuilder polygonsData = new StringBuilder(qgisHeader);
			int i = 1;

			polygons.ForEach(polygon =>
			{
				StringBuilder pointsData = new StringBuilder();
				polygon.Points.ForEach(point => pointsData.Append(FormattableString.Invariant($"{point.Lat} {point.Lng},")));

				polygonsData.Append(string.Format(
					POLYGON,
					pointsData.ToString(),
					i++,
					polygon.Name,
					polygon.AverageDepth,
					polygon.Coastline,
					polygon.Square,
					polygon.Size));
			});

			File.WriteAllText(filename, polygonsData.ToString());

			return true;
		}
	}
}
