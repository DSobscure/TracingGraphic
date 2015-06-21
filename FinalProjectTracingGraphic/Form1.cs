using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FinalProjectTracingGraphic
{
    public partial class TracingPictureForm : Form
    {
        private bool isDrawing = false;
        private bool pointMode = false;

        private Point startPoint, oldPoint;

        private enum drawTools
        {
            Pencil = 0, Line, Rectangle, Ellipse, Circle, Bezier, Eraser, None, BSpline, Curve
        };
        private drawTools drawTool = drawTools.None;

        private Graphics drawingGraphic;
        private Graphics showingGraphic;
        private Graphics tempGraphic;

        private Image originPicture;
        private Image showingPicture;
        private Image drawingPicture;
        private Image tracedPicture;

        private Color foreColor = Color.Black;
        private Color backColor = Color.White;

        private Pen pen = new Pen(Color.Black);

        private List<Label> pointsLabel = new List<Label>();
        private List<Image> restoreTracedPool = new List<Image>();
        private List<Image> restoreShowingPool = new List<Image>();
        
        private string savePath = "";
        private StringBuilder curvePoints = new StringBuilder();

        private Label[] Colors = new Label[18];

        public TracingPictureForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i=0;i<Colors.Length;i++)
            {
                Colors[i] = new Label();
                Colors[i].Height = 30;
                Colors[i].Width = 30;
                Colors[i].Top = ColorPicker.Top + 31 * (i/3);
                Colors[i].Left = ColorPicker.Left + 31 * (i%3);
                Colors[i].MouseClick += ChangeColor;
            }

            Colors[0].BackColor = Color.Black;
            Colors[1].BackColor = Color.Gray;
            Colors[2].BackColor = Color.DarkRed;
            Colors[3].BackColor = Color.Red;
            Colors[4].BackColor = Color.Orange;
            Colors[5].BackColor = Color.Yellow;
            Colors[6].BackColor = Color.Green;
            Colors[7].BackColor = Color.Cyan;
            Colors[8].BackColor = Color.Blue;
            Colors[9].BackColor = Color.Purple;
            Colors[10].BackColor = Color.Brown;
            Colors[11].BackColor = Color.Pink;
            Colors[12].BackColor = Color.Gold;
            Colors[13].BackColor = Color.LightYellow;
            Colors[14].BackColor = Color.GreenYellow;
            Colors[15].BackColor = Color.LightSkyBlue;
            Colors[16].BackColor = Color.Navy;
            Colors[17].BackColor = Color.White;

            ColorPicker.Controls.AddRange(Colors);
            Graphics cleaner;
            originPicture = new Bitmap(1000, 600);
            cleaner = Graphics.FromImage(originPicture);
            cleaner.Clear(backColor);

            tracedPicture = new Bitmap(1000, 600);
            cleaner = Graphics.FromImage(tracedPicture);
            cleaner.Clear(backColor);

            showingPicture = new Bitmap(1000, 600);
            cleaner = Graphics.FromImage(showingPicture);
            cleaner.Clear(backColor);

            drawingPicture = new Bitmap(1000, 600);
            cleaner = Graphics.FromImage(drawingPicture);
            cleaner.Clear(backColor);

            DrawingPictureBox.Image = showingPicture;

            drawingGraphic = Graphics.FromImage(tracedPicture);
            showingGraphic = Graphics.FromImage(showingPicture);
        }
        private void LoadPicture(object sender, EventArgs e)
        {
            if(OpenPictureDialog.ShowDialog() == DialogResult.OK)
            {
                originPicture = Image.FromFile(OpenPictureDialog.FileName);
                showingPicture = (Image)originPicture.Clone();
                DrawingPictureBox.Image = showingPicture;
                showingGraphic = Graphics.FromImage(showingPicture);
                tracedPicture = new Bitmap(originPicture.Width, originPicture.Height);
                drawingGraphic = Graphics.FromImage(tracedPicture);
                ParameterTextBox.Clear();
            }
        }
        private void SavePictureItem_Click(object sender, EventArgs e)
        {
            if (savePath == "")
            {
                saveFileDialog.ShowDialog();
                savePath = saveFileDialog.FileName;
            }
            if (savePath != "")
            {
                tracedPicture.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        private void ClearGrapicItem_Click(object sender, EventArgs e)
        {
            drawingGraphic.Clear(backColor);
            showingPicture = originPicture;
            showingGraphic = Graphics.FromImage(originPicture);
            DrawingPictureBox.Image = originPicture;
        }       

        private void CheckBackground(object sender, MouseEventArgs e)
        {
            DrawingPictureBox.Image = originPicture;
        }
        private void CheckTraced(object sender, MouseEventArgs e)
        {
            DrawingPictureBox.Image = tracedPicture;
        }
        private void CheckOver(object sender, MouseEventArgs e)
        {
            DrawingPictureBox.Image = showingPicture;
        }
        private void RestoreButton_Click(object sender, EventArgs e)
        {
            if (restoreTracedPool.Count > 0)
            {
                tracedPicture = restoreTracedPool[restoreTracedPool.Count() - 1];
                restoreTracedPool.RemoveAt(restoreTracedPool.Count() - 1);
                drawingGraphic = Graphics.FromImage(tracedPicture);

                showingPicture = restoreShowingPool[restoreShowingPool.Count() - 1];
                restoreShowingPool.RemoveAt(restoreShowingPool.Count() - 1);
                showingGraphic = Graphics.FromImage(showingPicture);

                DrawingPictureBox.Image = showingPicture;
                RestoreButton.Text = "復原(" + restoreTracedPool.Count.ToString() + ")";
            }
        }
        private void Cancle_Click(object sender, EventArgs e)
        {
            foreach (Control control in ToolBox.Controls)
            {
                control.Enabled = true;
            }
            foreach (Label point in pointsLabel)
            {
                DrawingPictureBox.Controls.Remove(point);
            }
            Cancel.Visible = false;
            ParameterTextBox.Visible = false;
            DrawButtonParameter.Visible = false;
            if (pointMode)
            {
                RestoreButton.PerformClick();
            }
            pointsLabel.Clear();
            drawTool = drawTools.None;
            DrawCurveButton.Visible = false;
            PointSelectCombo.Visible = false;
            BSplineControlSwitch.Checked = false;
            BSplineControlSwitch.Visible = false;
            AutoDrawModeSwitch.Visible = false;
        }
        private void DrawCurveButton_Click(object sender, EventArgs e)
        {
            if (drawTool == drawTools.Bezier)
            {
                curvePoints.Append("Bezier:|");
                for (int i = 0; i < pointsLabel.Count; i++)
                {
                    curvePoints.Append("(" + (pointsLabel[i].Left + 2).ToString() + "," + (pointsLabel[i].Top + 2).ToString() + ")|");
                }
                curvePoints.Append("End ");
                DrawBezierCurve(showingGraphic);
                DrawBezierCurve(drawingGraphic);
            }
            else if (drawTool == drawTools.BSpline)
            {
                curvePoints.Append("BSpline:|");
                for (int i = 0; i < pointsLabel.Count; i++)
                {
                    curvePoints.Append("(" + (pointsLabel[i].Left + 2).ToString() + "," + (pointsLabel[i].Top + 2).ToString() + ")|");
                }
                curvePoints.Append("End ");
                for (int i = 0; i < pointsLabel.Count - 3; i++)
                {
                    DrawBSplineCurve(showingGraphic, i);
                    DrawBSplineCurve(drawingGraphic, i);
                }
            }
            else if (drawTool == drawTools.Curve)
            {
                Point[] points = new Point[pointsLabel.Count];
                for (int i = 0; i < pointsLabel.Count; i++)
                {
                    points[i] = new Point(pointsLabel[i].Left + 2, pointsLabel[i].Top + 2);
                }
                showingGraphic.DrawCurve(pen, points);
                drawingGraphic.DrawCurve(pen, points);
            }
            DrawCurveButton.Visible = false;
            PointSelectCombo.Visible = false;
            pointMode = false;
            foreach (Label point in pointsLabel)
            {
                DrawingPictureBox.Controls.Remove(point);
            }
            pointsLabel.Clear();
            DrawingPictureBox.Image = showingPicture;
        }
        private void DrawButtonParameter_Click(object sender, EventArgs e)
        {
            if (restoreTracedPool.Count > 9)
            {
                restoreTracedPool.RemoveAt(0);
                restoreShowingPool.RemoveAt(0);
            }
            restoreTracedPool.Add((Image)tracedPicture.Clone());
            restoreShowingPool.Add((Image)showingPicture.Clone());
            RestoreButton.Text = "復原(" + restoreTracedPool.Count.ToString() + ")";
            if (AutoDrawModeSwitch.Checked)
            {
                string[] curves = ParameterTextBox.Text.Trim().Split(' ');
                string filter1 =
                @"((Bezier:\|)|(BSpline:\|))(\(([0-9]+),([0-9]+)\)\|)+(End)";
                foreach (string curve in curves)
                {
                    if (!Regex.IsMatch(curve, filter1))
                    {
                        MessageBox.Show("格式錯誤" + curve);
                        return;
                    }
                    string[] points = curve.Split('|');
                    List<Point> pointList = new List<Point>();
                    if (points[0] == "Bezier:")
                    {
                        for (int i = 1; i < points.Length - 1; i++)
                        {
                            string[] coordinate = points[i].Split(',');
                            int x = int.Parse(coordinate[0].Substring(1));
                            int y = int.Parse(coordinate[1].Substring(0, coordinate[1].Length - 1));
                            pointList.Add(new Point(x, y));
                        }

                        int spanCount = 100;
                        double span = 1.0 / spanCount;
                        Point[] pointBuffer = new Point[spanCount];
                        double u = 0;
                        for (int i = 0; i < spanCount; i++)
                        {
                            Matrix parameterVector = new Matrix(new double[,] { { u * u * u, u * u, u, 1 } });
                            Matrix xPoints = new Matrix(new double[,] { { pointList[0].X }, { pointList[1].X }, { pointList[2].X }, { pointList[3].X } });
                            Matrix yPoints = new Matrix(new double[,] { { pointList[0].Y }, { pointList[1].Y }, { pointList[2].Y }, { pointList[3].Y } });
                            Matrix BezierDefaultMatrix = new Matrix(new double[,] { { -1.0, 3.0, -3.0, 1.0 }, { 3, -6, 3, 0 }, { -3, 3, 0, 0 }, { 1, 0, 0, 0 } });
                            double x = (parameterVector * BezierDefaultMatrix * xPoints)[0, 0];
                            double y = (parameterVector * BezierDefaultMatrix * yPoints)[0, 0];
                            pointBuffer[i] = new Point((int)x, (int)y);
                            u += span;
                        }
                        drawingGraphic.DrawLines(pen, pointBuffer);
                        showingGraphic.DrawLines(pen, pointBuffer);
                    }
                    else
                    {
                        for (int i = 1; i < points.Length - 1; i++)
                        {
                            string[] coordinate = points[i].Split(',');
                            int x = int.Parse(coordinate[0].Substring(1));
                            int y = int.Parse(coordinate[1].Substring(0, coordinate[1].Length - 1));
                            pointList.Add(new Point(x, y));
                        }

                        int spanCount = 100;
                        double span = 1.0 / spanCount;
                        Point[] pointBuffer = new Point[spanCount];

                        for (int index = 0; index < pointList.Count - 3; index++)
                        {
                            double u = 0;
                            for (int i = 0; i < spanCount; i++)
                            {
                                Matrix parameterVector = new Matrix(new double[,] { { u * u * u / 6.0, u * u / 6.0, u / 6.0, 1 / 6.0 } });
                                Matrix xPoints = new Matrix(new double[,] { { pointList[0 + index].X }, { pointList[1 + index].X }, { pointList[2 + index].X }, { pointList[3 + index].X } });
                                Matrix yPoints = new Matrix(new double[,] { { pointList[0 + index].Y }, { pointList[1 + index].Y }, { pointList[2 + index].Y }, { pointList[3 + index].Y } });
                                Matrix BSplineDefaultMatrix = new Matrix(new double[,] { { -1.0, 3.0, -3.0, 1.0 }, { 3, -6, 3, 0 }, { -3, 0, 3, 0 }, { 1, 4, 1, 0 } });
                                double x = (parameterVector * BSplineDefaultMatrix * xPoints)[0, 0];
                                double y = (parameterVector * BSplineDefaultMatrix * yPoints)[0, 0];
                                pointBuffer[i] = new Point((int)x, (int)y);
                                u += span;
                            }
                            drawingGraphic.DrawLines(pen, pointBuffer);
                            showingGraphic.DrawLines(pen, pointBuffer);
                        }

                    }
                    DrawingPictureBox.Image = showingPicture;
                }
            }
            else
            {
                string[] functions = ParameterTextBox.Text.Split(';');
                foreach (string function in functions)
                {
                    List<Interval> intervalList = new List<Interval>();
                    Polynomial polynomial = new Polynomial();

                    string[] function_intervals = function.Split(' ');
                    string[] function_items = function_intervals[0].Split('+');
                    string filter1 =
                    @"^(((-?)[0-9]+(?:\.[0-9]+)?))([x](\^(-?)([0-9]+(?:\.[0-9]+)?))?)?$";
                    foreach (string item in function_items)
                    {
                        if (!Regex.IsMatch(item, filter1))
                        {
                            MessageBox.Show("函數錯誤");
                            return;
                        }
                        if (item.Contains("x^"))
                        {
                            string[] coefs = item.Split('x');
                            string deg = coefs[1].Substring(1);

                            polynomial.Items.Add(new Item() { Degree = double.Parse((deg == "") ? "1" : deg), Coefficient = double.Parse((coefs[0] == "") ? "1" : coefs[0]) });
                        }
                        else if (item.Contains("x"))
                        {
                            string coef = item.Substring(0, item.Length - 1);
                            polynomial.Items.Add(new Item() { Degree = 1, Coefficient = double.Parse((coef != "") ? coef : "1") });
                        }
                        else
                        {
                            polynomial.Items.Add(new Item() { Degree = 0, Coefficient = double.Parse(item) });
                        }
                    }
                    string filter2 =
                    @"^\[((-?)[0-9]+(?:\.[0-9]+)?),((-?)[0-9]+(?:\.[0-9]+)?)\]$";
                    if (function_intervals.Length > 1)
                    {
                        for (int i = 1; i < function_intervals.Length; i++)
                        {
                            if (!Regex.IsMatch(function_intervals[i], filter2))
                            {
                                MessageBox.Show("區間格式錯誤");
                                return;
                            }
                            string[] bounds = function_intervals[i].Split(',');
                            double leftBound = double.Parse(bounds[0].Substring(1));
                            double rightBound = double.Parse(bounds[1].Substring(0, bounds[1].Length - 1));
                            intervalList.Add(new Interval() { LeftBound = leftBound, RightBound = rightBound });
                        }
                    }
                    else
                    {
                        MessageBox.Show("沒有區間");
                        return;
                    }
                    foreach (Interval i in intervalList)
                    {
                        List<Point> points = new List<Point>();
                        double spanCount = 50.0;
                        double span = (i.RightBound - i.LeftBound) / spanCount;
                        double preSlope = polynomial.dF(i.LeftBound);
                        for (double position = i.LeftBound; position <= i.RightBound; )
                        {
                            int x = (int)position;
                            int y = (int)polynomial.F(position);
                            if (0 <= x && x <= showingPicture.Width)
                            {
                                points.Add(new Point(x, y));
                            }
                            if (Math.Abs((preSlope - polynomial.dF(position)) / (polynomial.dF(position) + double.Epsilon)) < 0.01)
                            {
                                preSlope = polynomial.dF(position);
                                position += span;
                            }
                            else
                            {
                                preSlope = polynomial.dF(position);
                                position += 0.01*span;
                            }
                        }
                        //MessageBox.Show("描點數："+points.Count.ToString());
                        if (points.Count>0)
                        {
                            showingGraphic.DrawLines(pen, points.ToArray());
                        }
                        DrawingPictureBox.Image = showingPicture;
                    }
                }
            }
        }

        private void PictureMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!isDrawing)
                {
                    isDrawing = true;
                    startPoint = new Point(e.X, e.Y);
                    oldPoint = new Point(e.X, e.Y);
                }
                if (drawTool != drawTools.None && pointsLabel.Count == 0)
                {
                    SaveAction();
                }
            }
        }
        private void PictureMouseMove(object sender, MouseEventArgs e)
        {
            CoordinateLabel.Text = "("+e.X.ToString()+","+e.Y.ToString()+")";
            if (isDrawing)
            {
                if (drawingPicture is Image)
                {
                    drawingPicture.Dispose();
                }
                drawingPicture = (Image)showingPicture.Clone();
                switch (drawTool)
                {
                    #region Pencil
                    case drawTools.Pencil:
                        {
                            drawingGraphic.DrawLine(pen, oldPoint, new Point(e.X, e.Y));
                            showingGraphic.DrawLine(pen, oldPoint, new Point(e.X, e.Y));
                            oldPoint.X = e.X;
                            oldPoint.Y = e.Y;
                        }
                        break;
                    #endregion
                    #region Line
                    case drawTools.Line:
                        {
                            tempGraphic = Graphics.FromImage(drawingPicture);
                            tempGraphic.DrawLine(pen, startPoint, new Point(e.X, e.Y));
                        }
                        break;
                    #endregion
                    #region Rectangle
                    case drawTools.Rectangle:
                        {
                            tempGraphic = Graphics.FromImage(drawingPicture);
                            int startX, startY, width, height;
                            #region rectangle margin check
                            if (startPoint.X < e.X)
                            {
                                startX = startPoint.X;
                                width = e.X - startPoint.X;
                            }
                            else
                            {
                                startX = e.X;
                                width = startPoint.X - e.X;
                            }
                            if(startPoint.Y < e.Y)
                            {
                                startY = startPoint.Y;
                                height = e.Y - startPoint.Y;
                            }
                            else
                            {
                                startY = e.Y;
                                height = startPoint.Y - e.Y;
                            }
                            #endregion
                            tempGraphic.DrawRectangle(pen, startX, startY, width, height);
                        }
                        break;
                    #endregion
                    #region Ellipse
                    case drawTools.Ellipse:
                        {
                            tempGraphic = Graphics.FromImage(drawingPicture);
                            tempGraphic.DrawEllipse(pen, startPoint.X, startPoint.Y, e.X - startPoint.X, e.Y - startPoint.Y);
                        }
                        break;
                    #endregion
                    #region Circle
                    case drawTools.Circle:
                        {
                            tempGraphic = Graphics.FromImage(drawingPicture);
                            int radius = (int)Math.Sqrt((e.X - startPoint.X) * (e.X - startPoint.X) + (e.Y - startPoint.Y) * (e.Y - startPoint.Y));
                            tempGraphic.DrawEllipse(pen, startPoint.X - radius, startPoint.Y - radius, 2 * radius, 2 * radius);
                        }
                        break;
                    #endregion
                    #region Eraser
                    case drawTools.Eraser:
                        {
                            drawingGraphic.FillRectangle(new SolidBrush(backColor),new Rectangle(e.X - 10, e.Y - 10, 20, 20));
                            showingGraphic.DrawImage(originPicture, new Rectangle(e.X - 10, e.Y - 10, 20, 20), new Rectangle(e.X - 10, e.Y - 10, 20, 20), GraphicsUnit.Pixel);
                        }
                        break;
                    #endregion
                }
                DrawingPictureBox.Image = drawingPicture;
            }
        }
        private void PictureMouseUp(object sender, MouseEventArgs e)
        {
            if(isDrawing)
            {
                isDrawing = false;
                switch (drawTool)
                {
                    #region Line
                    case drawTools.Line:
                        {
                            drawingGraphic.DrawLine(pen, startPoint, new Point(e.X, e.Y));
                            showingGraphic.DrawLine(pen, startPoint, new Point(e.X, e.Y));
                        }
                        break;
                    #endregion
                    #region Rectangle
                    case drawTools.Rectangle:
                        {
                            int startX, startY, width, height;
                            #region rectangle margin check
                            if (startPoint.X < e.X)
                            {
                                startX = startPoint.X;
                                width = e.X - startPoint.X;
                            }
                            else
                            {
                                startX = e.X;
                                width = startPoint.X - e.X;
                            }
                            if (startPoint.Y < e.Y)
                            {
                                startY = startPoint.Y;
                                height = e.Y - startPoint.Y;
                            }
                            else
                            {
                                startY = e.Y;
                                height = startPoint.Y - e.Y;
                            }
                            #endregion
                            drawingGraphic.DrawRectangle(pen, startX, startY, width, height);
                            showingGraphic.DrawRectangle(pen, startX, startY, width, height);
                        }
                        break;
                    #endregion
                    #region Ellipse
                    case drawTools.Ellipse:
                        {
                            drawingGraphic.DrawEllipse(pen, startPoint.X, startPoint.Y, e.X - startPoint.X, e.Y - startPoint.Y);
                            showingGraphic.DrawEllipse(pen, startPoint.X, startPoint.Y, e.X - startPoint.X, e.Y - startPoint.Y);
                        }
                        break;
                    #endregion
                    #region Circle
                    case drawTools.Circle:
                        {
                            int radius = (int)Math.Sqrt((e.X - startPoint.X) * (e.X - startPoint.X) + (e.Y - startPoint.Y) * (e.Y - startPoint.Y));
                            drawingGraphic.DrawEllipse(pen, startPoint.X - radius, startPoint.Y - radius, 2 * radius, 2 * radius);
                            showingGraphic.DrawEllipse(pen, startPoint.X - radius, startPoint.Y - radius, 2 * radius, 2 * radius);
                        }
                        break;
                    #endregion
                    #region Bezier
                    case drawTools.Bezier:
                        {
                            if (pointsLabel.Count < 4)
                            {
                                pointMode = true;
                                Label point = new Label() { Height = 4, Width = 4, Left = e.X - 2, Top = e.Y - 2, BackColor = Color.Black };
                                pointsLabel.Add(point);
                                DrawingPictureBox.Controls.Add(point);
                                if (pointsLabel.Count == 4)
                                {
                                    DrawBezierCurve(showingGraphic);
                                    DrawCurveButton.Visible = true;
                                    PointSelectCombo.Visible = true;
                                }
                            }
                            else
                            {
                                int index = PointSelectCombo.SelectedIndex;
                                if (index != -1)
                                {
                                    pointsLabel[index].Left = e.X - 2;
                                    pointsLabel[index].Top = e.Y - 2;
                                }
                                RestoreButton.PerformClick();
                                SaveAction();
                                DrawBezierCurve(showingGraphic);
                            }
                        }
                        break;
                    #endregion
                    #region BSpline
                    case drawTools.BSpline:
                        {
                            if (!BSplineControlSwitch.Checked)
                            {
                                pointMode = true;
                                Label point = new Label() { Height = 4, Width = 4, Left = e.X - 2, Top = e.Y - 2, BackColor = Color.Black };
                                pointsLabel.Add(point);
                                PointSelectCombo.Items.Add("第"+pointsLabel.Count.ToString()+"點");
                                DrawingPictureBox.Controls.Add(point);
                                if (pointsLabel.Count == 4)
                                {
                                    DrawCurveButton.Visible = true;
                                    PointSelectCombo.Visible = true;
                                    BSplineControlSwitch.Visible = true;
                                }
                                if(pointsLabel.Count >= 4)
                                {
                                    DrawBSplineCurve(showingGraphic,pointsLabel.Count-4);
                                }
                            }
                            else
                            {
                                int index = PointSelectCombo.SelectedIndex;
                                if (index != -1)
                                {
                                    pointsLabel[index].Left = e.X - 2;
                                    pointsLabel[index].Top = e.Y - 2;
                                }
                                RestoreButton.PerformClick();
                                SaveAction();
                                for (int i = 0; i < pointsLabel.Count - 3; i++)
                                {
                                    DrawBSplineCurve(showingGraphic, i);
                                }
                            }
                        }
                        break;
                    #endregion
                    #region Curve
                    case drawTools.Curve:
                        {
                            Label point = new Label() { Height = 4, Width = 4, Left = e.X - 2, Top = e.Y - 2, BackColor = Color.Black };
                            pointsLabel.Add(point);
                            DrawingPictureBox.Controls.Add(point);
                            if(pointsLabel.Count > 1)
                            {
                                DrawCurveButton.Visible = true;
                            }
                        }
                        break;
                    #endregion
                }
                DrawingPictureBox.Image = showingPicture;
            }
        }
        private void CancleDrawing(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                isDrawing = false;
                DrawingPictureBox.Image = showingPicture;
            }
        }

        private void ChangeColor(object sender, MouseEventArgs e)
        {
            foreColor = ((Label)sender).BackColor;
            pen = new Pen(foreColor);
            ForeColorLabel.BackColor = foreColor;
        }
        private void DefineColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            foreColor = colorDialog.Color;
            pen = new Pen(foreColor);
            ForeColorLabel.BackColor = foreColor;
        }
        private void DrawButtonPencil_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Pencil;
        }
        private void DrawButtonLine_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Line;
        }
        private void DrawButtonRectangle_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Rectangle;
        }
        private void DrawButtonEllipse_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Ellipse;
        }
        private void DrawButtonCircle_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Circle;
        }
        private void DrawButtonEraser_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Eraser;
        }
        private void DrawButtonBSpline_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.BSpline;
            foreach (Control control in ToolBox.Controls)
            {
                control.Enabled = false;
            }
            Cancel.Visible = true;
            PointSelectCombo.Items.Clear();
        }
        private void DrawButtonBezier_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Bezier;
            foreach (Control control in ToolBox.Controls)
            {
                control.Enabled = false;
            }
            Cancel.Visible = true;
            PointSelectCombo.Items.Clear();
            PointSelectCombo.Items.Add("第1點");
            PointSelectCombo.Items.Add("第2點");
            PointSelectCombo.Items.Add("第3點");
            PointSelectCombo.Items.Add("第4點");
        }
        private void DrawButtonCurve_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Curve;
            foreach (Control control in ToolBox.Controls)
            {
                control.Enabled = false;
            }
            Cancel.Visible = true;
            DrawCurveButton.Visible = true;
        }
        private void DrawButtonAuto_Click(object sender, EventArgs e)
        {
            Cancel.Visible = true;
            ParameterTextBox.Visible = true;
            DrawButtonParameter.Visible = true;
            foreach (Control control in ToolBox.Controls)
            {
                control.Enabled = false;
            }
            AutoDrawModeSwitch.Visible = true;
        }
        private void ShowPointsButton_Click(object sender, EventArgs e)
        {
            if (curvePoints.Length > 0)
            {
                MessageBox.Show("已複製到剪貼簿!\n" + curvePoints.ToString());
                Clipboard.SetText(curvePoints.ToString());
            }
        }
        private void InstructionButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show
                ("關於自動繪圖：\n"+
                 "通常模式是函數繪圖，支援多項式整數或是小數系數和次方\n"+
                 "並加上繪圖區間。各個函數以;隔開\n"+
                 "範例 2x+100 [100,400];0.5x^2+-400x+80000 [100,600]\n\n"+
                 "描點模式為自動繪出由程式輸出的曲線");
        }

        private void DrawBezierCurve(Graphics graphic)
        {
            int spanCount = 100;
            double span = 1.0/spanCount;
            Point[] pointBuffer = new Point[spanCount];
            double u = 0;
            for(int i=0;i<spanCount;i++)
            {
                Matrix parameterVector = new Matrix(new double[,]{{u*u*u, u*u, u, 1}});
                Matrix xPoints = new Matrix(new double[,] { { pointsLabel[0].Left + 2 }, { pointsLabel[1].Left + 2 }, { pointsLabel[2].Left + 2 }, { pointsLabel[3].Left + 2 } });
                Matrix yPoints = new Matrix(new double[,] { { pointsLabel[0].Top + 2 }, { pointsLabel[1].Top + 2 }, { pointsLabel[2].Top + 2 }, { pointsLabel[3].Top + 2 } });
                Matrix BezierDefaultMatrix = new Matrix(new double[,]{{-1.0, 3.0,-3.0, 1.0},{ 3,-6, 3, 0},{-3, 3, 0, 0},{ 1, 0, 0, 0}});
                double x = (parameterVector*BezierDefaultMatrix*xPoints)[0, 0];
                double y = (parameterVector*BezierDefaultMatrix*yPoints)[0, 0];
                pointBuffer[i] = new Point((int)x,(int)y);
                u += span;
            }
            graphic.DrawLines(pen, pointBuffer);
        }
        private void DrawBSplineCurve(Graphics graphic, int index)
        {
            int spanCount = 100;
            double span = 1.0 / spanCount;
            Point[] pointBuffer = new Point[spanCount];
            double u = 0;
            for (int i = 0; i < spanCount; i++)
            {
                Matrix parameterVector = new Matrix(new double[,] { { u * u * u / 6.0, u * u / 6.0, u / 6.0, 1 / 6.0 } });
                Matrix xPoints = new Matrix(new double[,] { { pointsLabel[0 + index].Left + 2 }, { pointsLabel[1 + index].Left + 2 }, { pointsLabel[2 + index].Left + 2 }, { pointsLabel[3 + index].Left + 2 } });
                Matrix yPoints = new Matrix(new double[,] { { pointsLabel[0 + index].Top + 2 }, { pointsLabel[1 + index].Top + 2 }, { pointsLabel[2 + index].Top + 2 }, { pointsLabel[3 + index].Top + 2 } });
                Matrix BSplineDefaultMatrix = new Matrix(new double[,] { { -1.0, 3.0, -3.0, 1.0 }, { 3, -6, 3, 0 }, { -3, 0, 3, 0 }, { 1, 4, 1, 0 } });
                double x = (parameterVector*BSplineDefaultMatrix*xPoints)[0, 0];
                double y = (parameterVector*BSplineDefaultMatrix*yPoints)[0, 0];
                pointBuffer[i] = new Point((int)x, (int)y);
                u += span;
            }
            graphic.DrawLines(pen, pointBuffer);
        }     
        private void SaveAction()
        {
            if (restoreTracedPool.Count > 9)
            {
                restoreTracedPool.RemoveAt(0);
                restoreShowingPool.RemoveAt(0);
            }
            restoreTracedPool.Add((Image)tracedPicture.Clone());
            restoreShowingPool.Add((Image)showingPicture.Clone());
            RestoreButton.Text = "復原(" + restoreTracedPool.Count.ToString() + ")";
        }
    }
}
