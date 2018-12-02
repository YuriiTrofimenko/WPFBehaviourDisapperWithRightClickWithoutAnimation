using CustomPanelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BehaviorLib
{
    public class ClickFillBehavior : Behavior<UIElement>
    {
        private CustomCanvas canvas;

        protected override void OnAttached()
        {
            base.OnAttached();

            // Присоединение обработчиков событий
            this.AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            // Удаление обработчиков событий
            this.AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Поиск canvas
            if (canvas == null) canvas =
                    VisualTreeHelper.GetParent(this.AssociatedObject) as CustomCanvas;



            Color resultColor = Colors.Black;

            Console.WriteLine(canvas.currentColor);

            switch (canvas.currentColor)
            {
                case "Yellow": { resultColor = Colors.Yellow; break; }
                case "Red": { resultColor = Colors.Red; break; }
                case "Green": { resultColor = Colors.Green; break; }
                default: break;
            }

            Console.WriteLine(new SolidColorBrush(resultColor));

            AssociatedObject.GetType()
                .GetProperty("Fill")
                .SetValue(AssociatedObject, new SolidColorBrush(resultColor));
        }
    }
}
