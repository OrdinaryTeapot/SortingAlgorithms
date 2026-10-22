namespace SortingAlgorithms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рассчитатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияСДаннымиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.случайныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьПоСсылкеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bubbleCB = new System.Windows.Forms.CheckBox();
            this.insertionCB = new System.Windows.Forms.CheckBox();
            this.shakerCB = new System.Windows.Forms.CheckBox();
            this.quickCB = new System.Windows.Forms.CheckBox();
            this.bogoCB = new System.Windows.Forms.CheckBox();
            this.ascCB = new System.Windows.Forms.CheckBox();
            this.descCB = new System.Windows.Forms.CheckBox();
            this.bubbleTP = new System.Windows.Forms.TabPage();
            this.bubbleReplayButton = new System.Windows.Forms.Button();
            this.bubblePlot = new ScottPlot.WinForms.FormsPlot();
            this.bubbleLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.insertionTP = new System.Windows.Forms.TabPage();
            this.insertionReplayButton = new System.Windows.Forms.Button();
            this.insertionPlot = new ScottPlot.WinForms.FormsPlot();
            this.insertionLabel = new System.Windows.Forms.Label();
            this.shakerTP = new System.Windows.Forms.TabPage();
            this.shakerReplayButton = new System.Windows.Forms.Button();
            this.shakerPlot = new ScottPlot.WinForms.FormsPlot();
            this.shakerLabel = new System.Windows.Forms.Label();
            this.quickTP = new System.Windows.Forms.TabPage();
            this.quickReplayButton = new System.Windows.Forms.Button();
            this.quickPlot = new ScottPlot.WinForms.FormsPlot();
            this.quickLabel = new System.Windows.Forms.Label();
            this.bogoTP = new System.Windows.Forms.TabPage();
            this.bogoReplayButton = new System.Windows.Forms.Button();
            this.bogoPlot = new ScottPlot.WinForms.FormsPlot();
            this.bogoLabel = new System.Windows.Forms.Label();
            this.скачатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.bubbleTP.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.insertionTP.SuspendLayout();
            this.shakerTP.SuspendLayout();
            this.quickTP.SuspendLayout();
            this.bogoTP.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияToolStripMenuItem,
            this.действияСДаннымиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.рассчитатьToolStripMenuItem,
            this.очиститьToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // рассчитатьToolStripMenuItem
            // 
            this.рассчитатьToolStripMenuItem.Name = "рассчитатьToolStripMenuItem";
            this.рассчитатьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.рассчитатьToolStripMenuItem.Text = "Рассчитать";
            this.рассчитатьToolStripMenuItem.Click += new System.EventHandler(this.рассчитатьToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // действияСДаннымиToolStripMenuItem
            // 
            this.действияСДаннымиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.случайныеToolStripMenuItem,
            this.загрузитьИзФайлаToolStripMenuItem,
            this.загрузитьПоСсылкеToolStripMenuItem,
            this.скачатьToolStripMenuItem});
            this.действияСДаннымиToolStripMenuItem.Name = "действияСДаннымиToolStripMenuItem";
            this.действияСДаннымиToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.действияСДаннымиToolStripMenuItem.Text = "Данные";
            // 
            // случайныеToolStripMenuItem
            // 
            this.случайныеToolStripMenuItem.Name = "случайныеToolStripMenuItem";
            this.случайныеToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.случайныеToolStripMenuItem.Text = "Случайные";
            this.случайныеToolStripMenuItem.Click += new System.EventHandler(this.случайныеToolStripMenuItem_Click);
            // 
            // загрузитьИзФайлаToolStripMenuItem
            // 
            this.загрузитьИзФайлаToolStripMenuItem.Name = "загрузитьИзФайлаToolStripMenuItem";
            this.загрузитьИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.загрузитьИзФайлаToolStripMenuItem.Text = "Загрузить из файла";
            this.загрузитьИзФайлаToolStripMenuItem.Click += new System.EventHandler(this.загрузитьИзФайлаToolStripMenuItem_Click);
            // 
            // загрузитьПоСсылкеToolStripMenuItem
            // 
            this.загрузитьПоСсылкеToolStripMenuItem.Name = "загрузитьПоСсылкеToolStripMenuItem";
            this.загрузитьПоСсылкеToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.загрузитьПоСсылкеToolStripMenuItem.Text = "Загрузить по ссылке";
            this.загрузитьПоСсылкеToolStripMenuItem.Click += new System.EventHandler(this.загрузитьПоСсылкеToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(150, 1050);
            this.dataGridView1.TabIndex = 1;
            // 
            // bubbleCB
            // 
            this.bubbleCB.AutoSize = true;
            this.bubbleCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bubbleCB.Location = new System.Drawing.Point(168, 31);
            this.bubbleCB.Name = "bubbleCB";
            this.bubbleCB.Size = new System.Drawing.Size(142, 24);
            this.bubbleCB.TabIndex = 3;
            this.bubbleCB.Text = "Пузырьковая";
            this.bubbleCB.UseVisualStyleBackColor = true;
            // 
            // insertionCB
            // 
            this.insertionCB.AutoSize = true;
            this.insertionCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.insertionCB.Location = new System.Drawing.Point(316, 31);
            this.insertionCB.Name = "insertionCB";
            this.insertionCB.Size = new System.Drawing.Size(123, 24);
            this.insertionCB.TabIndex = 4;
            this.insertionCB.Text = "Вставками";
            this.insertionCB.UseVisualStyleBackColor = true;
            // 
            // shakerCB
            // 
            this.shakerCB.AutoSize = true;
            this.shakerCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shakerCB.Location = new System.Drawing.Point(445, 31);
            this.shakerCB.Name = "shakerCB";
            this.shakerCB.Size = new System.Drawing.Size(124, 24);
            this.shakerCB.TabIndex = 5;
            this.shakerCB.Text = "Шейкерная";
            this.shakerCB.UseVisualStyleBackColor = true;
            // 
            // quickCB
            // 
            this.quickCB.AutoSize = true;
            this.quickCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quickCB.Location = new System.Drawing.Point(575, 31);
            this.quickCB.Name = "quickCB";
            this.quickCB.Size = new System.Drawing.Size(104, 24);
            this.quickCB.TabIndex = 6;
            this.quickCB.Text = "Быстрая";
            this.quickCB.UseVisualStyleBackColor = true;
            // 
            // bogoCB
            // 
            this.bogoCB.AutoSize = true;
            this.bogoCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bogoCB.Location = new System.Drawing.Point(685, 31);
            this.bogoCB.Name = "bogoCB";
            this.bogoCB.Size = new System.Drawing.Size(82, 24);
            this.bogoCB.TabIndex = 7;
            this.bogoCB.Text = "BOGO";
            this.bogoCB.UseVisualStyleBackColor = true;
            // 
            // ascCB
            // 
            this.ascCB.AutoSize = true;
            this.ascCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ascCB.Location = new System.Drawing.Point(168, 61);
            this.ascCB.Name = "ascCB";
            this.ascCB.Size = new System.Drawing.Size(170, 24);
            this.ascCB.TabIndex = 8;
            this.ascCB.Text = "По возрастанию";
            this.ascCB.UseVisualStyleBackColor = true;
            // 
            // descCB
            // 
            this.descCB.AutoSize = true;
            this.descCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descCB.Location = new System.Drawing.Point(344, 61);
            this.descCB.Name = "descCB";
            this.descCB.Size = new System.Drawing.Size(142, 24);
            this.descCB.TabIndex = 9;
            this.descCB.Text = "По убыванию";
            this.descCB.UseVisualStyleBackColor = true;
            // 
            // bubbleTP
            // 
            this.bubbleTP.Controls.Add(this.bubbleReplayButton);
            this.bubbleTP.Controls.Add(this.bubblePlot);
            this.bubbleTP.Controls.Add(this.bubbleLabel);
            this.bubbleTP.Location = new System.Drawing.Point(4, 29);
            this.bubbleTP.Name = "bubbleTP";
            this.bubbleTP.Padding = new System.Windows.Forms.Padding(3);
            this.bubbleTP.Size = new System.Drawing.Size(1842, 992);
            this.bubbleTP.TabIndex = 0;
            this.bubbleTP.Text = "Пузырьковая";
            this.bubbleTP.UseVisualStyleBackColor = true;
            // 
            // bubbleReplayButton
            // 
            this.bubbleReplayButton.Location = new System.Drawing.Point(1473, 40);
            this.bubbleReplayButton.Name = "bubbleReplayButton";
            this.bubbleReplayButton.Size = new System.Drawing.Size(137, 57);
            this.bubbleReplayButton.TabIndex = 2;
            this.bubbleReplayButton.Text = "Повторить анимацию";
            this.bubbleReplayButton.UseVisualStyleBackColor = true;
            this.bubbleReplayButton.Click += new System.EventHandler(this.bubbleReplayButton_Click);
            // 
            // bubblePlot
            // 
            this.bubblePlot.Location = new System.Drawing.Point(10, 103);
            this.bubblePlot.Name = "bubblePlot";
            this.bubblePlot.Size = new System.Drawing.Size(1600, 800);
            this.bubblePlot.TabIndex = 1;
            // 
            // bubbleLabel
            // 
            this.bubbleLabel.AutoSize = true;
            this.bubbleLabel.Location = new System.Drawing.Point(6, 3);
            this.bubbleLabel.Name = "bubbleLabel";
            this.bubbleLabel.Size = new System.Drawing.Size(176, 20);
            this.bubbleLabel.TabIndex = 0;
            this.bubbleLabel.Text = "Время сортировки: ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.bubbleTP);
            this.tabControl1.Controls.Add(this.insertionTP);
            this.tabControl1.Controls.Add(this.shakerTP);
            this.tabControl1.Controls.Add(this.quickTP);
            this.tabControl1.Controls.Add(this.bogoTP);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(168, 91);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1850, 1025);
            this.tabControl1.TabIndex = 2;
            // 
            // insertionTP
            // 
            this.insertionTP.Controls.Add(this.insertionReplayButton);
            this.insertionTP.Controls.Add(this.insertionPlot);
            this.insertionTP.Controls.Add(this.insertionLabel);
            this.insertionTP.Location = new System.Drawing.Point(4, 29);
            this.insertionTP.Name = "insertionTP";
            this.insertionTP.Padding = new System.Windows.Forms.Padding(3);
            this.insertionTP.Size = new System.Drawing.Size(1842, 992);
            this.insertionTP.TabIndex = 1;
            this.insertionTP.Text = "Вставками";
            this.insertionTP.UseVisualStyleBackColor = true;
            // 
            // insertionReplayButton
            // 
            this.insertionReplayButton.Location = new System.Drawing.Point(1473, 40);
            this.insertionReplayButton.Name = "insertionReplayButton";
            this.insertionReplayButton.Size = new System.Drawing.Size(137, 57);
            this.insertionReplayButton.TabIndex = 2;
            this.insertionReplayButton.Text = "Повторить анимацию";
            this.insertionReplayButton.UseVisualStyleBackColor = true;
            this.insertionReplayButton.Click += new System.EventHandler(this.insertionReplayButton_Click);
            // 
            // insertionPlot
            // 
            this.insertionPlot.Location = new System.Drawing.Point(10, 103);
            this.insertionPlot.Name = "insertionPlot";
            this.insertionPlot.Size = new System.Drawing.Size(1600, 800);
            this.insertionPlot.TabIndex = 1;
            // 
            // insertionLabel
            // 
            this.insertionLabel.AutoSize = true;
            this.insertionLabel.Location = new System.Drawing.Point(6, 3);
            this.insertionLabel.Name = "insertionLabel";
            this.insertionLabel.Size = new System.Drawing.Size(176, 20);
            this.insertionLabel.TabIndex = 0;
            this.insertionLabel.Text = "Время сортировки: ";
            // 
            // shakerTP
            // 
            this.shakerTP.Controls.Add(this.shakerReplayButton);
            this.shakerTP.Controls.Add(this.shakerPlot);
            this.shakerTP.Controls.Add(this.shakerLabel);
            this.shakerTP.Location = new System.Drawing.Point(4, 29);
            this.shakerTP.Name = "shakerTP";
            this.shakerTP.Padding = new System.Windows.Forms.Padding(3);
            this.shakerTP.Size = new System.Drawing.Size(1842, 992);
            this.shakerTP.TabIndex = 2;
            this.shakerTP.Text = "Шейкерная";
            this.shakerTP.UseVisualStyleBackColor = true;
            // 
            // shakerReplayButton
            // 
            this.shakerReplayButton.Location = new System.Drawing.Point(1473, 40);
            this.shakerReplayButton.Name = "shakerReplayButton";
            this.shakerReplayButton.Size = new System.Drawing.Size(137, 57);
            this.shakerReplayButton.TabIndex = 2;
            this.shakerReplayButton.Text = "Повторить анимацию";
            this.shakerReplayButton.UseVisualStyleBackColor = true;
            this.shakerReplayButton.Click += new System.EventHandler(this.shakerReplayButton_Click);
            // 
            // shakerPlot
            // 
            this.shakerPlot.Location = new System.Drawing.Point(10, 103);
            this.shakerPlot.Name = "shakerPlot";
            this.shakerPlot.Size = new System.Drawing.Size(1600, 800);
            this.shakerPlot.TabIndex = 1;
            // 
            // shakerLabel
            // 
            this.shakerLabel.AutoSize = true;
            this.shakerLabel.Location = new System.Drawing.Point(6, 3);
            this.shakerLabel.Name = "shakerLabel";
            this.shakerLabel.Size = new System.Drawing.Size(176, 20);
            this.shakerLabel.TabIndex = 0;
            this.shakerLabel.Text = "Время сортировки: ";
            // 
            // quickTP
            // 
            this.quickTP.Controls.Add(this.quickReplayButton);
            this.quickTP.Controls.Add(this.quickPlot);
            this.quickTP.Controls.Add(this.quickLabel);
            this.quickTP.Location = new System.Drawing.Point(4, 29);
            this.quickTP.Name = "quickTP";
            this.quickTP.Padding = new System.Windows.Forms.Padding(3);
            this.quickTP.Size = new System.Drawing.Size(1842, 992);
            this.quickTP.TabIndex = 3;
            this.quickTP.Text = "Быстрая";
            this.quickTP.UseVisualStyleBackColor = true;
            // 
            // quickReplayButton
            // 
            this.quickReplayButton.Location = new System.Drawing.Point(1473, 40);
            this.quickReplayButton.Name = "quickReplayButton";
            this.quickReplayButton.Size = new System.Drawing.Size(137, 57);
            this.quickReplayButton.TabIndex = 2;
            this.quickReplayButton.Text = "Повторить анимацию";
            this.quickReplayButton.UseVisualStyleBackColor = true;
            this.quickReplayButton.Click += new System.EventHandler(this.quickReplayButton_Click);
            // 
            // quickPlot
            // 
            this.quickPlot.Location = new System.Drawing.Point(10, 103);
            this.quickPlot.Name = "quickPlot";
            this.quickPlot.Size = new System.Drawing.Size(1600, 800);
            this.quickPlot.TabIndex = 1;
            // 
            // quickLabel
            // 
            this.quickLabel.AutoSize = true;
            this.quickLabel.Location = new System.Drawing.Point(6, 3);
            this.quickLabel.Name = "quickLabel";
            this.quickLabel.Size = new System.Drawing.Size(176, 20);
            this.quickLabel.TabIndex = 0;
            this.quickLabel.Text = "Время сортировки: ";
            // 
            // bogoTP
            // 
            this.bogoTP.Controls.Add(this.bogoReplayButton);
            this.bogoTP.Controls.Add(this.bogoPlot);
            this.bogoTP.Controls.Add(this.bogoLabel);
            this.bogoTP.Location = new System.Drawing.Point(4, 29);
            this.bogoTP.Name = "bogoTP";
            this.bogoTP.Padding = new System.Windows.Forms.Padding(3);
            this.bogoTP.Size = new System.Drawing.Size(1842, 992);
            this.bogoTP.TabIndex = 4;
            this.bogoTP.Text = "BOGO";
            this.bogoTP.UseVisualStyleBackColor = true;
            // 
            // bogoReplayButton
            // 
            this.bogoReplayButton.Location = new System.Drawing.Point(1473, 40);
            this.bogoReplayButton.Name = "bogoReplayButton";
            this.bogoReplayButton.Size = new System.Drawing.Size(137, 57);
            this.bogoReplayButton.TabIndex = 3;
            this.bogoReplayButton.Text = "Повторить анимацию";
            this.bogoReplayButton.UseVisualStyleBackColor = true;
            this.bogoReplayButton.Click += new System.EventHandler(this.bogoReplayButton_Click);
            // 
            // bogoPlot
            // 
            this.bogoPlot.Location = new System.Drawing.Point(10, 103);
            this.bogoPlot.Name = "bogoPlot";
            this.bogoPlot.Size = new System.Drawing.Size(1600, 800);
            this.bogoPlot.TabIndex = 1;
            // 
            // bogoLabel
            // 
            this.bogoLabel.AutoSize = true;
            this.bogoLabel.Location = new System.Drawing.Point(6, 3);
            this.bogoLabel.Name = "bogoLabel";
            this.bogoLabel.Size = new System.Drawing.Size(176, 20);
            this.bogoLabel.TabIndex = 0;
            this.bogoLabel.Text = "Время сортировки: ";
            // 
            // скачатьToolStripMenuItem
            // 
            this.скачатьToolStripMenuItem.Name = "скачатьToolStripMenuItem";
            this.скачатьToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.скачатьToolStripMenuItem.Text = "Скачать";
            this.скачатьToolStripMenuItem.Click += new System.EventHandler(this.скачатьToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.descCB);
            this.Controls.Add(this.ascCB);
            this.Controls.Add(this.bogoCB);
            this.Controls.Add(this.quickCB);
            this.Controls.Add(this.shakerCB);
            this.Controls.Add(this.insertionCB);
            this.Controls.Add(this.bubbleCB);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сортировки";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.bubbleTP.ResumeLayout(false);
            this.bubbleTP.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.insertionTP.ResumeLayout(false);
            this.insertionTP.PerformLayout();
            this.shakerTP.ResumeLayout(false);
            this.shakerTP.PerformLayout();
            this.quickTP.ResumeLayout(false);
            this.quickTP.PerformLayout();
            this.bogoTP.ResumeLayout(false);
            this.bogoTP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рассчитатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияСДаннымиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem случайныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьПоСсылкеToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox bubbleCB;
        private System.Windows.Forms.CheckBox insertionCB;
        private System.Windows.Forms.CheckBox shakerCB;
        private System.Windows.Forms.CheckBox quickCB;
        private System.Windows.Forms.CheckBox bogoCB;
        private System.Windows.Forms.CheckBox ascCB;
        private System.Windows.Forms.CheckBox descCB;
        private System.Windows.Forms.TabPage bubbleTP;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label bubbleLabel;
        private ScottPlot.WinForms.FormsPlot bubblePlot;
        private System.Windows.Forms.TabPage insertionTP;
        private ScottPlot.WinForms.FormsPlot insertionPlot;
        private System.Windows.Forms.Label insertionLabel;
        private System.Windows.Forms.TabPage shakerTP;
        private ScottPlot.WinForms.FormsPlot shakerPlot;
        private System.Windows.Forms.Label shakerLabel;
        private System.Windows.Forms.TabPage quickTP;
        private ScottPlot.WinForms.FormsPlot quickPlot;
        private System.Windows.Forms.Label quickLabel;
        private System.Windows.Forms.TabPage bogoTP;
        private ScottPlot.WinForms.FormsPlot bogoPlot;
        private System.Windows.Forms.Label bogoLabel;
        private System.Windows.Forms.Button insertionReplayButton;
        private System.Windows.Forms.Button shakerReplayButton;
        private System.Windows.Forms.Button quickReplayButton;
        private System.Windows.Forms.Button bubbleReplayButton;
        private System.Windows.Forms.Button bogoReplayButton;
        private System.Windows.Forms.ToolStripMenuItem скачатьToolStripMenuItem;
    }
}

