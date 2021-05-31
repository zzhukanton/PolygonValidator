using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonValidator
{
	public class PolygonSerializer
	{
		private const string POLYGON = "\"POLYGON (({0}))\"";
		private string basicFormat = $"{Polygon.Id}{{0}}\n{Polygon.NamePrefix}{{1}}\n{Polygon.AverageDepthPrefix}{{2}}\n{Polygon.CoastlinePrefix}{{3}}\n{Polygon.SquarePrefix}{{4}}\n{Polygon.SizePrefix}{{5}}\n{{6}}\n\n\n";
		private string qgisFormat = $"WKT,id,Название,Ср гл (м),Бр л (км),Площ (км2),\"Размер, км\"";

		public string BasicFormat => basicFormat;

		public PolygonSerializer()
		{
		}

		public bool SavePolygons(string filename, List<Polygon> polygons)
		{


			return true;
		}

		public bool SavePolygonsAsQGIS(string filename, List<Polygon> polygons)
		{

			return true;
		}
	}
}
