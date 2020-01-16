using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTKGui.Model
{
    class CoordinateTransformation
    {
        public static Point GL_to_Screen_Coords(Vector2 coords, float screen_width, float screen_height)
        {
            Point point = new Point();

            float temp_x = ((coords.X + 1) / 2) * screen_width;
            point.X = (int)temp_x;

            //Invert y-axis first because screen relative positive is downwards, in GL upwards
            float temp_y = coords.Y * (-1);
            temp_y = ((temp_y + 1) / 2) * screen_height;
            point.Y = (int)temp_y;

            return point;
        }

        public static Vector2 Screen_to_GL_Coords(Point coords, float screen_width, float screen_height)
        {
            Vector2 point = new Vector2();

            float temp_x = ((coords.X / screen_width) * 2) - 1;
            point.X = temp_x;

            float temp_y = ((coords.Y / screen_height) * 2) - 1;
            point.Y = (int)temp_y;

            return point;
        }

        public static Point GL_Size_To_Screen_Size(Vector2 size, float screen_width, float screen_height)
        {
            Point point = new Point();

            float temp_x = (size.X / 2) * screen_width;
            point.X = (int)temp_x;
            float temp_y = (size.Y / 2) * screen_height;
            point.Y = (int)temp_y;

            return point;
        }
    }
}
