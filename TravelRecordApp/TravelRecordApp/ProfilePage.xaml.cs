﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var postTable = conn.Table<Post>().ToList();
                var categories = (from p in postTable
                                  orderby p.CategoryId
                                  select p.CategoryName).ToList();
                Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
                foreach(var category in categories)
                {
                    var count = (from post in postTable
                                 where post.CategoryName == category
                                 select post).ToList().Count;
                    categoriesCount.Add(category, count);
                }
                categoriesListView.ItemsSource = categoriesCount;
                postCountLabel.Text = postTable.Count.ToString();
            }
        }
    }
}