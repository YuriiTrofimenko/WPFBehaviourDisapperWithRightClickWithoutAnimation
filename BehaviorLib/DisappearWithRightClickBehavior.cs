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
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;

namespace BehaviorLib
{
    public class DisappearWithRightClickBehavior : Behavior<UIElement>
    {
        private Canvas canvas;
        Task t;

        protected override void OnAttached()
        {
            base.OnAttached();

            // Присоединение обработчиков событий
            this.AssociatedObject.MouseRightButtonDown += AssociatedObject_MouseRightButtonDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            // Удаление обработчиков событий
            this.AssociatedObject.MouseRightButtonDown -= AssociatedObject_MouseRightButtonDown;
        }

        
        private void AssociatedObject_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(canvas == null) canvas = VisualTreeHelper.GetParent(this.AssociatedObject) as Canvas;
            //mouseOffset = e.GetPosition(AssociatedObject);
            Point point = e.GetPosition(canvas);
                    AssociatedObject.SetValue(Canvas.LeftProperty, canvas.Height + 6000);
        }

        
    }
}
