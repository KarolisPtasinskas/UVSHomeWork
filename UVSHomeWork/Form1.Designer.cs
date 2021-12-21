namespace UVSHomeWork
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tbSlider = new System.Windows.Forms.TrackBar();
            this.lbValues = new System.Windows.Forms.Label();
            this.lvMainModelList = new System.Windows.Forms.ListView();
            this.threadId = new System.Windows.Forms.ColumnHeader();
            this.data = new System.Windows.Forms.ColumnHeader();
            this.lbNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 34);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(654, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 34);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tbSlider
            // 
            this.tbSlider.LargeChange = 3;
            this.tbSlider.Location = new System.Drawing.Point(130, 12);
            this.tbSlider.Maximum = 15;
            this.tbSlider.Minimum = 2;
            this.tbSlider.Name = "tbSlider";
            this.tbSlider.Size = new System.Drawing.Size(518, 69);
            this.tbSlider.TabIndex = 2;
            this.tbSlider.Value = 2;
            this.tbSlider.Scroll += new System.EventHandler(this.tbSlider_Scroll);
            // 
            // lbValues
            // 
            this.lbValues.AutoSize = true;
            this.lbValues.Location = new System.Drawing.Point(139, 65);
            this.lbValues.Name = "lbValues";
            this.lbValues.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbValues.Size = new System.Drawing.Size(507, 25);
            this.lbValues.TabIndex = 17;
            this.lbValues.Text = "2      3     4     5     6      7     8      9    10   11    12    13   14   15";
            // 
            // lvMainModelList
            // 
            this.lvMainModelList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.threadId,
            this.data});
            this.lvMainModelList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvMainModelList.HideSelection = false;
            this.lvMainModelList.Location = new System.Drawing.Point(12, 117);
            this.lvMainModelList.Name = "lvMainModelList";
            this.lvMainModelList.Size = new System.Drawing.Size(754, 415);
            this.lvMainModelList.TabIndex = 18;
            this.lvMainModelList.UseCompatibleStateImageBehavior = false;
            this.lvMainModelList.View = System.Windows.Forms.View.Details;
            // 
            // threadId
            // 
            this.threadId.Text = "Thread ID";
            this.threadId.Width = 120;
            // 
            // data
            // 
            this.data.Text = "Data";
            this.data.Width = 400;
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(26, 64);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(22, 25);
            this.lbNumber.TabIndex = 19;
            this.lbNumber.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.lvMainModelList);
            this.Controls.Add(this.lbValues);
            this.Controls.Add(this.tbSlider);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UVS Thread generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TrackBar tbSlider;
        private System.Windows.Forms.Label lbValues;
        private System.Windows.Forms.ListView lvMainModelList;
        private System.Windows.Forms.ColumnHeader threadId;
        private System.Windows.Forms.ColumnHeader data;
        private System.Windows.Forms.Label lbNumber;
    }
}
