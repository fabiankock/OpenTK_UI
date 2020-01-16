using OpenTK;
using System.Collections.Generic;
using System.Drawing;

namespace OpenTKGui.Model.UIElements
{
    interface IGUIEntity
    {
        Color Color { get; }
        Vector2 Position { get; set; }
        Vector2 Size { get; set; }
        int glTex { get; set; }
        void Update(float deltaTime, Point mousePosition, float screenWidth, float screenHeight, bool leftClicked);
    }
}