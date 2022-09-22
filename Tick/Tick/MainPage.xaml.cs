namespace Tick;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Microsoft.Maui.Dispatching;

public partial class MainPage : ContentPage
{

    private IDispatcherTimer? reminderTimer;

    public MainPage()
	{
		InitializeComponent();
        this.InitializeReminderTimer();
    }

    private void InitializeReminderTimer()
    {
        var dispatcher = Dispatcher.DispatchDelayed;
        if (dispatcher != null)
        {
            this.reminderTimer = Dispatcher.CreateTimer();
            if (this.reminderTimer != null)
            {
                this.reminderTimer.Tick += this.OnReminderTimerTick;
            }
        }

        this.reminderTimer.Interval = new TimeSpan(0, 0, 10);
        StartReminderTimer();
    }

    private void StartReminderTimer()
    {
        this.StopReminderTimer();
        this.reminderTimer?.Start();
    }

    private void StopReminderTimer()
    {
        if (this.reminderTimer != null && !this.reminderTimer.IsRunning)
        {
            return;
        }

        this.reminderTimer?.Stop();
    }

    private void OnReminderTimerTick(object sender, EventArgs e)
    {
        DisplayAlert("Reminder Tick event Triggered", "Yes", "ok");
        //// set Time interval
        this.reminderTimer.Interval = new TimeSpan(0,1,0);
        StartReminderTimer();
    }
}

