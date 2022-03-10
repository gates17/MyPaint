using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    public abstract class Shape
    {
        public int AxisXstart { get; set; }
        public int AxisYstart { get; set; }
        public int AxisYend { get; set; }
        public int AxisXend { get; set; }
        public Pen Pen { get; set; }

        public Shape(int axisXstart, int axisYstart, int axisXend, int axisYend, Pen pen)
        {
            AxisXstart = axisXstart;
            AxisYstart = axisYstart;
            AxisYend = axisYend;
            AxisXend = axisXend;
            Pen = pen;
        }

        public abstract void Draw(Graphics graphics);

        public abstract void AddToDataSet(Shape shape);
        public abstract void AddToDataSet(List<Shape> shapes);
        public abstract void RemoveFromDataSet(int index);
        public abstract void UpdateToDataSet(int index, Shape shape);

        //public virtual Shape Get(int index)
        //{
        //    DataSetHelper dataSetHelper = DataSetHelper.GetInstance();
        //    var rowToUpdate = dataSetHelper.ShapesTable.Rows[index];
        //    AxisXstart = int.Parse(rowToUpdate[0].ToString());
        //    AxisYstart = int.Parse(rowToUpdate[1].ToString());
        //    AxisXend = int.Parse(rowToUpdate[2].ToString());
        //    AxisYend = int.Parse(rowToUpdate[3].ToString());

        //    return new Shape();
        //}


 }
}
