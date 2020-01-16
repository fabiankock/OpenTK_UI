using System.Drawing;
using OpenTK;

namespace OpenTKGui.Model.UIElements
{
    class Slider : IGUIEntity
    {
        public Color Color { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public int GLTex { get; set; }

        public SliderHead Slider_Head { get; set; }
        public float Value { get; set; }
        public Slider(Vector2 pos, Vector2 size, Color col)
        {
            Color = col;
            Position = pos;
            Size = size;

            Slider_Head = new SliderHead(pos, new Vector2(size.X / 6, size.Y), col, this);
            Slider_Head.Position = Position + (new Vector2(-Size.X / 2, 0));
            Value = 0.0f;

            GLTex = TextureHelper.CreateTexture("s_body");
        }

        public void Update(float deltaTime, Point mousePosition, float screenWidth, float screenHeight, bool leftClicked)
        {
            Vector2 left = new Vector2(Position.X - (Size.X / 2), Slider_Head.Position.Y);

            if(Slider_Head.Position.X <= left.X)
            {
                Slider_Head.Position = new Vector2(left.X, Slider_Head.Position.Y);
            }
            else if(Slider_Head.Position.X >= (Position.X + (Size.X / 2)))
            {
                Slider_Head.Position = new Vector2(Position.X + (Size.X / 2), Slider_Head.Position.Y);
            }

            Value = (Slider_Head.Position.X - left.X) / Size.X;
        }
    }
}