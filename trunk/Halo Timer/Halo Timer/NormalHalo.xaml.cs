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

using System;
using System.Threading;
// The following Imports are not required for the timer. They merely simplify 
// the code.
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Halo_Timer
{
    
 
    
    public partial class NormalHalo : PhoneApplicationPage
    {
        private DispatcherTimer rockets = new DispatcherTimer();
        int rocketDuration;
        bool rocketEnabled = false;
        

        public NormalHalo()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
         
        }

        private void rocketReset_Click(object sender, RoutedEventArgs e)
        {
            // If statement is to fix the tick time.
            if (!rocketEnabled)
            {
                rockets.Interval = new TimeSpan(0, 0, 1);
                rockets.Tick += new EventHandler(rockets_Tick);
                rocketEnabled = true;
            }
            // Reset the Duration and start the timer
            rocketDuration = 180;
            rockets.Start();
        }

        // Handles appropriate actions on each tick: Lowers seconds, updates the field and stops timer when 0 is reached.
        void rockets_Tick(object sender, EventArgs e)
        {
            rocketDuration--;
            updateRocketField();
            if (rocketDuration <= 0)
                rockets.Stop();
        }

        // Method to update the field to display the timer
        void updateRocketField()
        {
            int minutes = rocketDuration / 60;
            int seconds = rocketDuration % 60;
            string newTime = minutes.ToString();
            newTime = newTime + ":";
            newTime = newTime + seconds.ToString();
            rocketTime.Text = newTime;
        }
    }
}