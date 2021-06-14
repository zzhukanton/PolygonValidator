using GMap.NET;
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
		private string currentFilename;
		private GMapPolygon currentSelectedPolygon;

		public MainForm()
		{
			this.InitializeComponent();

			fixButton.Enabled = false;
			save.Enabled = false;
			saveAs.Enabled = false;
			saveQGIS.Enabled = false;
			closeCurrent.Enabled = false;
			colorSelector.Enabled = false;

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
			this.currentFilename = openFile.FileName;

			this.ReadMapPolygon(this.currentFilename);
			this.DrawPolygons(this.polygons);

			save.Enabled = true;
			saveAs.Enabled = true;
			saveQGIS.Enabled = true;
			closeCurrent.Enabled = true;
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
						double.Parse(coordinates[1], CultureInfo.InvariantCulture),
						double.Parse(coordinates[0], CultureInfo.InvariantCulture)));
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

				this.updatedPolygons.Add(new Polygon
				{
					Name = Polygon.GetValueFromString(Polygon.NamePrefix, allSinglePolygonData[1]),
					AverageDepth = Polygon.GetValueFromString(Polygon.AverageDepthPrefix, allSinglePolygonData[2]),
					Coastline = Polygon.GetValueFromString(Polygon.CoastlinePrefix, allSinglePolygonData[3]),
					Square = Polygon.GetValueFromString(Polygon.SquarePrefix, allSinglePolygonData[4]),
					Size = Polygon.GetValueFromString(Polygon.SizePrefix, allSinglePolygonData[5]),
					Points = new List<PointLatLng>(polygonPoints)
				});
			}
		}

		private void DrawPolygons(List<Polygon> polygons)
		{
			GMapOverlay polyOverlay = new GMapOverlay(Overlay.Polygon);

			foreach (var polygon in polygons)
			{
				GMapPolygon mapPolygon = new GMapPolygon(polygon.Points, polygon.Name)
				{
					Fill = new SolidBrush(Color.FromArgb(50, Color.Red)),
					Stroke = new Pen(Color.Red, 1),
					IsHitTestVisible = true
				};
				
				polyOverlay.Polygons.Add(mapPolygon);
			}

			gmap.Overlays.Add(polyOverlay);
			
			gmap.Zoom++;
			gmap.Zoom--;
		}

		private void gmap_Load(object sender, EventArgs e)
		{
			gmap.ShowCenter = false;
			gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
			GMaps.Instance.Mode = AccessMode.ServerOnly;
			gmap.Position = new PointLatLng(55.629253022756586, 37.71169139127381);
		}

		private void findMap_Click(object sender, EventArgs e)
		{
			if (this.polygons.Count == 0)
			{
				MessageBox.Show(UserMessage.LoadPolygon, UserMessage.ErrorTitle,MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (this.showIntersections)
			{
				findMap.Text = Labels.ShowPointsButtonText;
				this.showIntersections = false;
			}

			for (int index = 0; index < this.polygons.Count; index++)
			{
				List<PointLatLng> intersections = new List<PointLatLng>();
				int length = this.polygons[index].Points.Count;
				List<PointLatLng> pointsToDelete = new List<PointLatLng>();

				for (int i = 0; i < length - 4; i++)
				{
					PointLatLng? intersection = this.CheckForIntersection(
						this.polygons[index].Points[i],
						this.polygons[index].Points[i + 1],
						this.polygons[index].Points[i + 2],
						this.polygons[index].Points[i + 3]);

					if (intersection != null)
					{
						intersections.Add(intersection.Value);
						pointsToDelete.Add(this.polygons[index].Points[i + 1]);
						pointsToDelete.Add(this.polygons[index].Points[i + 2]);
					}
				}

				if (intersections.Count > 0)
				{
					this.HighlightIntersectionsMap(intersections);
					this.polygons[index].Intersecions = intersections;

					pointsToDelete.ForEach(point => this.updatedPolygons[index].Points.Remove(point));
				}
			}

			this.showIntersections = true;
			findMap.Text = Labels.HidePointsButtonText;
			fixButton.Enabled = true;
			gmap.Zoom++;
			gmap.Zoom--;
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
			GMapOverlay markersOverlay = new GMapOverlay(Overlay.Marker);

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
		}

		private void fixButton_Click(object sender, EventArgs e)
		{
			gmap.Overlays.Clear();

			DrawPolygons(this.updatedPolygons);

			gmap.Zoom++;
			gmap.Zoom--;
		}

		private void closeCurrent_Click(object sender, EventArgs e)
		{
			gmap.Overlays.Clear();

			fixButton.Enabled = false;
			save.Enabled = false;
			saveAs.Enabled = false;
			saveQGIS.Enabled = false;
			closeCurrent.Enabled = false;

			this.polygons.Clear();
			this.updatedPolygons.Clear();
			this.markersOverlays.Clear();

			// clear labels with data
			name.Text = Labels.NameText;
			depth.Text = Labels.AverageDepthText;
			coast.Text = Labels.CoastlineText;
			square.Text = Labels.SquareText;
			size.Text = Labels.SizeText;
		}

		private void exit_Click(object sender, EventArgs e) => this.Close();

		private void save_Click(object sender, EventArgs e)
		{
			PolygonSerializer serializer = new PolygonSerializer();
			serializer.SavePolygons(this.currentFilename, updatedPolygons);
		}

		private void saveAs_Click(object sender, EventArgs e)
		{
			saveFileDialog1.DefaultExt = Labels.TxtExtention;
			saveFileDialog1.FileName = Labels.DefaultFileName;
			saveFileDialog1.Filter = Labels.CsvTxtFilter;
			saveFileDialog1.ShowDialog();
		}

		private void saveQGIS_Click(object sender, EventArgs e)
		{
			saveFileDialog1.DefaultExt = Labels.CsvExtention;
			saveFileDialog1.FileName = Labels.DefaultFileName;
			saveFileDialog1.Filter = Labels.CsvFilter;
			saveFileDialog1.ShowDialog();
		}

		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			PolygonSerializer serializer = new PolygonSerializer();
			serializer.SavePolygonsAsQGIS(saveFileDialog1.FileName, updatedPolygons);
			MessageBox.Show(UserMessage.SaveSuccess, UserMessage.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void gmap_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
		{
			Polygon polygon = this.polygons.Find(p => p.Name == item.Name);
			this.currentSelectedPolygon = item;

			name.Text = $"{Labels.NameText}{polygon.Name}";
			depth.Text = $"{Labels.AverageDepthText}{polygon.AverageDepth}";
			coast.Text = $"{Labels.CoastlineText}{polygon.Coastline}";
			square.Text = $"{Labels.SquareText}{polygon.Square}";
			size.Text = $"{Labels.SizeText}{polygon.Size}";

			colorSelector.Enabled = true;
			borderSelector.Enabled = true;
		}

		private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(UserMessage.About, UserMessage.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void colorSelector_Click(object sender, EventArgs e)
		{
			if (this.currentSelectedPolygon == null)
			{
				MessageBox.Show(UserMessage.SelectPolygon, UserMessage.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (colorDialog1.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}

			this.currentSelectedPolygon.Fill = new SolidBrush(Color.FromArgb(50, colorDialog1.Color));
			gmap.Zoom++;
			gmap.Zoom--;
		}

		private void borderSelector_Click(object sender, EventArgs e)
		{
			if (this.currentSelectedPolygon == null)
			{
				MessageBox.Show(UserMessage.SelectPolygon, UserMessage.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (colorDialog1.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}

			this.currentSelectedPolygon.Stroke = new Pen(colorDialog1.Color, 1);
			gmap.Zoom++;
			gmap.Zoom--;
		}
	}
}
