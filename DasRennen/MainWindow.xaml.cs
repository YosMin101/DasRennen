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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DasRennen
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Race race;
        TranslateTransform greenCarTrans;
        RotateTransform greenCarRot;
        TranslateTransform redCarTrans;
        RotateTransform redCarRot;
        DispatcherTimer timer;
        public MainWindow() {
            InitializeComponent();
            greenCarTrans = new TranslateTransform();
            greenCarRot = new RotateTransform();
            redCarTrans = new TranslateTransform(); 
            redCarRot = new RotateTransform();
           
            System.Drawing.Rectangle borders = new System.Drawing.Rectangle(0, 0, (int)canvasRacing.Width, (int)canvasRacing.Height);
            

            race = new Race(270, 290, 0, borders);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.025);
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (selectedComboBox.SelectedIndex == 0)
                race.Drive("green");
            else if (selectedComboBox.SelectedIndex == 1)
                race.Drive("red");
            updateRace();
        }
        private void sliderSteer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double rotationAngle = sliderSteer.Value;
            if (selectedComboBox.SelectedIndex == 0)
                race.greenOrientation = rotationAngle;
            else if (selectedComboBox.SelectedIndex == 1)
                race.redOrientation = rotationAngle;
            updateRace();
        }

        private void sliderSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Parameters.Speed = (int)e.NewValue;
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            if (selectedComboBox.SelectedIndex == 0)
                race.greenThrottle = Parameters.Direction.left;
            else if (selectedComboBox.SelectedIndex == 1)
                race.redThrottle = Parameters.Direction.left;
            updateRace();
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            if (selectedComboBox.SelectedIndex == 0)
                race.greenThrottle = Parameters.Direction.right;
            else if (selectedComboBox.SelectedIndex == 1)
                race.redThrottle = Parameters.Direction.right;
            updateRace();
        }
        void updateRace() {
            TransformGroup greentransformGroup = new TransformGroup();
            TransformGroup redtransformGroup = new TransformGroup();
            //redCar
            redCarTrans.X = race.redLocation.X;
            redCarTrans.Y = race.redLocation.Y;
            redCarRot.Angle = race.redOrientation;
            redtransformGroup.Children.Add(redCarRot);
            redtransformGroup.Children.Add(redCarTrans);
            rectangleRed.RenderTransform = redtransformGroup;
            //greenCar
            greenCarTrans.X = race.greenLocation.X;
            greenCarTrans.Y = race.greenLocation.Y;
            greenCarRot.Angle = race.greenOrientation;           
            greentransformGroup.Children.Add(greenCarRot);
            greentransformGroup.Children.Add(greenCarTrans);
            //rectangleGreen.RenderTransform = greenCarTrans;
            rectangleGreen.RenderTransform = greentransformGroup;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
