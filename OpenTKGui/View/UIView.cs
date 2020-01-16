using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTKGui.Model.UIElements;
using System.Collections.Generic;
using System.Drawing;

namespace OpenTKGui.View
{
    class UIView
    {
        public void Render(IEnumerable<IGUIEntity> entities)
        {
            GL.ClearColor(Color.Gray);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            foreach (var entity in entities)
            {
                RenderEntity(entity);
            }
        }

        private void RenderEntity(IGUIEntity entity)
        {
            GL.LoadIdentity();
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.BindTexture(TextureTarget.Texture2D, entity.glTex);

            GL.Begin(PrimitiveType.Quads);

            GL.Color3(entity.Color);
            GL.TexCoord2(0, 1);
            GL.Vertex2(entity.Position + new Vector2(-entity.Size.X / 2, -entity.Size.Y / 2));
            GL.TexCoord2(1, 1);
            GL.Vertex2(entity.Position + new Vector2(entity.Size.X / 2, -entity.Size.Y / 2));
            GL.TexCoord2(1, 0);
            GL.Vertex2(entity.Position + new Vector2(entity.Size.X / 2, entity.Size.Y / 2));
            GL.TexCoord2(0, 0);
            GL.Vertex2(entity.Position + new Vector2(-entity.Size.X / 2, entity.Size.Y / 2));

            GL.End();

            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.Blend);
        }
    }
}