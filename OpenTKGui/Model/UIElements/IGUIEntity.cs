using OpenTK;
using System.Drawing;

namespace OpenTKGui.Model.UIElements
{
    interface IGUIEntity
    {
        Color Color { get; }
        Vector2 Position { get; set; }
        Vector2 Size { get; set; }
        int GLTex { get; set; }
        void Update(float deltaTime, Point mousePosition, float screenWidth, float screenHeight, bool leftClicked);
    }
}