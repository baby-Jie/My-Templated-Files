using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace UIProject.Behaviors
{
    class ZoomAndDrangeBehavior:Behavior<UIElement>
    {
        ScaleTransform scaleTf;
        TranslateTransform translateTf;

        protected override void OnAttached()
        {
            base.OnAttached();

            scaleTf = new ScaleTransform();
            translateTf = new TranslateTransform();
            TransformGroup group = new TransformGroup();
            group.Children.Add(scaleTf);
            group.Children.Add(translateTf);

            AssociatedObject.MouseWheel += Image_MouseWheel;
            AssociatedObject.MouseLeftButtonDown += Image_MouseLeftButtonDown;
            AssociatedObject.PreviewMouseLeftButtonUp += Image_MouseLeftButtonUp;
            AssociatedObject.MouseMove += Image_MouseMove;
            AssociatedObject.RenderTransform = group;
        }



        protected override void OnDetaching()
        {
            AssociatedObject.MouseWheel -= Image_MouseWheel;
            AssociatedObject.MouseLeftButtonDown -= Image_MouseLeftButtonDown;
            AssociatedObject.PreviewMouseLeftButtonUp -= Image_MouseLeftButtonUp;
            AssociatedObject.MouseMove -= Image_MouseMove;
            base.OnDetaching();
        }

        Point oldPt;

        private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0 && scaleTf.ScaleX < 0.2) return;

            Point zoomCenter = e.GetPosition(AssociatedObject);
            Point point = AssociatedObject.RenderTransform.Inverse.Transform(zoomCenter);


            this.translateTf.X = (zoomCenter.X - point.X) * this.scaleTf.ScaleX;
            this.translateTf.Y = (zoomCenter.Y - point.Y) * scaleTf.ScaleY;

            this.scaleTf.CenterX = zoomCenter.X;
            this.scaleTf.CenterY = zoomCenter.Y;

            this.scaleTf.ScaleX += e.Delta / 1000.0;
            this.scaleTf.ScaleY += e.Delta / 1000.0;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DependencyObject obj = LogicalTreeHelper.GetParent(AssociatedObject);
            oldPt = e.GetPosition(obj as UIElement);
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject obj = LogicalTreeHelper.GetParent(AssociatedObject);
            oldPt = e.GetPosition(obj as UIElement);
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            DependencyObject obj = LogicalTreeHelper.GetParent(AssociatedObject);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point pt = e.GetPosition(obj as UIElement);
                translateTf.X += pt.X - oldPt.X;
                translateTf.Y += pt.Y - oldPt.Y;
                oldPt = pt;
            }
        }
    }
}
