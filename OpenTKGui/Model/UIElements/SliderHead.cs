using System.Drawing;
using OpenTK;

namespace OpenTKGui.Model.UIElements
{
    class SliderHead : IGUIEntity
    {
        public Color Color { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public int GLTex { get; set; }

        public SliderHead(Vector2 pos, Vector2 size, Color col, IGUIEntity parent)
        {
            Color = col;
            Position = pos;
            Size = size;

            GLTex = TextureHelper.CreateTexture("s_head");
        }

        public void Update(float deltaTime, Point mousePosition, float screenWidth, float screenHeight, bool leftClicked)
        {
            if(leftClicked)
            {
                //Get upper left point of sliderHead
                Point headCoords = CoordinateTransformation.GL_to_Screen_Coords(Position + new Vector2(-Size.X / 2, Size.Y / 2), screenWidth, screenHeight);
                //Get button size
                Point headSize = CoordinateTransformation.GL_Size_To_Screen_Size(Size, screenWidth, screenHeight);

                //Make rectangles relative to screen to check for intersection
                Rectangle headRect = new Rectangle(headCoords.X, headCoords.Y, headSize.X, headSize.Y);
                Rectangle mouseRect = new Rectangle(mousePosition, new Size(10, 10));

                if (headRect.IntersectsWith(mouseRect))
                {
                    Position = new Vector2(CoordinateTransformation.Screen_to_GL_Coords(mousePosition, screenWidth, screenHeight).X, Position.Y);
                }
            }
        }
    }
}