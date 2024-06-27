using Syncfusion.XForms.ComboBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ComboWordWrap
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Control> sortByItems;
        public ObservableCollection<Control> SortByItems
        {
            get { return sortByItems; }
            set
            {
                sortByItems = value;
                OnPropertyChanged("SortByItems");
            }
        }

        private object selectedSortOrder;
        public object SelectedSortOrder
        {
            get { return selectedSortOrder; }
            set
            {
                selectedSortOrder = value;
                OnPropertyChanged("SelectedSortOrder");
            }
        }
        public MainPage()
        {
            InitializeComponent();
            sortByItems = new ObservableCollection<Control>();
            sortByItems.Add(new Control() { Description = "The SfComboBox control allows the user to select an item either type a value" });
            sortByItems.Add(new Control() { Description = "Provide useful suggestions to users based on the already typed content" });
            sortByItems.Add(new Control() { Description = "The Schedule control is used to schedule and manage the appointment" });

            selectedSortOrder = new ObservableCollection<Control>();
            selectedSortOrder = sortByItems[0];
            this.BindingContext = this;
        }
    }

    public class Control
    {
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
    public class SfCustomComboBox:SfComboBox
    {

    }
}
