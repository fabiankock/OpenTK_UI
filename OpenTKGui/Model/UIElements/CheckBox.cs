using System.Drawing;
using OpenTK;

namespace OpenTKGui.Model.UIElements
{
    class CheckBox : IGUIEntity
    {
        public Color Color { get; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public int glTex { get; set; }

        public CheckBoxTick CheckBoxTick { get; }
        public bool Active => CheckBoxTick.Activated;

        private bool leftClickedLastFrame;
        public CheckBox(Vector2 pos, Vector2 size, Color col)
        {
            Color = col;
            Position = pos;
            Size = size;

            glTex = TextureHelper.CreateTexture("check_box");
            leftClickedLastFrame = false;
            CheckBoxTick = new CheckBoxTick(pos, size, col);
        }

        public void Update(float deltaTime, Point mousePosition, float screenWidth, float screenHeight, bool leftClicked)
        {
            if (leftClicked && !leftClickedLastFrame)
            {
                //Get upper left point of checkbox
                Point checkboxCoords = CoordinateTransformation.GL_to_Screen_Coords(Position + new Vector2(-Size.X / 2, Size.Y / 2), screenWidth, screenHeight);
                //Get checkbox size
                Point checkboxSize = CoordinateTransformation.GL_Size_To_Screen_Size(Size, screenWidth, screenHeight);

                //Make rectangles relative to screen to check for intersection
                Rectangle checkboxRect = new Rectangle(checkboxCoords.X, checkboxCoords.Y, checkboxSize.X, checkboxSize.Y);
                Rectangle mouseRect = new Rectangle(mousePosition, new Size(10, 10));

                if (checkboxRect.IntersectsWith(mouseRect))
                {
                    CheckBoxTick.Activated = !CheckBoxTick.Activated;
                    System.Console.WriteLine("Checkbox " + CheckBoxTick.Activated);
                }
            }

            leftClickedLastFrame = leftClicked;
        }
    }
}