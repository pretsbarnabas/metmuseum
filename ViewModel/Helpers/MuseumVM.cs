﻿using museum_api.Model;
using museum_api.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace museum_api.ViewModel.Helpers
{
    public class MuseumVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public SearchCommand SearchCommand { get; set; }
        public WebLink WebLinkCommand { get; set; }
        private string hasselected;

        public string HasSelected
        {
            get { return hasselected; }
            set { hasselected = value; OnPropertyChanged(nameof(HasSelected)); }
        }

        private Art selectedart;
        private int selectedItem;

        public int SelectedItem
        {
            get { return selectedItem; }
            set {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                GetArtInfo();
            }
        }

        private bool checkboxChecked;

        public bool CheckboxChecked
        {
            get { return checkboxChecked; }
            set
            {
                checkboxChecked = value;
                OnPropertyChanged(nameof(checkboxChecked));
            }

        }
        public Art SelectedArt
        {
            get { return selectedart; }
            set 
            { 
                selectedart = value; 
                OnPropertyChanged(nameof(selectedart));
            }
        }
        private string query;

        public string Query
        {
            get { return query; }
            set 
            { 
                query = value; 
                OnPropertyChanged(nameof(query));
            }
        }
        public ObservableCollection<int> IdList { get; set; }



        public MuseumVM() 
        {
            SearchCommand = new SearchCommand(this);
            WebLinkCommand = new WebLink(this);
            hasselected = "Hidden";
            IdList = new();
        }


        public async void MakeQuery()
        {
            if (string.IsNullOrWhiteSpace(Query)) return;
            IdList.Clear();
            var result = await API_Helper.SearchArt(Query, CheckboxChecked);
            if(result != null)
            {
                foreach (var item in result)
                {
                    IdList.Add(item);
                }
            }
        }

        private async void GetArtInfo()
        {
            SelectedArt = await API_Helper.GetArtInfo(SelectedItem);
            HasSelected = "Visible";
        }
        private void OnPropertyChanged(string v)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
        }
        public void Wiki_RequestNavigate()
        {
            Process.Start(new ProcessStartInfo(SelectedArt.objectURL) { UseShellExecute = true });
        }
    }
}
