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
        // Time Objects
        private DispatcherTimer rockets = new DispatcherTimer();
        private DispatcherTimer sniper = new DispatcherTimer();
        
        
        // Integer time variables
        int rocketDuration;
        int sniperDuration;

        // Boolean Variables
        bool rocketEnabled = false;
        bool sniperEnabled = false;

        string newTime;
        
        // Map ID
        int map;

        public NormalHalo()
        {
            InitializeComponent();
        }

        private void sniperReset_Click(object sender, RoutedEventArgs e)
        {
            // If statement is to prevent the tick time from increase on each reset.
            if (!sniperEnabled)
            {
                sniper.Interval = new TimeSpan(0, 0, 1);
                sniper.Tick += new EventHandler(sniper_Tick);
                sniperEnabled = true;
            }
            // Reset the Duration and start the timer
            sniperDuration = 180;
            sniper.Start();
        }

        // Handles appropriate actions on each tick: Lowers seconds, updates the field and stops timer when 0 is reached.
        void sniper_Tick(object sender, EventArgs e)
        {
            sniperDuration--;
            updateField(sniperTime, sniperDuration);
            if (sniperDuration <= 0)
                sniper.Stop();
        }

        // Resets the timer to three minutes when button is clicked.
        private void rocketReset_Click(object sender, RoutedEventArgs e)
        {
            
            // If statement is to prevent the tick time from increase on each reset.
            if (!rocketEnabled)
            {
                rockets.Interval = new TimeSpan(0, 0, 1);
                rockets.Tick += new EventHandler(rockets_Tick);
                rocketEnabled = true;
            }
            // Reset the Duration and start the timer
            if (map == 0)
            {
                rocketDuration = 180;
            }
            else
                rocketDuration = 120;
            rockets.Start();
        }

        // Handles appropriate actions on each tick: Lowers seconds, updates the field and stops timer when 0 is reached.
        void rockets_Tick(object sender, EventArgs e)
        {
            rocketDuration--;
            updateField(rocketTime, rocketDuration);
            if (rocketDuration <= 0)
                rockets.Stop();
        }

        // Method to update the field to display the timer
        void updateField(TextBox box, int time)
        {
            box.Text = convertTime(time);
        }

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


        private void listPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get the data object that represents the current selected item
            //SampleData data = (sender as ListPicker).SelectedItem as SampleData;
            map = this.listPicker.SelectedIndex;
            //Get the selected ListPickerItem container instance    
            //ListPickerItem selectedItem = this.listPicker.ItemContainerGenerator.ContainerFromItem(data) as ListPickerItem;
        }
    }
}