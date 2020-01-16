using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using System.Resources;

namespace OpenTKGui.Model
{
    class TextureHelper
    {
        public static int CreateTexture(string texName)
        {
            ResourceManager rm = Resource.ResourceManager;
            Bitmap tex = (Bitmap)rm.GetObject(texName);
   
            GL.GenTextures(1, out int tempTex);
            GL.BindTexture(TextureTarget.Texture2D, tempTex);

            BitmapData data = tex.LockBits(new System.Drawing.Rectangle(0, 0, tex.Width, tex.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            tex.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            return tempTex;
        }
    }
}
