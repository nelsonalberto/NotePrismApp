using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NotesPrism.Droid.Renders;
using NotesPrism.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CButtonRenderer), typeof(ButtonRendererAndroid))]
namespace NotesPrism.Droid.Renders
{
    public class ButtonRendererAndroid : ButtonRenderer
    {
        public ButtonRendererAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            Control.SetAllCaps(false);
           
        }
    }
}