using OpenTK;
using OpenTK.Input;
using OpenTKGui.Model;
using System.Collections.Generic;
using System.Drawing;

namespace OpenTKGui.Controller
{
    class MouseState
    {
        private Point _click_position;
        public Point ClickPosition => _click_position;

        private List<Actions> _actions;
        public IEnumerable<Actions> Actions => _actions;

        public MouseState(INativeWindow window)
        {
            _click_position = new Point();
            _actions = new List<Actions>();

            window.MouseUp += Window_MouseUp;
            window.MouseDown += Window_MouseDown;
            window.MouseMove += Window_MouseMove;
        }

        private void Window_MouseMove(object sender, MouseMoveEventArgs e)
        {
            _click_position = e.Position;
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == MouseButton.Left)
            {
                _actions.Remove(Model.Actions.leftClicked);
            }
            else if (e.Button == MouseButton.Right)
            {
                _actions.Remove(Model.Actions.rightClicked);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _click_position = e.Position;

            if(e.Button == MouseButton.Left)
                _actions.Add(Model.Actions.leftClicked);

            else if(e.Button == MouseButton.Right)
                _actions.Add(Model.Actions.rightClicked);
        }
    }
}