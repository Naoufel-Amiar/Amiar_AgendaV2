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

using Amiar_Agenda.Views;


namespace Amiar_Agenda
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

        private void BP_DEL_SUPPR_VIEW_Click(object sender, RoutedEventArgs e)
        {
            CONTAINERS.Children.Clear();
            AddContactPage addContactPage = new AddContactPage();
            CONTAINERS.Children.Add(addContactPage);
        }

        private void BP_Contact_View_Click(object sender, RoutedEventArgs e)
        {
            CONTAINERS.Children.Clear();
            ContactPage seeContacts = new ContactPage();
            CONTAINERS.Children.Add(seeContacts);


        }

        private void BTN_TODOLIST_VIEW_Click(object sender, RoutedEventArgs e)
        {
            CONTAINERS.Children.Clear();
            TodolistPage todolistPage = new TodolistPage();
            CONTAINERS.Children.Add(todolistPage);
        }

        private void BTN_CALENDAR_VIEW_Click(object sender, RoutedEventArgs e)
        {
            CONTAINERS.Children.Clear();
            CalanderPage calanderPage = new CalanderPage();
            CONTAINERS.Children.Add(calanderPage);
        }

        private void BTN_Settings_Click(object sender, RoutedEventArgs e)
        {
            CONTAINERS.Children.Clear();
            SettingsPage settingsPage = new SettingsPage();
            CONTAINERS.Children.Add(settingsPage);
        }
    }
}
