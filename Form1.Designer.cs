
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
			this.closeCurrent = new System.Windows.Forms.ToolStripMenuItem();
			this.save = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.saveQGIS = new System.Windows.Forms.ToolStripMenuItem();
			this.exit = new System.Windows.Forms.ToolStripMenuItem();
			this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gmap = new GMap.NET.WindowsForms.GMapControl();
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.findMap = new System.Windows.Forms.Button();
			this.fixButton = new System.Windows.Forms.Button();
			this.details = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.details.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
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
            this.closeCurrent,
            this.save,
            this.saveAs,
            this.saveQGIS,
            this.exit});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// открытьToolStripMenuItem
			// 
			this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
			this.открытьToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
			this.открытьToolStripMenuItem.Text = "Открыть";
			this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
			// 
			// closeCurrent
			// 
			this.closeCurrent.Name = "closeCurrent";
			this.closeCurrent.Size = new System.Drawing.Size(231, 26);
			this.closeCurrent.Text = "Закрыть текущий";
			this.closeCurrent.Click += new System.EventHandler(this.closeCurrent_Click);
			// 
			// save
			// 
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(231, 26);
			this.save.Text = "Сохранить";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// saveAs
			// 
			this.saveAs.Name = "saveAs";
			this.saveAs.Size = new System.Drawing.Size(231, 26);
			this.saveAs.Text = "Сохранить как...";
			// 
			// saveQGIS
			// 
			this.saveQGIS.Name = "saveQGIS";
			this.saveQGIS.Size = new System.Drawing.Size(231, 26);
			this.saveQGIS.Text = "Сохранить для QGIS";
			// 
			// exit
			// 
			this.exit.Name = "exit";
			this.exit.Size = new System.Drawing.Size(231, 26);
			this.exit.Text = "Выход";
			this.exit.Click += new System.EventHandler(this.exit_Click);
			// 
			// оПрограммеToolStripMenuItem
			// 
			this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.информацияToolStripMenuItem});
			this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
			this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
			this.оПрограммеToolStripMenuItem.Text = "О программе";
			// 
			// информацияToolStripMenuItem
			// 
			this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
			this.информацияToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
			this.информацияToolStripMenuItem.Text = "Информация";
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
			this.gmap.Size = new System.Drawing.Size(1028, 697);
			this.gmap.TabIndex = 1;
			this.gmap.Zoom = 13D;
			this.gmap.Load += new System.EventHandler(this.gmap_Load);
			// 
			// openFile
			// 
			this.openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_FileOk);
			// 
			// findMap
			// 
			this.findMap.Location = new System.Drawing.Point(1046, 31);
			this.findMap.Name = "findMap";
			this.findMap.Size = new System.Drawing.Size(224, 94);
			this.findMap.TabIndex = 4;
			this.findMap.Text = "Показать точки самопересечения";
			this.findMap.UseVisualStyleBackColor = true;
			this.findMap.Click += new System.EventHandler(this.findMap_Click);
			// 
			// fixButton
			// 
			this.fixButton.Location = new System.Drawing.Point(1046, 131);
			this.fixButton.Name = "fixButton";
			this.fixButton.Size = new System.Drawing.Size(224, 94);
			this.fixButton.TabIndex = 5;
			this.fixButton.Text = "Сгладить точки самопересечения";
			this.fixButton.UseVisualStyleBackColor = true;
			this.fixButton.Click += new System.EventHandler(this.fixButton_Click);
			// 
			// details
			// 
			this.details.Controls.Add(this.label4);
			this.details.Controls.Add(this.label3);
			this.details.Controls.Add(this.label2);
			this.details.Controls.Add(this.label1);
			this.details.Location = new System.Drawing.Point(1046, 277);
			this.details.Name = "details";
			this.details.Size = new System.Drawing.Size(224, 212);
			this.details.TabIndex = 6;
			this.details.TabStop = false;
			this.details.Text = "Подробная информация";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 173);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Размеры: ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 134);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Площадь: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 93);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(125, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Береговая линия:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(125, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Средняя глубина:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1333, 740);
			this.Controls.Add(this.details);
			this.Controls.Add(this.fixButton);
			this.Controls.Add(this.findMap);
			this.Controls.Add(this.gmap);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Валидатор полигонов";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.details.ResumeLayout(false);
			this.details.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem save;
		private GMap.NET.WindowsForms.GMapControl gmap;
		private System.Windows.Forms.OpenFileDialog openFile;
		private System.Windows.Forms.Button findMap;
		private System.Windows.Forms.Button fixButton;
		private System.Windows.Forms.ToolStripMenuItem saveAs;
		private System.Windows.Forms.ToolStripMenuItem saveQGIS;
		private System.Windows.Forms.ToolStripMenuItem exit;
		private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
		private System.Windows.Forms.GroupBox details;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem closeCurrent;
	}
}

