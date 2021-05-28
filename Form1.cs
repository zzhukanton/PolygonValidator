﻿using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PolygonValidator
{
	public partial class MainForm : Form
	{
		private readonly List<Polygon> polygons;
		private readonly List<Polygon> updatedPolygons;

		private bool showIntersections;
		private List<GMapOverlay> markersOverlays;

		private const string HidePointsButtonText = "Скрыть точки самопересечений";
		private const string ShowPointsButtonText = "Показать точки самопересечений";



		public MainForm()
		{
			this.InitializeComponent();

			this.polygons = new List<Polygon>();
			this.updatedPolygons = new List<Polygon>();
			this.markersOverlays = new List<GMapOverlay>();
		}

		private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFile.ShowDialog();
		}

		private void openFile_FileOk(object sender, CancelEventArgs e)
		{
			this.ReadMapPolygon(openFile.FileName);
			this.DrawPolygons(this.polygons);
		}

		private void ReadMapPolygon(string fileName)
		{
			string[] polygonRawData = File.ReadAllText(fileName).Split(new[] { Polygon.Id }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < polygonRawData.Length; i++)
			{
				string[] allSinglePolygonData = polygonRawData[i].Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
				List<PointLatLng> polygonPoints = new List<PointLatLng>();

				for (int j = 6; j < allSinglePolygonData.Length; j++)
				{
					string[] coordinates = allSinglePolygonData[j].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
					polygonPoints.Add(new PointLatLng(
						double.Parse(coordinates[0], CultureInfo.InvariantCulture),
						double.Parse(coordinates[1], CultureInfo.InvariantCulture)));
				}

				this.polygons.Add(new Polygon
				{
					Name = Polygon.GetValueFromString(Polygon.NamePrefix, allSinglePolygonData[1]),
					AverageDepth = Polygon.GetValueFromString(Polygon.AverageDepthPrefix, allSinglePolygonData[2]),
					Coastline = Polygon.GetValueFromString(Polygon.CoastlinePrefix, allSinglePolygonData[3]),
					Square = Polygon.GetValueFromString(Polygon.SquarePrefix, allSinglePolygonData[4]),
					Size = Polygon.GetValueFromString(Polygon.SizePrefix, allSinglePolygonData[5]),
					Points = polygonPoints
				});
			}
		}

		private void DrawPolygons(List<Polygon> polygons)
		{
			GMapOverlay polyOverlay = new GMapOverlay("polygons");

			foreach (var polygon in polygons)
			{
				GMapPolygon mapPolygon = new GMapPolygon(polygon.Points, "mypolygon")
				{
					Fill = new SolidBrush(Color.FromArgb(50, Color.Red)),
					Stroke = new Pen(Color.Red, 1)
				};
				polyOverlay.Polygons.Add(mapPolygon);
			}
			
			gmap.Overlays.Add(polyOverlay);
			//gmap.Refresh();
		}

		private void gmap_Load(object sender, EventArgs e)
		{
			gmap.ShowCenter = false;
			gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
			GMaps.Instance.Mode = AccessMode.ServerOnly;
			gmap.Position = new PointLatLng(37.71169139127381, 55.629253022756586);
		}

		private void findMap_Click(object sender, EventArgs e)
		{
			if (this.polygons.Count == 0)
			{
				MessageBox.Show("Данные полигонов не были загружены!", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (this.showIntersections)
			{
				findMap.Text = ShowPointsButtonText;
				this.showIntersections = false;

				//this.markersOverlays.ForEach(overlay => gmap.Overlays.Clear());
				gmap.Overlays.Clear();
				//gmap.Overlays.Remove(this.markersOverlay);
				//gmap.Refresh();
			}

			foreach (var polygon in this.polygons)
			{
				List<PointLatLng> intersections = new List<PointLatLng>();

				for (int i = 0; i < polygon.Points.Count - 4; i++)
				{
					PointLatLng? intersection = this.CheckForIntersection(
						polygon.Points[i],
						polygon.Points[i + 1],
						polygon.Points[i + 2],
						polygon.Points[i + 3]);

					if (intersection != null)
					{
						intersections.Add(intersection.Value);
					}
				}

				if (intersections.Count > 0)
				{
					this.HighlightIntersectionsMap(intersections);
					polygon.Intersecions = intersections;
				}
			}

			this.showIntersections = true;
			findMap.Text = HidePointsButtonText;
		}

		private PointLatLng? CheckForIntersection(PointLatLng p1, PointLatLng p2, PointLatLng p3, PointLatLng p4)
		{
			// сортируем точки
			if (p2.Lat < p1.Lat)
			{
				PointLatLng tmp = p1;
				p1 = p2;
				p2 = tmp;
			}

			if (p4.Lat < p3.Lat)
			{
				PointLatLng tmp = p3;
				p3 = p4;
				p4 = tmp;
			}

			//проверим существование потенциального интервала для точки пересечения отрезков
			if (p2.Lat < p1.Lat)
			{
				//ибо у отрезков нету взаимной абсциссы
				return null;
			}

			//найдём коэффициенты уравнений, содержащих отрезки
			//f1(x) = A1*x + b1 = y
			//f2(x) = A2*x + b2 = y
			//если первый отрезок вертикальный
			if (p1.Lat - p2.Lat == 0)
			{
				//найдём Xa, Ya - точки пересечения двух прямых
				double resX = p1.Lat;
				double tg = (p3.Lng - p4.Lng) / (p3.Lat - p4.Lat);
				double shift = p3.Lng - tg * p4.Lat;

				double resultY = tg * resX + shift;

				if (p3.Lat <= resX &&
					p4.Lat >= resX &&
					Math.Min(p1.Lng, p2.Lng) <= resultY &&
					Math.Max(p1.Lng, p2.Lng) >= resultY)
				{
					return new PointLatLng(resX, resultY);
				}

				return null;
			}

			//если второй отрезок вертикальный
			if (p3.Lat - p4.Lat == 0)
			{
				//найдём Xa, Ya - точки пересечения двух прямых
				double resX = p3.Lat;
				double tg = (p1.Lng - p2.Lng) / (p1.Lat - p2.Lat);
				double shift = p1.Lng - tg * p1.Lat;
				double resultY = tg * resX + shift;

				if (p1.Lat <= resX &&
					p2.Lat >= resX &&
					Math.Min(p3.Lng, p4.Lng) <= resultY &&
					Math.Max(p3.Lng, p4.Lng) >= resultY)
				{
					return new PointLatLng(resX, resultY);
				}

				return null;
			}

			//оба отрезка невертикальные
			double tg1 = (p1.Lng - p2.Lng) / (p1.Lat - p2.Lat);
			double tg2 = (p3.Lng - p4.Lng) / (p3.Lat - p4.Lat);
			double shift1 = p1.Lng - tg1 * p1.Lat;
			double shift2 = p3.Lng - tg2 * p3.Lat;

			if (tg1 == tg2)
			{
				//отрезки параллельны
				return null;
			}

			//Xa - абсцисса точки пересечения двух прямых
			double resultX = (shift2 - shift1) / (tg1 - tg2);

			if ((resultX < Math.Max(p1.Lat, p3.Lat)) || (resultX > Math.Min(p2.Lat, p4.Lat)))
			{
				//точка Xa находится вне пересечения проекций отрезков на ось X
				return null;
			}
			else
			{
				double resultY = tg1 * resultX + shift1;
				return new PointLatLng(resultX, resultY);
			}
		}

		private void HighlightIntersectionsMap(List<PointLatLng> intersections)
		{
			GMapOverlay markersOverlay = new GMapOverlay("markers");

			intersections.ForEach(point =>
			{
				GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.green)
				{
					ToolTipText = point.ToString()
				};
				markersOverlay.Markers.Add(marker);
			});

			gmap.Overlays.Add(markersOverlay);
			this.markersOverlays.Add(markersOverlay);
			//gmap.Refresh();
		}

		#region Test code for test polygons

		private Point[] polygonPoints;

		private void ReadTestPolygon(string fileName)
		{
			string[] stringPoints = File.ReadAllText(fileName).Split(new[] { ',' });
			this.polygonPoints = new Point[stringPoints.Length];

			for (int i = 0; i < stringPoints.Length; i++)
			{
				string[] coordinates = stringPoints[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				this.polygonPoints[i] = new Point
				{
					X = int.Parse(coordinates[0]),
					Y = int.Parse(coordinates[1])
				};
			}
		}

		private void DrawTestPolygon(Point[] polygonPoints)
		{
			playground.Image = new Bitmap(playground.Width, playground.Height);
			using (Graphics g = Graphics.FromImage(playground.Image))
			{
				g.Clear(Color.White);

				Pen blackPen = new Pen(Color.Black, 1);
				g.DrawLines(blackPen, polygonPoints);
			}
		}

		private void HighlightIntersections(List<Point> intersections)
		{
			using (Graphics g = Graphics.FromImage(playground.Image))
			{
				Pen redPen = new Pen(Color.Red, 2);

				intersections.ForEach(point =>
				{
					g.DrawEllipse(redPen, point.X, point.Y, 2, 2);
				});
			}
			playground.Refresh();
		}

		private void findButton_Click(object sender, EventArgs e)
		{
			List<Point> intersections = new List<Point>();

			for (int i = 0; i < this.polygonPoints.Length - 4; i++)
			{
				Point? intersection = this.CheckForIntersection(
					(PointF)this.polygonPoints[i],
					(PointF)this.polygonPoints[i + 1],
					(PointF)this.polygonPoints[i + 2],
					(PointF)this.polygonPoints[i + 3]);

				if (intersection != null)
				{
					intersections.Add(intersection.Value);
				}
			}

			if (intersections.Count > 0)
			{
				this.HighlightIntersections(intersections);
			}
		}

		private Point? CheckForIntersection(PointF p1, PointF p2, PointF p3, PointF p4)
		{
			// сортируем точки
			if (p2.X < p1.X)
			{
				PointF tmp = p1;
				p1 = p2;
				p2 = tmp;
			}

			if (p4.X < p3.X)
			{
				PointF tmp = p3;
				p3 = p4;
				p4 = tmp;
			}

			//проверим существование потенциального интервала для точки пересечения отрезков
			if (p2.X < p1.X)
			{
				//ибо у отрезков нету взаимной абсциссы
				return null;
			}

			//найдём коэффициенты уравнений, содержащих отрезки
			//f1(x) = A1*x + b1 = y
			//f2(x) = A2*x + b2 = y
			//если первый отрезок вертикальный
			if (p1.X - p2.X == 0)
			{
				//найдём Xa, Ya - точки пересечения двух прямых
				double resX = p1.X;
				double tg = (p3.Y - p4.Y) / (p3.X - p4.X);
				double shift = p3.Y - tg * p4.X;

				double resultY = tg * resX + shift;

				if (p3.X <= resX &&
					p4.X >= resX &&
					Math.Min(p1.Y, p2.Y) <= resultY &&
					Math.Max(p1.Y, p2.Y) >= resultY)
				{
					return new Point { X = (int)Math.Round(resX), Y = (int)Math.Round(resultY) };
				}

				return null;
			}

			//если второй отрезок вертикальный
			if (p3.X - p4.X == 0)
			{
				//найдём Xa, Ya - точки пересечения двух прямых
				double resX = p3.X;
				double tg = (p1.Y - p2.Y) / (p1.X - p2.X);
				double shift = p1.Y - tg * p1.X;
				double resultY = tg * resX + shift;

				if (p1.X <= resX &&
					p2.X >= resX &&
					Math.Min(p3.Y, p4.Y) <= resultY &&
					Math.Max(p3.Y, p4.Y) >= resultY)
				{
					return new Point { X = (int)Math.Round(resX), Y = (int)Math.Round(resultY) };
				}

				return null;
			}

			//оба отрезка невертикальные
			double tg1 = (p1.Y - p2.Y) / (p1.X - p2.X);
			double tg2 = (p3.Y - p4.Y) / (p3.X - p4.X);
			double shift1 = p1.Y - tg1 * p1.X;
			double shift2 = p3.Y - tg2 * p3.X;

			if (tg1 == tg2)
			{
				//отрезки параллельны
				return null;
			}

			//Xa - абсцисса точки пересечения двух прямых
			double resultX = (shift2 - shift1) / (tg1 - tg2);

			if ((resultX < Math.Max(p1.X, p3.X)) || (resultX > Math.Min(p2.X, p4.X)))
			{
				//точка Xa находится вне пересечения проекций отрезков на ось X
				return null;
			}
			else
			{
				double resultY = tg1 * resultX + shift1;
				return new Point { X = (int)Math.Round(resultX), Y = (int)Math.Round(resultY) };
			}
		}


		#endregion
	}
}
