using Xamarin.Forms;
using MyGarden.Controls;
using XamarinBorderlessEntry.Droid.ControlHelpers;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;

#pragma warning disable CS0612 // O tipo ou membro é obsoleto
[assembly: ExportRenderer(typeof(XDate), typeof(XDateRenderer))]
#pragma warning restore CS0612 // O tipo ou membro é obsoleto
namespace XamarinBorderlessEntry.Droid.ControlHelpers
{
    [System.Obsolete]
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