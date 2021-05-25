
namespace PolygonValidator
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gmap = new GMap.NET.WindowsForms.GMapControl();
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.playground = new System.Windows.Forms.PictureBox();
			this.findButton = new System.Windows.Forms.Button();
			this.findMap = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.playground)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1333, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// открытьToolStripMenuItem
			// 
			this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
			this.открытьToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
			this.открытьToolStripMenuItem.Text = "Открыть";
			this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
			// 
			// сохранитьToolStripMenuItem
			// 
			this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
			this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
			this.сохранитьToolStripMenuItem.Text = "Сохранить";
			// 
			// gmap
			// 
			this.gmap.Bearing = 0F;
			this.gmap.CanDragMap = true;
			this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
			this.gmap.GrayScaleMode = false;
			this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
			this.gmap.LevelsKeepInMemmory = 5;
			this.gmap.Location = new System.Drawing.Point(12, 31);
			this.gmap.MarkersEnabled = true;
			this.gmap.MaxZoom = 18;
			this.gmap.MinZoom = 2;
			this.gmap.MouseWheelZoomEnabled = true;
			this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			this.gmap.Name = "gmap";
			this.gmap.NegativeMode = false;
			this.gmap.PolygonsEnabled = true;
			this.gmap.RetryLoadTile = 0;
			this.gmap.RoutesEnabled = true;
			this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
			this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
			this.gmap.ShowTileGridLines = false;
			this.gmap.Size = new System.Drawing.Size(1028, 587);
			this.gmap.TabIndex = 1;
			this.gmap.Zoom = 13D;
			this.gmap.Load += new System.EventHandler(this.gmap_Load);
			// 
			// openFile
			// 
			this.openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_FileOk);
			// 
			// playground
			// 
			this.playground.Location = new System.Drawing.Point(1168, 55);
			this.playground.Name = "playground";
			this.playground.Size = new System.Drawing.Size(122, 100);
			this.playground.TabIndex = 2;
			this.playground.TabStop = false;
			// 
			// findButton
			// 
			this.findButton.Location = new System.Drawing.Point(1066, 206);
			this.findButton.Name = "findButton";
			this.findButton.Size = new System.Drawing.Size(224, 94);
			this.findButton.TabIndex = 3;
			this.findButton.Text = "Найти точки пересечения тест";
			this.findButton.UseVisualStyleBackColor = true;
			this.findButton.Click += new System.EventHandler(this.findButton_Click);
			// 
			// findMap
			// 
			this.findMap.Location = new System.Drawing.Point(1066, 359);
			this.findMap.Name = "findMap";
			this.findMap.Size = new System.Drawing.Size(224, 94);
			this.findMap.TabIndex = 4;
			this.findMap.Text = "Найти точки пересечения карта";
			this.findMap.UseVisualStyleBackColor = true;
			this.findMap.Click += new System.EventHandler(this.findMap_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1333, 630);
			this.Controls.Add(this.findMap);
			this.Controls.Add(this.findButton);
			this.Controls.Add(this.playground);
			this.Controls.Add(this.gmap);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Валидатор полигонов";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.playground)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
		private GMap.NET.WindowsForms.GMapControl gmap;
		private System.Windows.Forms.OpenFileDialog openFile;
		private System.Windows.Forms.PictureBox playground;
		private System.Windows.Forms.Button findButton;
		private System.Windows.Forms.Button findMap;
	}
}

