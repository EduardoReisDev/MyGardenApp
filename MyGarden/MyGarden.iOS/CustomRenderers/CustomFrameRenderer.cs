using System;
using System.Drawing;
using MyGarden.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Frame), typeof(CustomFrameRenderer))]
namespace MyGarden.iOS.CustomRenderers
{
    public class CustomFrameRenderer : FrameRenderer
    {
        public CustomFrameRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (Layer != null && Element != null)
            {
                ConfigureShadow(Element.HasShadow);
            }
        }

        private void ConfigureShadow(bool hasShadow)
        {
            if (hasShadow)
            {
                Layer.ShadowColor = UIColor.DarkGray.CGColor;
                Layer.ShadowOpacity = 0.2f;
                Layer.ShadowRadius = 8.0f;
                Layer.ShadowOffset = new SizeF(0, 5);
            }
            else
            {
                Layer.ShadowOpacity = 0.0f;
                Layer.ShadowRadius = 0.0f;
                Layer.ShadowOffset = new SizeF(0, 0);
            }
        }
    }
}
