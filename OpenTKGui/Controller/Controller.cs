using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTKGui.Model;
using OpenTKGui.View;
using System.Linq;

namespace OpenTKGui.Controller
{
    class Controller
    {
        private static readonly int SCREEN_WIDTH = 640;
        private static readonly int SCREEN_HEIGHT = 480;

        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(SCREEN_WIDTH, SCREEN_HEIGHT);
            MouseState mouse = new MouseState(window);

            UIModel model = new UIModel(SCREEN_WIDTH, SCREEN_HEIGHT);
            UIView view = new UIView();

            window.UpdateFrame += (s, e) => model.Update(mouse.ClickPosition, mouse.Actions.Contains(Actions.leftClicked), (float)e.Time);
            window.RenderFrame += (s, e) => view.Render(model.Entities);
            window.RenderFrame += (s, e) => window.SwapBuffers();
            window.Resize += (s, e) => UpdateViewport(window, model);

            window.Run();
        }

        public static void UpdateViewport(GameWindow window, UIModel model)
        {
            GL.Viewport(0, 0, window.Width, window.Height);

            model.ScreenHeight = window.Height;
            model.ScreenWidth = window.Width;
        }
    }
}