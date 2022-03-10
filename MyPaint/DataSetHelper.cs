using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    public class DataSetHelper
    {
        //BOOKS TABLE FIELD NAMES
        public static readonly string TABLE_SHAPES = "Shape";
        public static readonly string COLUMN_SHAPE_TYPE = "Type";
        public static readonly string COLUMN_SHAPE_AXISXSTART = "Xstart";
        public static readonly string COLUMN_SHAPE_AXISYSTART = "Ystart";
        public static readonly string COLUMN_SHAPE_AXISXEND = "Xend";
        public static readonly string COLUMN_SHAPE_AXISYEND = "Yend";
        public static readonly string COLUMN_SHAPE_PEN = "Pen";


        public string filename = "mydrawings2.xml";

        private static DataSetHelper instance;



        /// <summary>
        /// Library DataSet access properties
        /// </summary>
        public DataSet DrawingDataSet { get; set; }
        /// <summary>
        /// Books Table access properties
        /// </summary>
        public DataTable ShapesTable { get; set; }


        /// <summary>
        /// Library Init Constructor
        /// </summary>
        private DataSetHelper()
        {
            DrawingDataSet = new DataSet("Shapes");

            ShapesTable = new DataTable(TABLE_SHAPES);
            ShapesTable.Columns.Add(COLUMN_SHAPE_TYPE);
            ShapesTable.Columns.Add(COLUMN_SHAPE_AXISXSTART);
            ShapesTable.Columns.Add(COLUMN_SHAPE_AXISYSTART);
            ShapesTable.Columns.Add(COLUMN_SHAPE_AXISXEND);
            ShapesTable.Columns.Add(COLUMN_SHAPE_AXISYEND);
            ShapesTable.Columns.Add(COLUMN_SHAPE_PEN);

            DrawingDataSet.Tables.Add(ShapesTable);

            Load();
        }

        /// <summary>
        /// Open Xml File
        /// </summary>
        private void Load()
        {
            try
            {
                DrawingDataSet.ReadXml(filename);
            }
            catch (FileNotFoundException)
            {

            }
        }

        /// <summary>
        /// Save Xml File
        /// </summary>
        public void Save()
        {
            DrawingDataSet.WriteXml(filename);
        }

        /// <summary>
        /// DataSetHelper Singleton
        /// </summary>
        /// <returns></returns>
        public static DataSetHelper GetInstance()
        {
            if (instance == null)
                instance = new DataSetHelper();
            return instance;
        }

        /// <summary>
        /// Reads data from text file and converts to Shapes List
        /// </summary>
        /// <param name="pen"></param>
        /// <returns></returns>
        public static List<Shape> GetFromDataSet(Pen pen)
        {
            DataSetHelper dataSetHelper = GetInstance(); //DataSetHelper.GetInstance()
            List<Shape> shapes = new();

            foreach (DataRow row in dataSetHelper.ShapesTable.Rows)
            {
                DataTable dataTable = new("Shape");
                dataTable = dataSetHelper.ShapesTable;
                for (int index = 0; index < row.ItemArray.Length ; index++)
                    dataTable.Columns[index].DefaultValue = row.ItemArray[index].ToString();

                switch (dataTable.Columns[COLUMN_SHAPE_TYPE].DefaultValue)
                {
                    case "Line":
                        shapes.Add(
                            new Line(
                                int.Parse(dataTable.Columns[COLUMN_SHAPE_AXISXSTART].DefaultValue.ToString()),
                                int.Parse(dataTable.Columns[COLUMN_SHAPE_AXISYSTART].DefaultValue.ToString()),
                                int.Parse(dataTable.Columns[COLUMN_SHAPE_AXISXEND].DefaultValue.ToString()),
                                int.Parse(dataTable.Columns[COLUMN_SHAPE_AXISYEND].DefaultValue.ToString()),
                                pen
                            )
                        );
                        break;
                    case "Circle":
                        shapes.Add(
                            new Circle(
                                int.Parse(dataTable.Columns[COLUMN_SHAPE_AXISXSTART].DefaultValue.ToString()),
                                int.Parse(dataTable.Columns[COLUMN_SHAPE_AXISYSTART].DefaultValue.ToString()),
                                int.Parse(dataTable.Columns[COLUMN_SHAPE_AXISXEND].DefaultValue.ToString()),
                                int.Parse(dataTable.Columns[COLUMN_SHAPE_AXISYEND].DefaultValue.ToString()),
                                pen
                            )
                        );
                        break;
                    case "Rectangle":
                        shapes.Add(
                            new Rectangle(
                                int.Parse(dataTable.Columns[COLUMN_SHAPE_AXISXSTART].DefaultValue.ToString()),
                                int.Parse(dataTable.Columns[COLUMN_SHAPE_AXISYSTART].DefaultValue.ToString()),
                                int.Parse(dataTable.Columns[COLUMN_SHAPE_AXISXEND].DefaultValue.ToString()),
                                int.Parse(dataTable.Columns[COLUMN_SHAPE_AXISYEND].DefaultValue.ToString()),
                                pen
                            )
                        );
                        break;
                    case "PenShape":
                        break;
                }
            }
            return shapes;
        }
    }
}
