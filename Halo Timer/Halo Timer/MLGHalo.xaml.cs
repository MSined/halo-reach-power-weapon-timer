using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using System.Threading;
using System.Windows.Threading;

namespace Halo_Timer
{
    public partial class MLGHalo : PhoneApplicationPage
    {
        bool start = true;
        // Time Objects
        private DispatcherTimer mlgRockets = new DispatcherTimer();
        private DispatcherTimer mlgSniper = new DispatcherTimer();
        private DispatcherTimer mlgLauncher = new DispatcherTimer();
        private DispatcherTimer customPowerup = new DispatcherTimer();

        // Declare time variables for each weapon
        int mlgRocketTimer;
        int mlgSniperTimer;
        int mlgLauncherTimer;
        int customPowerupTimer;

        string newTime;
        
        public MLGHalo()
        {
            InitializeComponent();

            mlgSniper.Interval = new TimeSpan(0, 0, 1);
            mlgSniper.Tick += new EventHandler(mlgSniper_Tick);

            mlgRockets.Interval = new TimeSpan(0, 0, 1);
            mlgRockets.Tick += new EventHandler(mlgRockets_Tick);

            mlgLauncher.Interval = new TimeSpan(0, 0, 1);
            mlgLauncher.Tick += new EventHandler(mlgLauncher_Tick);

            customPowerup.Interval = new TimeSpan(0, 0, 1);
            customPowerup.Tick += new EventHandler(customPowerup_Tick);
        }

        // Button that will start all the weapon timers.
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(start)
            {
                button1.Content = "Stop";
                mlgRocketTimer = 177;
                mlgSniperTimer = 117;
                mlgLauncherTimer = 117;

                mlgRockets.Start();
                mlgSniper.Start();
                mlgLauncher.Start();
                start = false;
            }
            else
            {
                button1.Content = "Start";
                mlgRockets.Stop();
                mlgSniper.Stop();
                mlgLauncher.Stop();
                start = true;
            }
        }

        // Actions to perform on each sniper tick
        void mlgSniper_Tick(object sender, EventArgs e)
        {
            mlgSniperTimer--;
            updateField(mlgSniperTime, mlgSniperTimer);
            if (mlgSniperTimer <= 0)
                mlgSniperTimer = 120;
        }

        // Actions to perform on each rocket tick
        void mlgRockets_Tick(object sender, EventArgs e)
        {
            mlgRocketTimer--;
            updateField(mlgRocketTime, mlgRocketTimer);
            if (mlgRocketTimer <= 0)
                mlgRocketTimer = 180;
        }

        // Actions to perform on each grenade launcher tick
        void mlgLauncher_Tick(object sender, EventArgs e)
        {
            mlgLauncherTimer--;
            updateField(mlgLauncherTime, mlgLauncherTimer);
            if (mlgLauncherTimer <= 0)
                mlgLauncherTimer = 120;
        }

        // Actions to perform on each grenade launcher tick
        void customPowerup_Tick(object sender, EventArgs e)
        {
            customPowerupTimer--;
            updateField(CustomTimer, customPowerupTimer);
            if (customPowerupTimer <= 0)
                customPowerup.Stop();
        }

        // Method to update the field to display the timer
        void updateField(TextBox box, int time)
        {
            box.Text = convertTime(time);
        }

        // Converts
        string convertTime(int duration)
        {
            int minutes = duration / 60;
            int seconds = duration % 60;
            newTime = minutes.ToString();
            newTime = newTime + ":";
            if (seconds / 10 < 1)
                newTime = newTime + "0" + seconds.ToString();
            else
                newTime = newTime + seconds.ToString();
            return newTime;
        }

        // Reset the custom powerup timer
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            customPowerupTimer = 120;
            customPowerup.Start();
        }
    }

}