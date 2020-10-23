using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ResponsiveDesign.Controls
{
    public class GarethPanel : WrapPanel
    {
        public static readonly DependencyProperty RequestedItemWidthProperty =
           DependencyProperty.Register(nameof(RequestedItemWidth), typeof(double), typeof(GarethPanel), new PropertyMetadata(double.NaN));

        public double RequestedItemWidth
        {
            get { return (double)GetValue(RequestedItemWidthProperty); }
            set { SetValue(RequestedItemWidthProperty, value); }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            if(!double.IsNaN(RequestedItemWidth))
            {
                double requestedWidth = RequestedItemWidth;
                double panelWidth = constraint.Width;

                if (panelWidth < requestedWidth)
                {
                    requestedWidth = panelWidth;
                }

                foreach (UIElement child in InternalChildren)
                {
                    Thickness margin = (Thickness)child.GetValue(MarginProperty);

                    double width = requestedWidth - margin.Left - margin.Right;
                    if (width < 0)
                    {
                        width = 0;
                    }

                    child.SetValue(WidthProperty, width);
                }
            }

            return base.MeasureOverride(constraint);
        }
    }
}
