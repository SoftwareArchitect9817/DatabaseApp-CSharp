using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka.component
{
    public class DataGridViewDotColumn : DataGridViewImageColumn
    {
        public DataGridViewDotColumn()
        {
            CellTemplate = new DataGridViewDotCell();
        }
    }

    class DataGridViewDotCell : DataGridViewImageCell
    {
        // Used to make custom cell consistent with a DataGridViewImageCell
        static Image emptyImage;

        static DataGridViewDotCell()
        {
            emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        public DataGridViewDotCell()
        {
            ValueType = typeof(int);
        }

        // Method required to make the Progress Cell consistent with the default Image Cell. 
        // The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an int.
        protected override object GetFormattedValue(object value,
                            int rowIndex,
                            ref DataGridViewCellStyle cellStyle,
                            TypeConverter valueTypeConverter,
                            TypeConverter formattedValueTypeConverter,
                            DataGridViewDataErrorContexts context)
        {
            return emptyImage;
        }

        protected override void Paint(System.Drawing.Graphics g,
                            System.Drawing.Rectangle clipBounds,
                            System.Drawing.Rectangle cellBounds,
                            int rowIndex,
                            DataGridViewElementStates cellState,
                            object value,
                            object formattedValue,
                            string errorText, DataGridViewCellStyle cellStyle,
                            DataGridViewAdvancedBorderStyle advancedBorderStyle,
                            DataGridViewPaintParts paintParts)
        {
            try
            {
                if (value != null)
                {
                    int dot = (int)value;
                    Brush backColorBrush = new SolidBrush(cellStyle.BackColor);
                    Brush foreColorBrush = new SolidBrush(cellStyle.ForeColor);
                    // Draws the cell grid
                    base.Paint(g, clipBounds, cellBounds,
                             rowIndex, cellState, value, formattedValue, errorText,
                             cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));
                    if (dot == 0)
                    {
                        // Draw the progress bar and the text
                        g.FillEllipse(new SolidBrush(Color.FromArgb(0, 255, 0)), Convert.ToInt32(cellBounds.X + cellBounds.Width / 2 - (cellBounds.Height - 4) / 2), cellBounds.Y + 2, cellBounds.Height - 4, cellBounds.Height - 4);

                    }
                    else if (dot == 1)
                    {
                        // Draw the progress bar and the text
                        g.FillEllipse(new SolidBrush(Color.FromArgb(255, 0, 0)), Convert.ToInt32(cellBounds.X + cellBounds.Width / 2 - (cellBounds.Height - 4) / 2), cellBounds.Y + 2, cellBounds.Height - 4, cellBounds.Height - 4);

                    }
                    else if (dot == 2)
                    {
                        // Draw the progress bar and the text
                        g.FillEllipse(new SolidBrush(Color.FromArgb(255, 165, 0)), Convert.ToInt32(cellBounds.X + cellBounds.Width / 2 - (cellBounds.Height - 4) / 2), cellBounds.Y + 2, cellBounds.Height - 4, cellBounds.Height - 4);

                    }
                    else if (dot == 3)
                    {
                        // Draw the progress bar and the text
                        // g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 255)), Convert.ToInt32(cellBounds.X + cellBounds.Width / 2 - (cellBounds.Height - 4) / 2), cellBounds.Y + 2, cellBounds.Height - 4, cellBounds.Height - 4);
                        g.DrawEllipse(new Pen(new SolidBrush(Color.Black)), Convert.ToInt32(cellBounds.X + cellBounds.Width / 2 - (cellBounds.Height - 4) / 2), cellBounds.Y + 2, cellBounds.Height - 4, cellBounds.Height - 4);
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
