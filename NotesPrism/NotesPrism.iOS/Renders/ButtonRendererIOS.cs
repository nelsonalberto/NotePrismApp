using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using NotesPrism.iOS.Renders;
using NotesPrism.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CButtonRenderer), typeof(ButtonRendererIOS))]
namespace NotesPrism.iOS.Renders
{
    public class ButtonRendererIOS: ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

        }
    }
}