using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Non_linear_Filters
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
            this.tbSpace = new System.Windows.Forms.TrackBar();
            this.lblSigmaSpace = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.grbBilateral = new System.Windows.Forms.GroupBox();
            this.tbColor = new System.Windows.Forms.TrackBar();
            this.lblSigmaColor = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grbMedian = new System.Windows.Forms.GroupBox();
            this.cmbWindow = new System.Windows.Forms.ComboBox();
            this.lblMedian = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAfter)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpace)).BeginInit();
            this.grbBilateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbColor)).BeginInit();
            this.grbMedian.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBefore
            // 
            this.picBefore.BackColor = System.Drawing.SystemColors.Control;
            this.picBefore.Location = new System.Drawing.Point(16, 25);
            this.picBefore.Name = "picBefore";
            this.picBefore.Size = new System.Drawing.Size(349, 358);
            this.picBefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBefore.TabIndex = 0;
            this.picBefore.TabStop = false;
            // 
            // picAfter
            // 
            this.picAfter.Location = new System.Drawing.Point(15, 25);
            this.picAfter.Name = "picAfter";
            this.picAfter.Size = new System.Drawing.Size(349, 358);
            this.picAfter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAfter.TabIndex = 1;
            this.picAfter.TabStop = false;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(506, 76);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(94, 38);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "Choose Image";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(508, 381);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 38);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picBefore);
            this.groupBox1.Location = new System.Drawing.Point(45, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(378, 399);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Before";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picAfter);
            this.groupBox2.Location = new System.Drawing.Point(678, 46);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(378, 399);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "After";
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilter.Location = new System.Drawing.Point(506, 135);
            this.comboBoxFilter.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(96, 21);
            this.comboBoxFilter.TabIndex = 6;
            this.comboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
            // 
            // tbSpace
            // 
            this.tbSpace.Location = new System.Drawing.Point(116, 16);
            this.tbSpace.Margin = new System.Windows.Forms.Padding(2);
            this.tbSpace.Name = "tbSpace";
            this.tbSpace.Size = new System.Drawing.Size(94, 45);
            this.tbSpace.TabIndex = 7;
            this.tbSpace.Scroll += new System.EventHandler(this.trackBarSigmaSpace_Scroll);
            // 
            // lblSigmaSpace
            // 
            this.lblSigmaSpace.Location = new System.Drawing.Point(13, 29);
            this.lblSigmaSpace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSigmaSpace.Name = "lblSigmaSpace";
            this.lblSigmaSpace.Size = new System.Drawing.Size(94, 16);
            this.lblSigmaSpace.TabIndex = 8;
            this.lblSigmaSpace.Text = "Sigma Space: 1";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(509, 322);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(94, 38);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Filter";
            this.btnFilter.Visible = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // grbBilateral
            // 
            this.grbBilateral.Controls.Add(this.tbColor);
            this.grbBilateral.Controls.Add(this.lblSigmaColor);
            this.grbBilateral.Controls.Add(this.tbSpace);
            this.grbBilateral.Controls.Add(this.lblSigmaSpace);
            this.grbBilateral.Location = new System.Drawing.Point(439, 177);
            this.grbBilateral.Name = "grbBilateral";
            this.grbBilateral.Size = new System.Drawing.Size(234, 127);
            this.grbBilateral.TabIndex = 9;
            this.grbBilateral.TabStop = false;
            // 
            // tbColor
            // 
            this.tbColor.Location = new System.Drawing.Point(116, 65);
            this.tbColor.Margin = new System.Windows.Forms.Padding(2);
            this.tbColor.Name = "tbColor";
            this.tbColor.Size = new System.Drawing.Size(94, 45);
            this.tbColor.TabIndex = 7;
            this.tbColor.Scroll += new System.EventHandler(this.trackBarSigmaColor_Scroll);
            // 
            // lblSigmaColor
            // 
            this.lblSigmaColor.Location = new System.Drawing.Point(13, 78);
            this.lblSigmaColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSigmaColor.Name = "lblSigmaColor";
            this.lblSigmaColor.Size = new System.Drawing.Size(94, 16);
            this.lblSigmaColor.TabIndex = 8;
            this.lblSigmaColor.Text = "Sigma Color: 1";
            // 
            // grbMedian
            // 
            this.grbMedian.Controls.Add(this.cmbWindow);
            this.grbMedian.Controls.Add(this.lblMedian);
            this.grbMedian.Location = new System.Drawing.Point(455, 215);
            this.grbMedian.Name = "grbMedian";
            this.grbMedian.Size = new System.Drawing.Size(192, 53);
            this.grbMedian.TabIndex = 10;
            this.grbMedian.TabStop = false;
            // 
            // cmbWindow
            // 
            this.cmbWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWindow.FormattingEnabled = true;
            this.cmbWindow.Location = new System.Drawing.Point(116, 16);
            this.cmbWindow.Name = "cmbWindow";
            this.cmbWindow.Size = new System.Drawing.Size(59, 21);
            this.cmbWindow.TabIndex = 9;
            // 
            // lblMedian
            // 
            this.lblMedian.Location = new System.Drawing.Point(17, 16);
            this.lblMedian.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMedian.Name = "lblMedian";
            this.lblMedian.Size = new System.Drawing.Size(84, 16);
            this.lblMedian.TabIndex = 8;
            this.lblMedian.Text = "Cửa sổ lọc(nxn):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 720);
            this.Controls.Add(this.grbMedian);
            this.Controls.Add(this.grbBilateral);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Filter Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAfter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbSpace)).EndInit();
            this.grbBilateral.ResumeLayout(false);
            this.grbBilateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbColor)).EndInit();
            this.grbMedian.ResumeLayout(false);
            this.ResumeLayout(false);

  }
  #endregion
  private PictureBox picBefore;
  private PictureBox picAfter;
  private Button btnChoose;
  private Button btnReset;
  private GroupBox groupBox1;
  private GroupBox groupBox2;
  private ComboBox comboBoxFilter;
  private TrackBar tbSpace;
  private Label lblSigmaSpace;
  private Button btnFilter;
        private GroupBox grbBilateral;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox grbMedian;
        private ComboBox cmbWindow;
        private Label lblMedian;
        private TrackBar tbColor;
        private Label lblSigmaColor;
    }
}
