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

        List<Shape> shapes = new();
        List<Shape> shapesToSave = new();
        Shape shape;
        DataSetHelper dataSetHelper;

        DesignType designType = DesignType.Line;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            this.isMousePressed = false;
            pen = new Pen(Color.Black, 1);

        }

        private void panelDrawing_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (!shapes.Equals(null))
                foreach(Shape shape in shapes)
                {
                    if (shape != null)
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
        }

        private void panelDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            switch (designType)
            {
                case DesignType.Line:
                    shapesToSave.Add(new Line(axisXstart, axisYstart, e.X, e.Y, pen));
                    shapes.Add(new Line(axisXstart, axisYstart, e.X, e.Y, pen));
                    break;
                case DesignType.Circle:
                    shapesToSave.Add(new Circle(axisXstart, axisYstart, e.X, e.Y, pen));
                    shapes.Add(new Circle(axisXstart, axisYstart, e.X, e.Y, pen));
                    break;
                case DesignType.Rectangle:
                    shapesToSave.Add(new Rectangle(axisXstart, axisYstart, e.X, e.Y, pen));
                    shapes.Add(new Rectangle(axisXstart, axisYstart, e.X, e.Y, pen));
                    break;
                case DesignType.Pen:
                    break;
            }

            // shape ou dataset?
            isMousePressed = false;
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
            if (shapesToSave.Count > 0)
            {
                shapes.Remove(shapes.Last());
                shapesToSave.Remove(shapesToSave.Last());
                shape = null;
                panelDrawing.Refresh();
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml files (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                DataSetHelper.SetFileName(fileName);
            }
            this.shapes.Clear();
            this.shapesToSave.Clear();
            panelDrawing.Refresh();
            this.shapes.AddRange(DataSetHelper.GetFromDataSet(pen));
            panelDrawing.Refresh();
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xml files (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                DataSetHelper.SetFileName(fileName);
            }
            //if(shapes.Count != shapesToSave.Count)
            //    shapesToSave = shapes;
            
            foreach (Shape shape in shapesToSave)
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
            this.shapesToSave.Clear();
            panelDrawing.Refresh();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            foreach (Shape shape in shapesToSave)
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
            this.shapesToSave.Clear();
            panelDrawing.Refresh();
        }
    }
}