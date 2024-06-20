using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ComboWordWrap;
using ComboWordWrap.Droid;
using Syncfusion.Android.ComboBox;
using Syncfusion.XForms.Android.ComboBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(SfCustomComboBox), typeof(CustomRenderer))]
namespace ComboWordWrap.Droid
{
    public class CustomRenderer:SfComboBoxRenderer
    {
        public CustomRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Syncfusion.XForms.ComboBox.SfComboBox> e)
        {
            base.OnElementChanged(e);
            Control.GetAutoEditText().SetLines(8);
            Control.GetAutoEditText().SetHorizontallyScrolling(false);
        }
    }
}