using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PolygonValidator
{
	public partial class MainForm : Form
	{
		private Point[] polygonPoints; 

		public MainForm()
		{
			InitializeComponent();
		}

		private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// read file, get the list of points
			openFile.ShowDialog();
		}

		private void openFile_FileOk(object sender, CancelEventArgs e)
		{
			//openFile.
			string fileName = openFile.FileName;
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

			DrawPolygon(this.polygonPoints);
		}

		private void DrawPolygon(Point[] polygonPoints)
		{
			playground.Image = new Bitmap(playground.Width, playground.Height);
			using (Graphics g = Graphics.FromImage(playground.Image))
			{
				g.Clear(Color.White);

				Pen blackPen = new Pen(Color.Black, 1);
				g.DrawLines(blackPen, polygonPoints);
			}
		}

		private void findButton_Click(object sender, EventArgs e)
		{
			List<Point> intersections = new List<Point>();

			for (int i = 0; i < this.polygonPoints.Length - 4; i++)
			{
				Point? intersection = CheckForIntersection(
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
				HighlightIntersections(intersections);
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
	}
}
