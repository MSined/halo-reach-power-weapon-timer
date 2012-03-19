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
        private DispatcherTimer generalTimer = new DispatcherTimer();

        // Declare time variables for each weapon
        int mlgRocketTimer;
        int mlgSniperTimer;
        int mlgLauncherTimer;
        int customPowerupTimer;

        // Sound Object
        PlaySoundFiles soundPlayer = new PlaySoundFiles();

        string newTime;
        
        public MLGHalo()
        {
            InitializeComponent();

            generalTimer.Interval = new TimeSpan(0, 0, 1);
            generalTimer.Tick += new EventHandler(generalTimer_Tick);

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
                generalTimer.Start();
                start = false;
            }
            else
            {
                button1.Content = "Start";
                mlgRockets.Stop();
                mlgSniper.Stop();
                mlgLauncher.Stop();
                generalTimer.Stop();
                start = true;
            }
        }

        // Actions performed on every tick
        void generalTimer_Tick(object sender, EventArgs e)
        {
            #region warnings
            if (mlgRocketTimer == 20 && mlgSniperTimer == 20 && mlgLauncherTimer == 20)
            {
                soundPlayer.playAllWarning();
            }
            else if (mlgSniperTimer == 20 && mlgLauncherTimer == 20)
            {
                soundPlayer.playSniperGrenadeWarning();
            }
            else if (mlgRocketTimer == 20)
            {
                soundPlayer.playRocketWarning();
            }
            #endregion

            #region spawns
            if (mlgRocketTimer <= 1 && mlgSniperTimer <= 1 && mlgLauncherTimer <= 1)
            {
                soundPlayer.playAllSpawn();
            }
            else if (mlgSniperTimer <= 1 && mlgLauncherTimer <= 1)
            {
                soundPlayer.playSniperGrenadeSpawn();
            }
            else if (mlgRocketTimer <= 1)
            {
                soundPlayer.playRocketSpawn();
            }
            #endregion
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
            if (customPowerupTimer == 20)
            {
                soundPlayer.playCustomWarning();
            }
            if (customPowerupTimer <= 0)
            {
                soundPlayer.playCustomSpawn();
                customPowerup.Stop();
            }
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