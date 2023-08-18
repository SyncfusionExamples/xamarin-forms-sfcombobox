using Syncfusion.XForms.ComboBox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ComboBoxFilterSample
{
    public partial class MainPage : ContentPage
    {
        ListView MainListView;
        public MainPage()
        {
            InitializeComponent();
            EmployeeViewModel viewModel = new EmployeeViewModel();
            this.BindingContext = viewModel;
            StackLayout stackLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                Padding = new Thickness(30),
                Margin = new Thickness(50)
            };

            SfComboBox comboBox = new SfComboBox()
            {
                HeightRequest = 40,
                WidthRequest = 200,
                IsEditableMode = true,
                AllowFiltering = true,
                DisplayMemberPath = "Name",
                SuggestionBoxPlacement = SuggestionBoxPlacement.None,
                SuggestionMode = SuggestionMode.Contains,
                DataSource = viewModel.EmployeeCollection
            };

            comboBox.FilterCollectionChanged += ComboBox_FilterCollectionChanged;
            Binding filteredItemsBinding = new Binding();
            filteredItemsBinding.Source = viewModel;
            filteredItemsBinding.Path = "Items";
            filteredItemsBinding.Mode = BindingMode.TwoWay;
            comboBox.SetBinding(SfComboBox.FilteredItemsProperty, filteredItemsBinding);
            StackLayout stack = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Margin = new Thickness(0, 50, 0, 0)
            };

            Label filteredItemsLabel = new Label()
            {
                Text = "Filtered Items",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Green
            };

            MainListView = new ListView()
            {
                RowHeight = 30
            };

            DataTemplate itemTemplate = new DataTemplate(() =>
            {
                StackLayout layout = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal
                };

                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                layout.Children.Add(nameLabel);

                return new ViewCell { View = layout };
            });

            MainListView.ItemTemplate = itemTemplate;

            stack.Children.Add(filteredItemsLabel);
            stack.Children.Add(MainListView);
            stackLayout.Children.Add(comboBox);
            stackLayout.Children.Add(stack);
            this.Content = stackLayout;
        }
        private void ComboBox_FilterCollectionChanged(object sender, FilterCollectionChangedEventArgs e)
        {
            MainListView.ItemsSource = (IEnumerable)e.Value;
        }
    }
}
