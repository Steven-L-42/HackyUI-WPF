﻿using System.Windows;
using System.Windows.Media;

namespace Project_Automait.Classes
{

    public class CheckBox : System.Windows.Controls.CheckBox
    {

        static CheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckBox), new FrameworkPropertyMetadata(typeof(CheckBox)));
        }


        // CornerRadius Dependency Property
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CheckBox), new PropertyMetadata(new CornerRadius(0)));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Text Dependency Property
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CheckBox), new PropertyMetadata(new string("CheckBox")));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Padding Dependency Property
        public static readonly new DependencyProperty PaddingProperty =
            DependencyProperty.Register("Padding", typeof(Thickness), typeof(CheckBox), new PropertyMetadata(new Thickness(0)));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }


        // BorderThickness Dependency Property
        public static readonly new DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(CheckBox), new PropertyMetadata(new Thickness(1)));

        public new Thickness BorderThickness
        {
            get { return (Thickness)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }


        // BorderBrush Dependency Property
        public static readonly new DependencyProperty BorderBrushProperty =
            DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(CheckBox), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0x7F, 0x40, 0x40, 0x40))));

        public new Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        // FontSize Dependency Property
        public static readonly new DependencyProperty FontSizeProperty =
            DependencyProperty.Register("FontSize", typeof(double), typeof(CheckBox), new PropertyMetadata(15.0));

        public new double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        // Foreground Dependency Property
        public static readonly new DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(Brush), typeof(CheckBox), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0xE0, 0xE0, 0xE0))));

        public new Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        // Foreground Dependency Property
        public static readonly new DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(CheckBox), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        // HoveredForeground Dependency Property
        public static readonly DependencyProperty HoveredForegroundProperty =
            DependencyProperty.Register("HoveredForeground", typeof(Brush), typeof(CheckBox), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x7A, 0x00))));

        public Brush HoveredForeground
        {
            get { return (Brush)GetValue(HoveredForegroundProperty); }
            set { SetValue(HoveredForegroundProperty, value); }
        }

        // UnCheckColor Dependency Property
        public static readonly DependencyProperty UnCheckColorProperty =
            DependencyProperty.Register("UnCheckColor", typeof(Brush), typeof(CheckBox), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0xCD, 0x66, 0x07))));

        public Brush UnCheckColor
        {
            get { return (Brush)GetValue(UnCheckColorProperty); }
            set { SetValue(UnCheckColorProperty, value); }
        }


    }
}
