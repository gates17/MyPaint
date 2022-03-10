using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
 
    public class PenShape : Shape
    {
        public PenShape(int axisXstart, int axisYstart, int axisXend, int axisYend, Pen pen)
            : base(axisXstart, axisYstart, axisXend, axisYend, pen) { }

        public override void Draw(Graphics graphics)
        {
            var pen = new Pen(Color.Red, 3);
            //var point1 = new Point(AxisXstart, AxisYstart);
            //var point2 = new Point(AxisXend, AxisYend);
            GraphicsPath graphicsPath = new();
            graphics.DrawPath(pen, graphicsPath);
        }

        public override void AddToDataSet(Shape shape)
        {
            DataRow dataRow = DataSetHelper.GetInstance().ShapesTable.NewRow();
            dataRow["Xstart"] = shape.AxisXstart;
            dataRow["Ystart"] = shape.AxisYstart;
            dataRow["Xend"] = shape.AxisXend;
            dataRow["Yend"] = shape.AxisYend;
            dataRow["Pen"] = shape.Pen;
            dataRow["Type"] = DesignType.Line;

            DataSetHelper.GetInstance().ShapesTable.Rows.Add(dataRow);
            DataSetHelper.GetInstance().Save();
        }

        public override void AddToDataSet(List<Shape> shapes)
        {
            foreach (PenShape shape in shapes)
            {
                this.AddToDataSet(shape);
            }
        }

        public override void RemoveFromDataSet(int index)
        {
            DataSetHelper.GetInstance().ShapesTable.Rows.RemoveAt(index);
            DataSetHelper.GetInstance().Save();
            //throw new NotImplementedException();
        }

        public override void UpdateToDataSet(int index, Shape shape)
        {
        }
    }
}
