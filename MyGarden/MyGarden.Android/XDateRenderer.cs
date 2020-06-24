using Xamarin.Forms;
using MyGarden.Controls;
using XamarinBorderlessEntry.Droid.ControlHelpers;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(XDate), typeof(XDateRenderer))]
namespace XamarinBorderlessEntry.Droid.ControlHelpers
{
    public class XDateRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}