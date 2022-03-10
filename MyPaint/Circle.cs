using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    public class Circle : Shape
    {
        public DesignType Type { get; set; }

        public Circle(int axisXstart, int axisYstart, int axisXend, int axisYend, Pen pen) 
            : base (axisXstart, axisYstart, axisXend, axisYend, pen) {}

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pen, AxisXstart, AxisYstart, AxisXend-AxisXstart, AxisYend-AxisYstart);
        }

        public override void AddToDataSet(Shape shape)
        {
            DataRow dataRow = DataSetHelper.GetInstance().ShapesTable.NewRow();
            dataRow["Xstart"] = shape.AxisXstart;
            dataRow["Ystart"] = shape.AxisYstart;
            dataRow["Xend"] = shape.AxisXend;
            dataRow["Yend"] = shape.AxisYend;
            dataRow["Pen"] = shape.Pen;
            dataRow["Type"] = DesignType.Circle;

            DataSetHelper.GetInstance().ShapesTable.Rows.Add(dataRow);
            DataSetHelper.GetInstance().Save();
        }

        public override void AddToDataSet(List<Shape> shapes)
        {
            foreach (Shape shape in shapes)
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
