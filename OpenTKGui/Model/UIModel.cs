using OpenTK;
using System.Drawing;
using System.Collections.Generic;
using OpenTKGui.Model.UIElements;

namespace OpenTKGui.Model
{
    class UIModel
    {
        readonly List<IGUIEntity> _entities;
        public IEnumerable<IGUIEntity> Entities => _entities;

        public float ScreenHeight { get; set; }
        public float ScreenWidth { get; set; }

        private Slider slider;
        private Button button;
        private CheckBox checkBox;

        public UIModel(int screenWidth, int screenHeight)
        {
            _entities = new List<IGUIEntity>();

            slider = new Slider(new Vector2(0.0f, 0.0f), new Vector2(1f, 0.2f), Color.Transparent);
            button = new Button(new Vector2(0.0f, 0.3f), new Vector2(1f, 0.2f), Color.Transparent);
            checkBox = new CheckBox(new Vector2(0.0f, -0.3f), new Vector2(0.2f, 0.2f), Color.Transparent);

            _entities.Add(slider);
            _entities.Add(slider.Slider_Head);

            _entities.Add(checkBox);
            _entities.Add(checkBox.CheckBoxTick);

            _entities.Add(button);

            ScreenHeight = screenHeight;
            ScreenWidth = screenWidth;
        }

        public void Update(Point mousePosition, bool leftClicked, float deltaTime)
        {
            foreach (var entity in _entities)
            {
                entity.Update(deltaTime, mousePosition, ScreenWidth, ScreenHeight, leftClicked);

                if (checkBox.Active)
                    System.Console.WriteLine(slider.Value);

                if (button.ButtonClicked == true && entity is Button)
                    System.Console.WriteLine(slider.Value);
            }
        }
    }
}