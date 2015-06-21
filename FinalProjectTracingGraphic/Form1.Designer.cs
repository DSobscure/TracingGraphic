namespace FinalProjectTracingGraphic
{
    partial class TracingPictureForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ToolBox = new System.Windows.Forms.GroupBox();
            this.InstructionButton = new System.Windows.Forms.Button();
            this.ShowPointsButton = new System.Windows.Forms.Button();
            this.DrawButtonCurve = new System.Windows.Forms.Button();
            this.DrawButtonEraser = new System.Windows.Forms.Button();
            this.DrawButtonAuto = new System.Windows.Forms.Button();
            this.DrawButtonBSpline = new System.Windows.Forms.Button();
            this.DrawButtonBezier = new System.Windows.Forms.Button();
            this.DrawButtonCircle = new System.Windows.Forms.Button();
            this.DrawButtonEllipse = new System.Windows.Forms.Button();
            this.DrawButtonRectangle = new System.Windows.Forms.Button();
            this.DrawButtonLine = new System.Windows.Forms.Button();
            this.DrawButtonPencil = new System.Windows.Forms.Button();
            this.ColorPicker = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPictureSelectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SavePictureItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編輯ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearGrapicItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenPictureDialog = new System.Windows.Forms.OpenFileDialog();
            this.PictureContainer = new System.Windows.Forms.Panel();
            this.DrawingPictureBox = new System.Windows.Forms.PictureBox();
            this.CheckBackgroundButton = new System.Windows.Forms.Button();
            this.CheckTracedButton = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.ParameterTextBox = new System.Windows.Forms.TextBox();
            this.DrawButtonParameter = new System.Windows.Forms.Button();
            this.ForeColorLabel = new System.Windows.Forms.Label();
            this.DefineColorButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.DrawCurveButton = new System.Windows.Forms.Button();
            this.PointSelectCombo = new System.Windows.Forms.ComboBox();
            this.CoordinateLabel = new System.Windows.Forms.Label();
            this.BSplineControlSwitch = new System.Windows.Forms.CheckBox();
            this.AutoDrawModeSwitch = new System.Windows.Forms.CheckBox();
            this.ToolBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.PictureContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBox
            // 
            this.ToolBox.Controls.Add(this.InstructionButton);
            this.ToolBox.Controls.Add(this.ShowPointsButton);
            this.ToolBox.Controls.Add(this.DrawButtonCurve);
            this.ToolBox.Controls.Add(this.DrawButtonEraser);
            this.ToolBox.Controls.Add(this.DrawButtonAuto);
            this.ToolBox.Controls.Add(this.DrawButtonBSpline);
            this.ToolBox.Controls.Add(this.DrawButtonBezier);
            this.ToolBox.Controls.Add(this.DrawButtonCircle);
            this.ToolBox.Controls.Add(this.DrawButtonEllipse);
            this.ToolBox.Controls.Add(this.DrawButtonRectangle);
            this.ToolBox.Controls.Add(this.DrawButtonLine);
            this.ToolBox.Controls.Add(this.DrawButtonPencil);
            this.ToolBox.Location = new System.Drawing.Point(12, 310);
            this.ToolBox.Name = "ToolBox";
            this.ToolBox.Size = new System.Drawing.Size(125, 361);
            this.ToolBox.TabIndex = 0;
            this.ToolBox.TabStop = false;
            // 
            // InstructionButton
            // 
            this.InstructionButton.Location = new System.Drawing.Point(67, 297);
            this.InstructionButton.Name = "InstructionButton";
            this.InstructionButton.Size = new System.Drawing.Size(52, 49);
            this.InstructionButton.TabIndex = 11;
            this.InstructionButton.Text = "使用說明";
            this.InstructionButton.UseVisualStyleBackColor = true;
            this.InstructionButton.Click += new System.EventHandler(this.InstructionButton_Click);
            // 
            // ShowPointsButton
            // 
            this.ShowPointsButton.Location = new System.Drawing.Point(7, 297);
            this.ShowPointsButton.Name = "ShowPointsButton";
            this.ShowPointsButton.Size = new System.Drawing.Size(52, 49);
            this.ShowPointsButton.TabIndex = 10;
            this.ShowPointsButton.Text = "輸出曲線關鍵點";
            this.ShowPointsButton.UseVisualStyleBackColor = true;
            this.ShowPointsButton.Click += new System.EventHandler(this.ShowPointsButton_Click);
            // 
            // DrawButtonCurve
            // 
            this.DrawButtonCurve.Location = new System.Drawing.Point(7, 242);
            this.DrawButtonCurve.Name = "DrawButtonCurve";
            this.DrawButtonCurve.Size = new System.Drawing.Size(52, 49);
            this.DrawButtonCurve.TabIndex = 9;
            this.DrawButtonCurve.Text = "曲線";
            this.DrawButtonCurve.UseVisualStyleBackColor = true;
            this.DrawButtonCurve.Click += new System.EventHandler(this.DrawButtonCurve_Click);
            // 
            // DrawButtonEraser
            // 
            this.DrawButtonEraser.Location = new System.Drawing.Point(67, 132);
            this.DrawButtonEraser.Name = "DrawButtonEraser";
            this.DrawButtonEraser.Size = new System.Drawing.Size(52, 49);
            this.DrawButtonEraser.TabIndex = 6;
            this.DrawButtonEraser.Text = "橡皮擦";
            this.DrawButtonEraser.UseVisualStyleBackColor = true;
            this.DrawButtonEraser.Click += new System.EventHandler(this.DrawButtonEraser_Click);
            // 
            // DrawButtonAuto
            // 
            this.DrawButtonAuto.Location = new System.Drawing.Point(67, 242);
            this.DrawButtonAuto.Name = "DrawButtonAuto";
            this.DrawButtonAuto.Size = new System.Drawing.Size(52, 49);
            this.DrawButtonAuto.TabIndex = 7;
            this.DrawButtonAuto.Text = "自動繪圖";
            this.DrawButtonAuto.UseVisualStyleBackColor = true;
            this.DrawButtonAuto.Click += new System.EventHandler(this.DrawButtonAuto_Click);
            // 
            // DrawButtonBSpline
            // 
            this.DrawButtonBSpline.Location = new System.Drawing.Point(7, 187);
            this.DrawButtonBSpline.Name = "DrawButtonBSpline";
            this.DrawButtonBSpline.Size = new System.Drawing.Size(52, 49);
            this.DrawButtonBSpline.TabIndex = 1;
            this.DrawButtonBSpline.Text = "B-Spline";
            this.DrawButtonBSpline.UseVisualStyleBackColor = true;
            this.DrawButtonBSpline.Click += new System.EventHandler(this.DrawButtonBSpline_Click);
            // 
            // DrawButtonBezier
            // 
            this.DrawButtonBezier.Location = new System.Drawing.Point(67, 187);
            this.DrawButtonBezier.Name = "DrawButtonBezier";
            this.DrawButtonBezier.Size = new System.Drawing.Size(52, 49);
            this.DrawButtonBezier.TabIndex = 5;
            this.DrawButtonBezier.Text = "貝茲曲線";
            this.DrawButtonBezier.UseVisualStyleBackColor = true;
            this.DrawButtonBezier.Click += new System.EventHandler(this.DrawButtonBezier_Click);
            // 
            // DrawButtonCircle
            // 
            this.DrawButtonCircle.Location = new System.Drawing.Point(7, 132);
            this.DrawButtonCircle.Name = "DrawButtonCircle";
            this.DrawButtonCircle.Size = new System.Drawing.Size(52, 49);
            this.DrawButtonCircle.TabIndex = 4;
            this.DrawButtonCircle.Text = "正圓";
            this.DrawButtonCircle.UseVisualStyleBackColor = true;
            this.DrawButtonCircle.Click += new System.EventHandler(this.DrawButtonCircle_Click);
            this.DrawButtonCircle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CancleDrawing);
            // 
            // DrawButtonEllipse
            // 
            this.DrawButtonEllipse.Location = new System.Drawing.Point(67, 77);
            this.DrawButtonEllipse.Name = "DrawButtonEllipse";
            this.DrawButtonEllipse.Size = new System.Drawing.Size(52, 49);
            this.DrawButtonEllipse.TabIndex = 3;
            this.DrawButtonEllipse.Text = "橢圓";
            this.DrawButtonEllipse.UseVisualStyleBackColor = true;
            this.DrawButtonEllipse.Click += new System.EventHandler(this.DrawButtonEllipse_Click);
            this.DrawButtonEllipse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CancleDrawing);
            // 
            // DrawButtonRectangle
            // 
            this.DrawButtonRectangle.Location = new System.Drawing.Point(7, 77);
            this.DrawButtonRectangle.Name = "DrawButtonRectangle";
            this.DrawButtonRectangle.Size = new System.Drawing.Size(52, 49);
            this.DrawButtonRectangle.TabIndex = 2;
            this.DrawButtonRectangle.Text = "矩形";
            this.DrawButtonRectangle.UseVisualStyleBackColor = true;
            this.DrawButtonRectangle.Click += new System.EventHandler(this.DrawButtonRectangle_Click);
            this.DrawButtonRectangle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CancleDrawing);
            // 
            // DrawButtonLine
            // 
            this.DrawButtonLine.Location = new System.Drawing.Point(67, 22);
            this.DrawButtonLine.Name = "DrawButtonLine";
            this.DrawButtonLine.Size = new System.Drawing.Size(52, 49);
            this.DrawButtonLine.TabIndex = 1;
            this.DrawButtonLine.Text = "直線";
            this.DrawButtonLine.UseVisualStyleBackColor = true;
            this.DrawButtonLine.Click += new System.EventHandler(this.DrawButtonLine_Click);
            this.DrawButtonLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CancleDrawing);
            // 
            // DrawButtonPencil
            // 
            this.DrawButtonPencil.Location = new System.Drawing.Point(7, 22);
            this.DrawButtonPencil.Name = "DrawButtonPencil";
            this.DrawButtonPencil.Size = new System.Drawing.Size(52, 49);
            this.DrawButtonPencil.TabIndex = 0;
            this.DrawButtonPencil.Text = "鉛筆";
            this.DrawButtonPencil.UseVisualStyleBackColor = true;
            this.DrawButtonPencil.Click += new System.EventHandler(this.DrawButtonPencil_Click);
            // 
            // ColorPicker
            // 
            this.ColorPicker.Location = new System.Drawing.Point(12, 27);
            this.ColorPicker.Name = "ColorPicker";
            this.ColorPicker.Size = new System.Drawing.Size(125, 220);
            this.ColorPicker.TabIndex = 1;
            this.ColorPicker.TabStop = false;
            this.ColorPicker.Text = "顏色";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案ToolStripMenuItem,
            this.編輯ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadPictureSelectItem,
            this.SavePictureItem});
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.檔案ToolStripMenuItem.Text = "檔案";
            // 
            // LoadPictureSelectItem
            // 
            this.LoadPictureSelectItem.Name = "LoadPictureSelectItem";
            this.LoadPictureSelectItem.Size = new System.Drawing.Size(152, 22);
            this.LoadPictureSelectItem.Text = "載入底圖";
            this.LoadPictureSelectItem.Click += new System.EventHandler(this.LoadPicture);
            // 
            // SavePictureItem
            // 
            this.SavePictureItem.Name = "SavePictureItem";
            this.SavePictureItem.Size = new System.Drawing.Size(152, 22);
            this.SavePictureItem.Text = "儲存圖片";
            this.SavePictureItem.Click += new System.EventHandler(this.SavePictureItem_Click);
            // 
            // 編輯ToolStripMenuItem
            // 
            this.編輯ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearGrapicItem});
            this.編輯ToolStripMenuItem.Name = "編輯ToolStripMenuItem";
            this.編輯ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.編輯ToolStripMenuItem.Text = "編輯";
            // 
            // ClearGrapicItem
            // 
            this.ClearGrapicItem.Name = "ClearGrapicItem";
            this.ClearGrapicItem.Size = new System.Drawing.Size(124, 22);
            this.ClearGrapicItem.Text = "清除畫布";
            this.ClearGrapicItem.Click += new System.EventHandler(this.ClearGrapicItem_Click);
            // 
            // OpenPictureDialog
            // 
            this.OpenPictureDialog.FileName = "openFileDialog1";
            this.OpenPictureDialog.Filter = "Image Files(*.bmp;*.jpg;*.png) | *.bmp;*.jpg;*.png";
            // 
            // PictureContainer
            // 
            this.PictureContainer.AutoScroll = true;
            this.PictureContainer.BackColor = System.Drawing.SystemColors.Window;
            this.PictureContainer.Controls.Add(this.DrawingPictureBox);
            this.PictureContainer.Location = new System.Drawing.Point(156, 102);
            this.PictureContainer.Name = "PictureContainer";
            this.PictureContainer.Size = new System.Drawing.Size(1000, 600);
            this.PictureContainer.TabIndex = 4;
            // 
            // DrawingPictureBox
            // 
            this.DrawingPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.DrawingPictureBox.Location = new System.Drawing.Point(0, 0);
            this.DrawingPictureBox.Name = "DrawingPictureBox";
            this.DrawingPictureBox.Size = new System.Drawing.Size(100, 50);
            this.DrawingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.DrawingPictureBox.TabIndex = 0;
            this.DrawingPictureBox.TabStop = false;
            this.DrawingPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureMouseDown);
            this.DrawingPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureMouseMove);
            this.DrawingPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureMouseUp);
            // 
            // CheckBackgroundButton
            // 
            this.CheckBackgroundButton.Location = new System.Drawing.Point(156, 40);
            this.CheckBackgroundButton.Name = "CheckBackgroundButton";
            this.CheckBackgroundButton.Size = new System.Drawing.Size(75, 27);
            this.CheckBackgroundButton.TabIndex = 5;
            this.CheckBackgroundButton.Text = "檢查底圖";
            this.CheckBackgroundButton.UseVisualStyleBackColor = true;
            this.CheckBackgroundButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckBackground);
            this.CheckBackgroundButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CheckOver);
            // 
            // CheckTracedButton
            // 
            this.CheckTracedButton.Location = new System.Drawing.Point(156, 73);
            this.CheckTracedButton.Name = "CheckTracedButton";
            this.CheckTracedButton.Size = new System.Drawing.Size(75, 23);
            this.CheckTracedButton.TabIndex = 6;
            this.CheckTracedButton.Text = "檢查描圖";
            this.CheckTracedButton.UseVisualStyleBackColor = true;
            this.CheckTracedButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckTraced);
            this.CheckTracedButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CheckOver);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(237, 73);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Visible = false;
            this.Cancel.Click += new System.EventHandler(this.Cancle_Click);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Location = new System.Drawing.Point(237, 40);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(78, 27);
            this.RestoreButton.TabIndex = 8;
            this.RestoreButton.Text = "復原";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // ParameterTextBox
            // 
            this.ParameterTextBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ParameterTextBox.Location = new System.Drawing.Point(321, 40);
            this.ParameterTextBox.Name = "ParameterTextBox";
            this.ParameterTextBox.Size = new System.Drawing.Size(613, 27);
            this.ParameterTextBox.TabIndex = 9;
            this.ParameterTextBox.Visible = false;
            // 
            // DrawButtonParameter
            // 
            this.DrawButtonParameter.Location = new System.Drawing.Point(940, 40);
            this.DrawButtonParameter.Name = "DrawButtonParameter";
            this.DrawButtonParameter.Size = new System.Drawing.Size(73, 26);
            this.DrawButtonParameter.TabIndex = 10;
            this.DrawButtonParameter.Text = "繪圖";
            this.DrawButtonParameter.UseVisualStyleBackColor = true;
            this.DrawButtonParameter.Visible = false;
            this.DrawButtonParameter.Click += new System.EventHandler(this.DrawButtonParameter_Click);
            // 
            // ForeColorLabel
            // 
            this.ForeColorLabel.BackColor = System.Drawing.Color.Black;
            this.ForeColorLabel.Location = new System.Drawing.Point(17, 254);
            this.ForeColorLabel.Name = "ForeColorLabel";
            this.ForeColorLabel.Size = new System.Drawing.Size(54, 50);
            this.ForeColorLabel.TabIndex = 11;
            // 
            // DefineColorButton
            // 
            this.DefineColorButton.Location = new System.Drawing.Point(78, 254);
            this.DefineColorButton.Name = "DefineColorButton";
            this.DefineColorButton.Size = new System.Drawing.Size(53, 50);
            this.DefineColorButton.TabIndex = 12;
            this.DefineColorButton.Text = "自定色彩";
            this.DefineColorButton.UseVisualStyleBackColor = true;
            this.DefineColorButton.Click += new System.EventHandler(this.DefineColorButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Image|.png";
            // 
            // DrawCurveButton
            // 
            this.DrawCurveButton.Location = new System.Drawing.Point(321, 73);
            this.DrawCurveButton.Name = "DrawCurveButton";
            this.DrawCurveButton.Size = new System.Drawing.Size(75, 23);
            this.DrawCurveButton.TabIndex = 13;
            this.DrawCurveButton.Text = "繪製曲線";
            this.DrawCurveButton.UseVisualStyleBackColor = true;
            this.DrawCurveButton.Visible = false;
            this.DrawCurveButton.Click += new System.EventHandler(this.DrawCurveButton_Click);
            // 
            // PointSelectCombo
            // 
            this.PointSelectCombo.FormattingEnabled = true;
            this.PointSelectCombo.Location = new System.Drawing.Point(402, 73);
            this.PointSelectCombo.Name = "PointSelectCombo";
            this.PointSelectCombo.Size = new System.Drawing.Size(121, 20);
            this.PointSelectCombo.TabIndex = 15;
            this.PointSelectCombo.Visible = false;
            // 
            // CoordinateLabel
            // 
            this.CoordinateLabel.AutoSize = true;
            this.CoordinateLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CoordinateLabel.Location = new System.Drawing.Point(16, 674);
            this.CoordinateLabel.Name = "CoordinateLabel";
            this.CoordinateLabel.Size = new System.Drawing.Size(0, 16);
            this.CoordinateLabel.TabIndex = 16;
            // 
            // BSplineControlSwitch
            // 
            this.BSplineControlSwitch.AutoSize = true;
            this.BSplineControlSwitch.Location = new System.Drawing.Point(529, 73);
            this.BSplineControlSwitch.Name = "BSplineControlSwitch";
            this.BSplineControlSwitch.Size = new System.Drawing.Size(84, 16);
            this.BSplineControlSwitch.TabIndex = 17;
            this.BSplineControlSwitch.Text = "調整控制點";
            this.BSplineControlSwitch.UseVisualStyleBackColor = true;
            this.BSplineControlSwitch.Visible = false;
            // 
            // AutoDrawModeSwitch
            // 
            this.AutoDrawModeSwitch.AutoSize = true;
            this.AutoDrawModeSwitch.Location = new System.Drawing.Point(1019, 46);
            this.AutoDrawModeSwitch.Name = "AutoDrawModeSwitch";
            this.AutoDrawModeSwitch.Size = new System.Drawing.Size(96, 16);
            this.AutoDrawModeSwitch.TabIndex = 18;
            this.AutoDrawModeSwitch.Text = "換成描點模式";
            this.AutoDrawModeSwitch.UseVisualStyleBackColor = true;
            this.AutoDrawModeSwitch.Visible = false;
            // 
            // TracingPictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1184, 712);
            this.Controls.Add(this.AutoDrawModeSwitch);
            this.Controls.Add(this.BSplineControlSwitch);
            this.Controls.Add(this.CoordinateLabel);
            this.Controls.Add(this.PointSelectCombo);
            this.Controls.Add(this.DrawCurveButton);
            this.Controls.Add(this.DefineColorButton);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.ForeColorLabel);
            this.Controls.Add(this.DrawButtonParameter);
            this.Controls.Add(this.ParameterTextBox);
            this.Controls.Add(this.RestoreButton);
            this.Controls.Add(this.CheckTracedButton);
            this.Controls.Add(this.CheckBackgroundButton);
            this.Controls.Add(this.PictureContainer);
            this.Controls.Add(this.ColorPicker);
            this.Controls.Add(this.ToolBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TracingPictureForm";
            this.Text = "TracingPicture";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ToolBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PictureContainer.ResumeLayout(false);
            this.PictureContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ToolBox;
        private System.Windows.Forms.Button DrawButtonAuto;
        private System.Windows.Forms.Button DrawButtonEraser;
        private System.Windows.Forms.Button DrawButtonBSpline;
        private System.Windows.Forms.Button DrawButtonBezier;
        private System.Windows.Forms.Button DrawButtonCircle;
        private System.Windows.Forms.Button DrawButtonEllipse;
        private System.Windows.Forms.Button DrawButtonRectangle;
        private System.Windows.Forms.Button DrawButtonLine;
        private System.Windows.Forms.Button DrawButtonPencil;
        private System.Windows.Forms.GroupBox ColorPicker;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編輯ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadPictureSelectItem;
        private System.Windows.Forms.OpenFileDialog OpenPictureDialog;
        private System.Windows.Forms.Panel PictureContainer;
        private System.Windows.Forms.PictureBox DrawingPictureBox;
        private System.Windows.Forms.Button CheckBackgroundButton;
        private System.Windows.Forms.Button CheckTracedButton;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.TextBox ParameterTextBox;
        private System.Windows.Forms.Button DrawButtonParameter;
        private System.Windows.Forms.ToolStripMenuItem ClearGrapicItem;
        private System.Windows.Forms.Label ForeColorLabel;
        private System.Windows.Forms.Button DefineColorButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripMenuItem SavePictureItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button ShowPointsButton;
        private System.Windows.Forms.Button DrawButtonCurve;
        private System.Windows.Forms.Button DrawCurveButton;
        private System.Windows.Forms.ComboBox PointSelectCombo;
        private System.Windows.Forms.Label CoordinateLabel;
        private System.Windows.Forms.CheckBox BSplineControlSwitch;
        private System.Windows.Forms.CheckBox AutoDrawModeSwitch;
        private System.Windows.Forms.Button InstructionButton;
    }
}

