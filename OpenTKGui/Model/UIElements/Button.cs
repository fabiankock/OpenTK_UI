using System.Drawing;
using System.Linq;
using OpenTK;
using System.Collections.Generic;

namespace OpenTKGui.Model.UIElements
{
    class Button : IGUIEntity
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public Color Color { get; set; }
        public int GLTex { get; set; }

        private bool leftClickedLastFrame;
        private bool _buttonClicked;
        public bool ButtonClicked { get => _buttonClicked; }

        public Button(Vector2 pos, Vector2 size, Color color)
        {
            this.Position = pos;
            this.Size = size;
            this.Color = color;

            GLTex = TextureHelper.CreateTexture("Button");
            leftClickedLastFrame = false;
        }

        public void Update(float deltaTime, Point mousePosition, float screenWidth, float screenHeight, bool leftClicked)
        {
            if (leftClickedLastFrame == true)
                _buttonClicked = false;

            if (leftClicked && !leftClickedLastFrame)
            {
                //Get upper left point of button
                Point btnCoords = CoordinateTransformation.GL_to_Screen_Coords(Position + new Vector2(-Size.X / 2, Size.Y / 2), screenWidth, screenHeight);
                //Get button size
                Point btnSize = CoordinateTransformation.GL_Size_To_Screen_Size(Size, screenWidth, screenHeight);

                //Make rectangles relative to screen to check for intersection
                Rectangle btnRect = new Rectangle(btnCoords.X, btnCoords.Y, btnSize.X, btnSize.Y);
                Rectangle mouseRect = new Rectangle(mousePosition, new Size(10, 10));

                if (btnRect.IntersectsWith(mouseRect))
                {
                    //System.Console.WriteLine("Button clicked");
                    _buttonClicked = true;
                }
            }
            leftClickedLastFrame = leftClicked;
        }
    }
}