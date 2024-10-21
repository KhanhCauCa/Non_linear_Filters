using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Non_linear_Filters_Median
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.picBefore = new System.Windows.Forms.PictureBox();
            this.picAfter = new System.Windows.Forms.PictureBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.trackBarBilateral = new System.Windows.Forms.TrackBar();
            this.lblTrackBarValue = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAfter)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBilateral)).BeginInit();
            this.SuspendLayout();
            // 
            // picBefore
            // 
            this.picBefore.BackColor = System.Drawing.SystemColors.Control;
            this.picBefore.Location = new System.Drawing.Point(21, 31);
            this.picBefore.Margin = new System.Windows.Forms.Padding(4);
            this.picBefore.Name = "picBefore";
            this.picBefore.Size = new System.Drawing.Size(465, 441);
            this.picBefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBefore.TabIndex = 0;
            this.picBefore.TabStop = false;
            // 
            // picAfter
            // 
            this.picAfter.Location = new System.Drawing.Point(20, 31);
            this.picAfter.Margin = new System.Windows.Forms.Padding(4);
            this.picAfter.Name = "picAfter";
            this.picAfter.Size = new System.Drawing.Size(465, 441);
            this.picAfter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAfter.TabIndex = 1;
            this.picAfter.TabStop = false;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(622, 99);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(4);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(125, 47);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "Choose Image";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(622, 391);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(125, 47);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picBefore);
            this.groupBox1.Location = new System.Drawing.Point(60, 57);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(504, 491);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Before";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picAfter);
            this.groupBox2.Location = new System.Drawing.Point(814, 57);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(504, 491);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "After";
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilter.Location = new System.Drawing.Point(622, 172);
            this.comboBoxFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(126, 24);
            this.comboBoxFilter.TabIndex = 6;
            this.comboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
            // 
            // trackBarBilateral
            // 
            this.trackBarBilateral.Location = new System.Drawing.Point(622, 243);
            this.trackBarBilateral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBarBilateral.Name = "trackBarBilateral";
            this.trackBarBilateral.Size = new System.Drawing.Size(125, 56);
            this.trackBarBilateral.TabIndex = 7;
            this.trackBarBilateral.Visible = false;
            this.trackBarBilateral.Scroll += new System.EventHandler(this.trackBarBilateral_Scroll);
            // 
            // lblTrackBarValue
            // 
            this.lblTrackBarValue.Location = new System.Drawing.Point(622, 296);
            this.lblTrackBarValue.Name = "lblTrackBarValue";
            this.lblTrackBarValue.Size = new System.Drawing.Size(125, 20);
            this.lblTrackBarValue.TabIndex = 8;
            this.lblTrackBarValue.Text = "Mịn: 50";
            this.lblTrackBarValue.Visible = false;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(623, 318);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(125, 47);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Filter";
            this.btnFilter.Visible = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 640);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.trackBarBilateral);
            this.Controls.Add(this.lblTrackBarValue);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Image Filter Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAfter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBilateral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private PictureBox picBefore;
        private PictureBox picAfter;
        private Button btnChoose;
        private Button btnReset;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox comboBoxFilter;
        private TrackBar trackBarBilateral;
        private Label lblTrackBarValue;
        private Button btnFilter;
    }
}
