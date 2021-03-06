
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
			this.name = new System.Windows.Forms.Label();
			this.size = new System.Windows.Forms.Label();
			this.square = new System.Windows.Forms.Label();
			this.coast = new System.Windows.Forms.Label();
			this.depth = new System.Windows.Forms.Label();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.colorSelector = new System.Windows.Forms.Button();
			this.borderSelector = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.menuStrip1.SuspendLayout();
			this.details.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			this.menuStrip1.Size = new System.Drawing.Size(1384, 28);
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
			this.saveAs.Click += new System.EventHandler(this.saveAs_Click);
			// 
			// saveQGIS
			// 
			this.saveQGIS.Name = "saveQGIS";
			this.saveQGIS.Size = new System.Drawing.Size(231, 26);
			this.saveQGIS.Text = "Сохранить для QGIS";
			this.saveQGIS.Click += new System.EventHandler(this.saveQGIS_Click);
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
			this.информацияToolStripMenuItem.Click += new System.EventHandler(this.информацияToolStripMenuItem_Click);
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
			this.gmap.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.gmap_OnPolygonClick);
			this.gmap.Load += new System.EventHandler(this.gmap_Load);
			// 
			// openFile
			// 
			this.openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_FileOk);
			// 
			// findMap
			// 
			this.findMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.findMap.Location = new System.Drawing.Point(1046, 31);
			this.findMap.Name = "findMap";
			this.findMap.Size = new System.Drawing.Size(326, 94);
			this.findMap.TabIndex = 4;
			this.findMap.Text = "Показать точки самопересечения";
			this.findMap.UseVisualStyleBackColor = true;
			this.findMap.Click += new System.EventHandler(this.findMap_Click);
			// 
			// fixButton
			// 
			this.fixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.fixButton.Location = new System.Drawing.Point(1046, 131);
			this.fixButton.Name = "fixButton";
			this.fixButton.Size = new System.Drawing.Size(326, 94);
			this.fixButton.TabIndex = 5;
			this.fixButton.Text = "Сгладить точки самопересечения";
			this.fixButton.UseVisualStyleBackColor = true;
			this.fixButton.Click += new System.EventHandler(this.fixButton_Click);
			// 
			// details
			// 
			this.details.Controls.Add(this.name);
			this.details.Controls.Add(this.size);
			this.details.Controls.Add(this.square);
			this.details.Controls.Add(this.coast);
			this.details.Controls.Add(this.depth);
			this.details.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.details.Location = new System.Drawing.Point(1046, 244);
			this.details.Name = "details";
			this.details.Size = new System.Drawing.Size(326, 230);
			this.details.TabIndex = 6;
			this.details.TabStop = false;
			this.details.Text = "Подробная информация";
			// 
			// name
			// 
			this.name.AutoSize = true;
			this.name.Location = new System.Drawing.Point(6, 37);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(83, 18);
			this.name.TabIndex = 4;
			this.name.Text = "Название: ";
			// 
			// size
			// 
			this.size.AutoSize = true;
			this.size.Location = new System.Drawing.Point(6, 197);
			this.size.Name = "size";
			this.size.Size = new System.Drawing.Size(80, 18);
			this.size.TabIndex = 3;
			this.size.Text = "Размеры: ";
			// 
			// square
			// 
			this.square.AutoSize = true;
			this.square.Location = new System.Drawing.Point(6, 159);
			this.square.Name = "square";
			this.square.Size = new System.Drawing.Size(81, 18);
			this.square.TabIndex = 2;
			this.square.Text = "Площадь: ";
			// 
			// coast
			// 
			this.coast.AutoSize = true;
			this.coast.Location = new System.Drawing.Point(6, 120);
			this.coast.Name = "coast";
			this.coast.Size = new System.Drawing.Size(130, 18);
			this.coast.TabIndex = 1;
			this.coast.Text = "Береговая линия:";
			// 
			// depth
			// 
			this.depth.AutoSize = true;
			this.depth.Location = new System.Drawing.Point(6, 79);
			this.depth.Name = "depth";
			this.depth.Size = new System.Drawing.Size(131, 18);
			this.depth.TabIndex = 0;
			this.depth.Text = "Средняя глубина:";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
			// 
			// colorSelector
			// 
			this.colorSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.colorSelector.Location = new System.Drawing.Point(6, 35);
			this.colorSelector.Name = "colorSelector";
			this.colorSelector.Size = new System.Drawing.Size(305, 55);
			this.colorSelector.TabIndex = 7;
			this.colorSelector.Text = "Заливка";
			this.colorSelector.UseVisualStyleBackColor = true;
			this.colorSelector.Click += new System.EventHandler(this.colorSelector_Click);
			// 
			// borderSelector
			// 
			this.borderSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.borderSelector.Location = new System.Drawing.Point(6, 96);
			this.borderSelector.Name = "borderSelector";
			this.borderSelector.Size = new System.Drawing.Size(305, 55);
			this.borderSelector.TabIndex = 8;
			this.borderSelector.Text = "Контур";
			this.borderSelector.UseVisualStyleBackColor = true;
			this.borderSelector.Click += new System.EventHandler(this.borderSelector_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.colorSelector);
			this.groupBox1.Controls.Add(this.borderSelector);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(1055, 491);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(317, 169);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Выбрать цвет";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1384, 740);
			this.Controls.Add(this.groupBox1);
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
			this.groupBox1.ResumeLayout(false);
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
		private System.Windows.Forms.Label size;
		private System.Windows.Forms.Label square;
		private System.Windows.Forms.Label coast;
		private System.Windows.Forms.Label depth;
		private System.Windows.Forms.ToolStripMenuItem closeCurrent;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label name;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button colorSelector;
		private System.Windows.Forms.Button borderSelector;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}

