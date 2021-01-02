namespace TestRealTimeCharts
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cpuChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sens1x = new System.Windows.Forms.TextBox();
            this.sens1y = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sens2y = new System.Windows.Forms.TextBox();
            this.sens2x = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.sens3y = new System.Windows.Forms.TextBox();
            this.sens3x = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.sens4y = new System.Windows.Forms.TextBox();
            this.sens4x = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cpuChart)).BeginInit();
            this.SuspendLayout();
            // 
            // cpuChart
            // 
            chartArea5.Name = "ChartArea1";
            this.cpuChart.ChartAreas.Add(chartArea5);
            legend5.Enabled = false;
            legend5.Name = "Legend1";
            this.cpuChart.Legends.Add(legend5);
            this.cpuChart.Location = new System.Drawing.Point(12, 12);
            this.cpuChart.Name = "cpuChart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.cpuChart.Series.Add(series5);
            this.cpuChart.Size = new System.Drawing.Size(882, 493);
            this.cpuChart.TabIndex = 0;
            this.cpuChart.Text = "chart1";
            this.cpuChart.Click += new System.EventHandler(this.cpuChart_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(719, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pierwszy Sensor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 525);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Drugi Sensor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 525);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trzeci Sensor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(505, 525);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Czwarty Sensor";
            // 
            // sens1x
            // 
            this.sens1x.Location = new System.Drawing.Point(39, 557);
            this.sens1x.Name = "sens1x";
            this.sens1x.Size = new System.Drawing.Size(100, 20);
            this.sens1x.TabIndex = 6;
            this.sens1x.Text = "0";
            this.sens1x.TextChanged += new System.EventHandler(this.sens1x_TextChanged);
            // 
            // sens1y
            // 
            this.sens1y.Location = new System.Drawing.Point(39, 583);
            this.sens1y.Name = "sens1y";
            this.sens1y.Size = new System.Drawing.Size(100, 20);
            this.sens1y.TabIndex = 7;
            this.sens1y.Text = "-2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 560);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 586);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 586);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(168, 560);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "X";
            // 
            // sens2y
            // 
            this.sens2y.Location = new System.Drawing.Point(188, 583);
            this.sens2y.Name = "sens2y";
            this.sens2y.Size = new System.Drawing.Size(100, 20);
            this.sens2y.TabIndex = 11;
            this.sens2y.Text = "-2";
            this.sens2y.TextChanged += new System.EventHandler(this.sens2y_TextChanged);
            // 
            // sens2x
            // 
            this.sens2x.Location = new System.Drawing.Point(188, 557);
            this.sens2x.Name = "sens2x";
            this.sens2x.Size = new System.Drawing.Size(100, 20);
            this.sens2x.TabIndex = 10;
            this.sens2x.Text = "-2";
            this.sens2x.TextChanged += new System.EventHandler(this.sens2x_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(330, 586);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(330, 560);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "X";
            // 
            // sens3y
            // 
            this.sens3y.Location = new System.Drawing.Point(350, 583);
            this.sens3y.Name = "sens3y";
            this.sens3y.Size = new System.Drawing.Size(100, 20);
            this.sens3y.TabIndex = 15;
            this.sens3y.Text = "0";
            // 
            // sens3x
            // 
            this.sens3x.Location = new System.Drawing.Point(350, 557);
            this.sens3x.Name = "sens3x";
            this.sens3x.Size = new System.Drawing.Size(100, 20);
            this.sens3x.TabIndex = 14;
            this.sens3x.Text = "-2";
            this.sens3x.TextChanged += new System.EventHandler(this.sens3x_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(488, 586);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(488, 560);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "X";
            // 
            // sens4y
            // 
            this.sens4y.Location = new System.Drawing.Point(508, 583);
            this.sens4y.Name = "sens4y";
            this.sens4y.Size = new System.Drawing.Size(100, 20);
            this.sens4y.TabIndex = 19;
            this.sens4y.Text = "0";
            // 
            // sens4x
            // 
            this.sens4x.Location = new System.Drawing.Point(508, 557);
            this.sens4x.Name = "sens4x";
            this.sens4x.Size = new System.Drawing.Size(100, 20);
            this.sens4x.TabIndex = 18;
            this.sens4x.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 686);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.sens4y);
            this.Controls.Add(this.sens4x);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.sens3y);
            this.Controls.Add(this.sens3x);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sens2y);
            this.Controls.Add(this.sens2x);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sens1y);
            this.Controls.Add(this.sens1x);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cpuChart);
            this.Name = "Form1";
            this.Text = "Wifi Triatelator";
            ((System.ComponentModel.ISupportInitialize)(this.cpuChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart cpuChart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sens1x;
        private System.Windows.Forms.TextBox sens1y;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox sens2y;
        private System.Windows.Forms.TextBox sens2x;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox sens3y;
        private System.Windows.Forms.TextBox sens3x;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox sens4y;
        private System.Windows.Forms.TextBox sens4x;
    }
}

