using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace alternative_clock_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private DispatcherTimer timer = new DispatcherTimer();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
            timer.Tick += new EventHandler(Get_time);
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void Get_time(object? sender, EventArgs e)
        {
            int hour=DateTime.Now.Hour;
            int minute=DateTime.Now.Minute;
            int second=DateTime.Now.Second;

            Arrow_rotation_animation(hour, minute, second);
        }

        private void Arrow_rotation_animation(int Hour,int Minute, int Second)
        {
            const int Angle_rotation_second_minute_hands = 6;
            const int Angle_rotation_hour_hand = 30;

            int Formula_movement_hour_hand = Hour * Angle_rotation_hour_hand + Minute / 12 * Angle_rotation_second_minute_hands;

            RotateTransform second = new RotateTransform(Second*Angle_rotation_second_minute_hands);
            RotateTransform minute = new RotateTransform(Minute*Angle_rotation_second_minute_hands);
            RotateTransform hour=new RotateTransform(Formula_movement_hour_hand);

            Second_arrow.RenderTransform = second;
            Minut_arrow.RenderTransform = minute;
            Hours_arrow.RenderTransform = hour;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key==Key.Escape)
            {
                timer.Tick -= new EventHandler(Get_time);
                timer.Stop();
                this.Close();
            }
        }
    }
}
