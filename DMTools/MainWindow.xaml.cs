using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DMTools.controllers;
using DMTools.models;

namespace DMTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        List<NPC> npcs = new List<NPC>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateNpc_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CreateNpcButton_Click(object sender, RoutedEventArgs e)
        {
            NPC npc = NpcController.CreateNpc();
            npcs.Add(npc);
            if (NpcGrid.ItemsSource == null)
            {
                NpcGrid.ItemsSource = npcs;
            }
            else
            {
                NpcGrid.Items.Refresh();
            }
        }
    }
}