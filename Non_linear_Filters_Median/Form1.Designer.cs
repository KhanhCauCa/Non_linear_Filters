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
   picBefore = new PictureBox();
   picAfter = new PictureBox();
   btnChoose = new Button();
   btnReset = new Button();
   groupBox1 = new GroupBox();
   groupBox2 = new GroupBox();
   comboBoxFilter = new ComboBox();
   trackBarBilateral = new TrackBar();
   lblTrackBarValue = new Label();
   btnFilter = new Button();
   ((System.ComponentModel.ISupportInitialize)picBefore).BeginInit();
   ((System.ComponentModel.ISupportInitialize)picAfter).BeginInit();
   groupBox1.SuspendLayout();
   groupBox2.SuspendLayout();
   ((System.ComponentModel.ISupportInitialize)trackBarBilateral).BeginInit();
   SuspendLayout();
   // 
   // picBefore
   // 
   picBefore.BackColor = SystemColors.Control;
   picBefore.Location = new Point(21, 39);
   picBefore.Margin = new Padding(4, 5, 4, 5);
   picBefore.Name = "picBefore";
   picBefore.Size = new Size(465, 551);
   picBefore.SizeMode = PictureBoxSizeMode.StretchImage;
   picBefore.TabIndex = 0;
   picBefore.TabStop = false;
   // 
   // picAfter
   // 
   picAfter.Location = new Point(20, 39);
   picAfter.Margin = new Padding(4, 5, 4, 5);
   picAfter.Name = "picAfter";
   picAfter.Size = new Size(465, 551);
   picAfter.SizeMode = PictureBoxSizeMode.StretchImage;
   picAfter.TabIndex = 1;
   picAfter.TabStop = false;
   // 
   // btnChoose
   // 
   btnChoose.Location = new Point(622, 124);
   btnChoose.Margin = new Padding(4, 5, 4, 5);
   btnChoose.Name = "btnChoose";
   btnChoose.Size = new Size(125, 59);
   btnChoose.TabIndex = 2;
   btnChoose.Text = "Choose Image";
   btnChoose.UseVisualStyleBackColor = true;
   btnChoose.Click += btnChoose_Click;
   // 
   // btnReset
   // 
   btnReset.Location = new Point(622, 489);
   btnReset.Margin = new Padding(4, 5, 4, 5);
   btnReset.Name = "btnReset";
   btnReset.Size = new Size(125, 59);
   btnReset.TabIndex = 2;
   btnReset.Text = "Reset";
   btnReset.UseVisualStyleBackColor = true;
   btnReset.Click += btnReset_Click;
   // 
   // groupBox1
   // 
   groupBox1.Controls.Add(picBefore);
   groupBox1.Location = new Point(60, 71);
   groupBox1.Name = "groupBox1";
   groupBox1.Size = new Size(504, 614);
   groupBox1.TabIndex = 4;
   groupBox1.TabStop = false;
   groupBox1.Text = "Before";
   // 
   // groupBox2
   // 
   groupBox2.Controls.Add(picAfter);
   groupBox2.Location = new Point(814, 71);
   groupBox2.Name = "groupBox2";
   groupBox2.Size = new Size(504, 614);
   groupBox2.TabIndex = 5;
   groupBox2.TabStop = false;
   groupBox2.Text = "After";
   // 
   // comboBoxFilter
   // 
   comboBoxFilter.DropDownStyle = ComboBoxStyle.DropDownList;
   comboBoxFilter.Location = new Point(622, 215);
   comboBoxFilter.Name = "comboBoxFilter";
   comboBoxFilter.Size = new Size(126, 28);
   comboBoxFilter.TabIndex = 6;
   comboBoxFilter.SelectedIndexChanged += comboBoxFilter_SelectedIndexChanged;
   // 
   // trackBarBilateral
   // 
   trackBarBilateral.Location = new Point(622, 304);
   trackBarBilateral.Name = "trackBarBilateral";
   trackBarBilateral.Size = new Size(125, 56);
   trackBarBilateral.TabIndex = 7;
   trackBarBilateral.Visible = false;
   trackBarBilateral.Scroll += trackBarBilateral_Scroll;
   // 
   // lblTrackBarValue
   // 
   lblTrackBarValue.Location = new Point(622, 370);
   lblTrackBarValue.Name = "lblTrackBarValue";
   lblTrackBarValue.Size = new Size(125, 25);
   lblTrackBarValue.TabIndex = 8;
   lblTrackBarValue.Text = "Mịn: 50";
   lblTrackBarValue.Visible = false;
   // 
   // btnFilter
   // 
   btnFilter.Location = new Point(623, 398);
   btnFilter.Name = "btnFilter";
   btnFilter.Size = new Size(125, 59);
   btnFilter.TabIndex = 8;
   btnFilter.Text = "Filter";
   btnFilter.Visible = false;
   btnFilter.Click += btnFilter_Click;
   // 
   // Form1
   // 
   AutoScaleDimensions = new SizeF(8F, 20F);
   AutoScaleMode = AutoScaleMode.Font;
   ClientSize = new Size(1422, 800);
   Controls.Add(comboBoxFilter);
   Controls.Add(trackBarBilateral);
   Controls.Add(lblTrackBarValue);
   Controls.Add(btnFilter);
   Controls.Add(btnChoose);
   Controls.Add(btnReset);
   Controls.Add(groupBox1);
   Controls.Add(groupBox2);
   Name = "Form1";
   Text = "Image Filter Application";
   Load += Form1_Load;
   ((System.ComponentModel.ISupportInitialize)picBefore).EndInit();
   ((System.ComponentModel.ISupportInitialize)picAfter).EndInit();
   groupBox1.ResumeLayout(false);
   groupBox2.ResumeLayout(false);
   ((System.ComponentModel.ISupportInitialize)trackBarBilateral).EndInit();
   ResumeLayout(false);
   PerformLayout();
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
