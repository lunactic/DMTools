﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
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
            List<Item> items = ItemController.GetAllItems();
            Items _items = (Items) this.Resources["items"];
            items.ForEach(_items.Add);

            List<Monster> monsters = MonsterController.GetAllMonsters();
            Monsters _monsters = (Monsters) this.Resources["monsters"];
            monsters.ForEach(_monsters.Add);


        }


        private void createShops_Click(object sender, RoutedEventArgs e)
        {
            npcs.Clear();
            Shop alchemyShop = ShopController.CreateAlchemy();
            LblAlchOwner.Content = alchemyShop.owner.FirstName + " " + alchemyShop.owner.Lastname;
            LblAlchName.Content = alchemyShop.name;
            npcs.Add(alchemyShop.owner);

            Shop jewelShop = ShopController.CreateJewlerry();
            LblJewOwner.Content = jewelShop.owner.FirstName + " " + jewelShop.owner.Lastname;
            LblJewName.Content = jewelShop.name;
            npcs.Add(jewelShop.owner);

            Shop inn = ShopController.CreateInn();
            LblInnOwner.Content = inn.owner.FirstName + " " + inn.owner.Lastname;
            LblInnName.Content = inn.name;
            npcs.Add(inn.owner);

            Shop blacksmith = ShopController.CreateBlacksmith();
            LblBlackOwner.Content = blacksmith.owner.FirstName + " " + blacksmith.owner.Lastname;
            LblBlackName.Content = blacksmith.name;
            npcs.Add(blacksmith.owner);

            Shop enchanterShop = ShopController.CreateEnchanter();
            LblEnchOwner.Content = enchanterShop.owner.FirstName + " " + enchanterShop.owner.Lastname;
            LblEnchName.Content = enchanterShop.name;
            npcs.Add(enchanterShop.owner);

            Shop magicShop = ShopController.CreateJewlerry();
            LblMagicOwner.Content = magicShop.owner.FirstName + " " + magicShop.owner.Lastname;
            LblMagicName.Content = magicShop.name;
            npcs.Add(magicShop.owner);
            if (NpcGrid.ItemsSource == null)
            {
                NpcGrid.ItemsSource = npcs;
            }
            else
            {
                NpcGrid.Items.Refresh();
            }
        }


        private void ItemSearch_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource cvsItems = (CollectionViewSource) this.Resources["cvsItems"];
            cvsItems.View.Refresh();
        }

        private void MonsterSearch_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource cvsItems = (CollectionViewSource)this.Resources["cvsMonsters"];
            cvsItems.View.Refresh();
        }

        private void ItemGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Console.Out.WriteLine((((DataGrid)sender).SelectedItem as Item).Name);
            ItemDetails details = new ItemDetails(((DataGrid)sender).SelectedItem as Item);
            details.Show();

        }
        
        private void ItemNameFilter(object sender, FilterEventArgs e)
        {
            Item item = e.Item as Item;

            if (item.Name.Contains(TxtItemSearch.Text))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void MonsterNameFilter(object sender, FilterEventArgs e)
        {
            Monster monster = e.Item as Monster;
            if (monster.Name.Contains(TxtMonsterSearch.Text))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }

        }
    }
}