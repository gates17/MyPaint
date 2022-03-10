using System.Data;

namespace MyPaint
{
    public enum DesignType
    {
        Line,
        Circle,
        Rectangle,
        Pen
    }

    public partial class Form1 : Form
    {
        bool isMousePressed;
        int axisXstart, axisYstart;

        //Line line;
        List<Shape> shapes = new();
        Shape shape;
        //DataSetHelper dataSetHelper;

        DesignType designType = DesignType.Line;
        Pen pen;
        //System.Drawing.Drawing2D.GraphicsPath mouseMovement;
        public Form1()
        {
            InitializeComponent();
            this.isMousePressed = false;

            pen = new Pen(Color.Black, 1);

            #region auto load
            //DataSetHelper dataSetHelper = DataSetHelper.GetInstance();

            ////metodo get 2
            //foreach(DataRow row in dataSetHelper.ShapesTable.Rows)
            //{
            //    //MessageBox.Show(dataSetHelper.ShapesTable.Columns[DataSetHelper.COLUMN_SHAPE_TYPE].DefaultValue.ToString());
            //    DataTable dataTable = new DataTable("Shape");
            //    dataTable = dataSetHelper.ShapesTable;
            //    for (int index = 0; index < row.ItemArray.Count(); index++)
            //        dataTable.Columns[index].DefaultValue = row.ItemArray[index].ToString();

            //    switch(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_TYPE].DefaultValue)
            //    {
            //        case "Line":
            //            shapes.Add(
            //                new Line(
            //                    int.Parse(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_AXISXSTART].DefaultValue.ToString()),
            //                    int.Parse(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_AXISYSTART].DefaultValue.ToString()),
            //                    int.Parse(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_AXISXEND].DefaultValue.ToString()),
            //                    int.Parse(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_AXISYEND].DefaultValue.ToString()),
            //                    pen
            //                )
            //            );
            //            break;
            //        case "Circle":
            //            shapes.Add(
            //                new Circle(
            //                    int.Parse(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_AXISXSTART].DefaultValue.ToString()),
            //                    int.Parse(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_AXISYSTART].DefaultValue.ToString()),
            //                    int.Parse(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_AXISXEND].DefaultValue.ToString()),
            //                    int.Parse(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_AXISYEND].DefaultValue.ToString()),
            //                    pen
            //                )
            //            );
            //            break;
            //        case "Rectangle":
            //            shapes.Add(
            //                new Rectangle(
            //                    int.Parse(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_AXISXSTART].DefaultValue.ToString()),
            //                    int.Parse(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_AXISYSTART].DefaultValue.ToString()),
            //                    int.Parse(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_AXISXEND].DefaultValue.ToString()),
            //                    int.Parse(dataTable.Columns[DataSetHelper.COLUMN_SHAPE_AXISYEND].DefaultValue.ToString()),
            //                    pen
            //                )
            //            );
            //            break;
            //        case "PenShape":
            //            break;
            //    }
            //}
            #endregion

            #region get shapes old
            //metodo get 1
            //var table = dataSetHelper.DrawingDataSet.Tables;
            //var size = table.Count;

            //for (int i = 0;i < size;i++)
            //{
            //    var rows = table[i].Rows;
            //    for (int j = 0; j < rows.Count; j++)
            //    {
            //        var b = rows[j].ItemArray;
            //        if (b[0] != null)
            //        {
            //            switch (b[0].ToString())
            //            {
            //                case "Line":
            //                    try
            //                    {
            //                        shapes.Add(new Line(int.Parse(b[1].ToString()), int.Parse(b[2].ToString()), int.Parse(b[3].ToString()), int.Parse(b[4].ToString()), pen));
            //                    }
            //                    catch (Exception)
            //                    {
            //                        continue;
            //                        //throw;
            //                    }
            //                    break;
            //                case "Circle":
            //                    try
            //                    {
            //                        shapes.Add(new Circle(int.Parse(b[1].ToString()), int.Parse(b[2].ToString()), int.Parse(b[3].ToString()), int.Parse(b[4].ToString()), pen));
            //                    }
            //                    catch (Exception)
            //                    {
            //                        continue;
            //                        //throw;
            //                    }
            //                    break;
            //                case "Rectangle":
            //                    try
            //                    {
            //                        shapes.Add(new Rectangle(int.Parse(b[1].ToString()), int.Parse(b[2].ToString()), int.Parse(b[3].ToString()), int.Parse(b[4].ToString()), pen));
            //                    }
            //                    catch (Exception)
            //                    {
            //                        continue;
            //                        //throw;
            //                    }
            //                    break;
            //                case "Pen":
            //                    break;
            //            }
            //        }
            //    }
            //}
            #endregion

            //mouseMovement = new System.Drawing.Drawing2D.GraphicsPath();
        }

        private void panelDrawing_Paint(object sender, PaintEventArgs e)
        {


            Graphics graphics = e.Graphics;
            foreach(Shape shape in shapes)
            {
                shape.Draw(graphics);
            }
            if (shape != null)
                shape.Draw(graphics);
        }

        private void panelDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            isMousePressed = true;
            axisXstart = e.X; //Starting x and Y
            axisYstart = e.Y;
            //panelDrawing.Cursor = Cursors.Cross;

        }

        private void panelDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            switch (designType)
            {
                case DesignType.Line:
                    shapes.Add(new Line(axisXstart, axisYstart, e.X, e.Y, pen));
                    break;
                case DesignType.Circle:
                    shapes.Add(new Circle(axisXstart, axisYstart, e.X, e.Y, pen));
                    break;
                case DesignType.Rectangle:
                    shapes.Add(new Rectangle(axisXstart, axisYstart, e.X, e.Y, pen));
                    break;
                case DesignType.Pen:
                    break;
            }

            // shape ou dataset?
            isMousePressed = false;

            //panelDrawing.Cursor = Cursors.Default;
        }

        private void panelDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePressed)
            {
                switch (designType)
                {
                    case DesignType.Line:
                        shape = new Line(axisXstart, axisYstart, e.X, e.Y, pen);
                        break;
                    case DesignType.Circle:
                        shape = new Circle(axisXstart, axisYstart, e.X, e.Y, pen);
                        break;
                    case DesignType.Rectangle:
                        shape = new Rectangle(axisXstart, axisYstart, e.X, e.Y, pen);
                        break;
                    case DesignType.Pen:
                        break;
                }


                panelDrawing.Refresh();
            }
            //mouseMovement.AddLine(axisXstart, axisYstart, axisXend, axisYend);
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            designType = DesignType.Line;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            designType = DesignType.Circle;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            designType = DesignType.Rectangle;
        }

        private void buttonPen_Click(object sender, EventArgs e)
        {
            designType = DesignType.Pen;
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.Red, 3);
        }

        private void buttonBlack_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.Black, 1);
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {

        }


        private void loadButton_Click(object sender, EventArgs e)
        {
            this.shapes.AddRange(DataSetHelper.GetFromDataSet(pen));
            panelDrawing.Refresh();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            foreach (Shape shape in shapes)
            {
                if (!shape.Equals(null))
                {
                    switch (shape)
                    {
                        case Circle:
                            this.shape = shape as Circle;
                            break;
                        case Line:
                            this.shape = shape as Line;
                            break;
                        case Rectangle:
                            this.shape = shape as Rectangle;
                            break;
                    }
                    this.shape.AddToDataSet(shape);
                }
            }
            this.shape = null;
            panelDrawing.Refresh();
        }
    }
}