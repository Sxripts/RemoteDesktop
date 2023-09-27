using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RemoteDesktop1
{
    public partial class MainWindow : Window
    {
        private bool isResizing = false;
        private Point lastMousePosition;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResizeGrip_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isResizing = true;
            lastMousePosition = e.GetPosition(this);
            resizeGrip.CaptureMouse();
            resizeGrip.MouseMove += ResizeGrip_MouseMove;
            resizeGrip.MouseLeftButtonUp += ResizeGrip_MouseLeftButtonUp;
        }

        private void ResizeGrip_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                var newMousePosition = e.GetPosition(this);
                var dx = newMousePosition.X - lastMousePosition.X;
                var dy = newMousePosition.Y - lastMousePosition.Y;

                // Apply the size change to the UserControl
                this.Width = Math.Max(this.Width + dx, this.MinWidth);
                this.Height = Math.Max(this.Height + dy, this.MinHeight);

                // Update last mouse position
                lastMousePosition = newMousePosition;
            }
        }

        private void ResizeGrip_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isResizing = false;
            resizeGrip.ReleaseMouseCapture();
            resizeGrip.MouseMove -= ResizeGrip_MouseMove;
            resizeGrip.MouseLeftButtonUp -= ResizeGrip_MouseLeftButtonUp;
        }

        private void CMD_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool isDragging = false;
        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDragging = false;
                Opacity = 0.9; // Set the opacity to 0.9 when dragging starts
                DragMove(); // Start dragging the window
            }
        }

        private void MainWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDragging = true;
                Opacity = 1.0; // Set the opacity back to 1.0 when dragging ends
            }
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {

            }
        }
    }
}