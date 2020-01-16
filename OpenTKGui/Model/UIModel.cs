using OpenTK;
using System.Drawing;
using System.Linq;
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

        public UIModel(int screenWidth, int screenHeight)
        {
            _entities = new List<IGUIEntity>();

            Slider slider = new Slider(new Vector2(0.0f, 0.0f), new Vector2(1f, 0.2f), Color.Transparent);
            Button button = new Button(new Vector2(0.0f, 0.3f), new Vector2(1f, 0.2f), Color.Transparent);
            CheckBox checkBox = new CheckBox(new Vector2(0.0f, -0.3f), new Vector2(0.2f, 0.2f), Color.Transparent);

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
            }
        }
    }
}