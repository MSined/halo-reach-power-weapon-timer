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
// The following Imports are not required for the timer. They merely simplify 
// the code.

using System.Windows.Threading;

namespace Halo_Timer
{
    
 
    
    public partial class NormalHalo : PhoneApplicationPage
    {
        // Listpicker array for map names
        String[] mapNames = { "Asylum", "Boardwalk", "Countdown", "Pinnacle", 
                              "Powerhouse", "Reflection", "Sword Base", "Uncaged" };

        // Time Objects
        private DispatcherTimer rockets     = new DispatcherTimer();
        private DispatcherTimer sniper      = new DispatcherTimer();
        private DispatcherTimer gLauncher   = new DispatcherTimer();
        private DispatcherTimer sword       = new DispatcherTimer();

        int[] rocketTimes       = { 0,  180, 0,     180, 180,   180, 0,     180 };
        int[] sniperTimes       = { 90, 120, 0,     180, 0,     180, 180,   120 };
        int[] gLauncherTimes    = { 0,  0,   0,     0,   90,    0,   0,     120 };
        int[] swordTimes        = { 90, 0,   180,   0,   0,     180, 120,   0   };
        
        // Integer time variables
        int rocketDuration;
        int sniperDuration;
        int gLauncherDuration;
        int swordDuration;

        // Boolean Variables
        bool rocketEnabled      = false;
        bool sniperEnabled      = false;
        bool gLauncherEnabled   = false;
        bool swordEnabled       = false;

        string newTime;
        
        // Map ID
        int map;

        public NormalHalo()
        {
            InitializeComponent();
            this.listPicker.ItemsSource = mapNames;
        }

        private void setMap()
        {
            map = listPicker.SelectedIndex;
        }

        // Sets the Rocker Launcher timer based on the map selection
        private void setRocketTimer()
        {
            setMap();
            rocketDuration = rocketTimes[map];
        }

        // Sets sniper rifle time based on map selection
        private void setSniperTimer()
        {
            setMap();
            sniperDuration = sniperTimes[map];
        }

        // Sets the Grenade Launcher timer based on the map selection
        private void setgLauncherTimer()
        {
            setMap();
            gLauncherDuration = gLauncherTimes[map];
        }

        // Sets the Sword timer based on the map selection
        private void setSwordTimer()
        {
            setMap();
            swordDuration = swordTimes[map];
        }

        // Resets the sniper timer
        private void sniperReset_Click(object sender, RoutedEventArgs e)
        {
            setSniperTimer();
            if (sniperDuration != 0)
            {
                // If statement is to prevent the tick time from increase on each reset.
                if (!sniperEnabled)
                {
                    sniper.Interval = new TimeSpan(0, 0, 1);
                    sniper.Tick += new EventHandler(sniper_Tick);
                    sniperEnabled = true;
                }
                // Reset the Duration and start the timer
                sniper.Start();
            }
        }

        // Handles appropriate actions on each tick: Lowers seconds, updates the field and stops timer when 0 is reached.
        void sniper_Tick(object sender, EventArgs e)
        {
            sniperDuration--;
            updateField(sniperTime, sniperDuration);
            if (sniperDuration <= 0)
                sniper.Stop();
        }

        // Resets the rocket timer
        private void rocketReset_Click(object sender, RoutedEventArgs e)
        {
            setRocketTimer();

            if (rocketDuration != 0)
            {
                // If statement is to prevent the tick time from increase on each reset.
                if (!rocketEnabled)
                {
                    rockets.Interval = new TimeSpan(0, 0, 1);
                    rockets.Tick += new EventHandler(rockets_Tick);
                    rocketEnabled = true;
                }
                // Reset the Duration and start the timer
                rockets.Start();
            }
        }

        // Handles appropriate actions on each tick: Lowers seconds, updates the field and stops timer when 0 is reached.
        void rockets_Tick(object sender, EventArgs e)
        {
            rocketDuration--;
            updateField(rocketTime, rocketDuration);
            if (rocketDuration <= 0)
                rockets.Stop();
        }

        // Resets grenade launcher timer
        private void grenadeGunReset_Click(object sender, RoutedEventArgs e)
        {
            setgLauncherTimer();

            if (gLauncherDuration != 0)
            {
                // If statement is to prevent the tick time from increase on each reset.
                if (!gLauncherEnabled)
                {
                    gLauncher.Interval = new TimeSpan(0, 0, 1);
                    gLauncher.Tick += new EventHandler(gLauncher_Tick);
                    gLauncherEnabled = true;
                }
                // Reset the Duration and start the timer
                gLauncher.Start();
            }
        }

        // Handles appropriate actions on each tick: Lowers seconds, updates the field and stops timer when 0 is reached.
        void gLauncher_Tick(object sender, EventArgs e)
        {
            gLauncherDuration--;
            updateField(grenadeGunTimer, gLauncherDuration);
            if (gLauncherDuration <= 0)
                gLauncher.Stop();
        }

        // Resets sword timer
        private void swordReset_Click(object sender, RoutedEventArgs e)
        {
            setSwordTimer();

            if (swordDuration != 0)
            {
                swordTimer.Background = new SolidColorBrush(Colors.White);
                // If statement is to prevent the tick time from increase on each reset.
                if (!swordEnabled)
                {
                    sword.Interval = new TimeSpan(0, 0, 1);
                    sword.Tick += new EventHandler(sword_Tick);
                    swordEnabled = true;
                }
                // Reset the Duration and start the timer
                sword.Start();
            }
        }

        // Handles appropriate actions on each tick: Lowers seconds, updates the field and stops timer when 0 is reached.
        void sword_Tick(object sender, EventArgs e)
        {
            swordDuration--;
            if (swordDuration <= 46 && swordDuration >= 44)
            {
                swordTimer.Background = new SolidColorBrush(Colors.Yellow);
            }
            if (swordDuration == 20)
            {
                swordTimer.Background = new SolidColorBrush(Colors.Red);
            }
            updateField(swordTimer, swordDuration);
            if (swordDuration <= 0)
                sword.Stop();
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

        

       
        
        
    }
}