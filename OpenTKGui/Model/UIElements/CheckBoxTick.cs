using OpenTK;
using System.Drawing;

namespace OpenTKGui.Model.UIElements
{
    class CheckBoxTick : IGUIEntity
    {
        public Color Color { get; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public int GLTex { get; set; }
        public bool Activated { get; set; }

        private Vector2 inital_pos;
        public CheckBoxTick(Vector2 pos, Vector2 size, Color col)
        {
            Color = col;
            Position = pos;
            Size = size;

            GLTex = TextureHelper.CreateTexture("check_tick");
            Activated = false;
            inital_pos = pos;
        }

        public void Update(float deltaTime, Point mousePosition, float screenWidth, float screenHeight, bool leftClicked)
        {
            if (!Activated)
                Position = new Vector2(100, 100);
            else
                Position = inital_pos;
        }
    }
}