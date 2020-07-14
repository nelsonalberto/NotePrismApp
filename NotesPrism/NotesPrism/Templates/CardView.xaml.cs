using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesPrism.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardView : ContentView
	{
		public CardView ()
		{
			InitializeComponent ();
		}

        #region Properties



        public string Imagen
        {
            get { return (string)GetValue(ImagenProperty); }
            set { SetValue(ImagenProperty, value); }
        }

        public static readonly BindableProperty ImagenProperty =
            BindableProperty.Create("Imagen", typeof(string), typeof(CardView), string.Empty);



        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create("Description", typeof(string), typeof(CardView), string.Empty);



        public string ComplementaryInfo
        {
            get { return (string)GetValue(ComplementaryInfoProperty); }
            set { SetValue(ComplementaryInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ComplementaryInfo.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ComplementaryInfoProperty =
            BindableProperty.Create("ComplementaryInfo", typeof(string), typeof(CardView), string.Empty);



        public string ActionTitle
        {
            get { return (string)GetValue(ActionTitleProperty); }
            set { SetValue(ActionTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActionTitle.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ActionTitleProperty =
            BindableProperty.Create("ActionTitle", typeof(string), typeof(CardView), string.Empty);



        public ICommand OnActionTitle
        {
            get { return (ICommand)GetValue(ButtonActionProperties); }
            set { SetValue(ButtonActionProperties, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static BindableProperty ButtonActionProperties =
            BindableProperty.Create(nameof(OnActionTitle), typeof(ICommand), typeof(CardView), default(ICommand));



        #endregion
    }
}