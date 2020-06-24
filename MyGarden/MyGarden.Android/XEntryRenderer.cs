using Xamarin.Forms;
using MyGarden.Controls;
using XamarinBorderlessEntry.Droid.ControlHelpers;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(XEntry), typeof(XEntryRenderer))]
namespace XamarinBorderlessEntry.Droid.ControlHelpers
{
    public class XEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}