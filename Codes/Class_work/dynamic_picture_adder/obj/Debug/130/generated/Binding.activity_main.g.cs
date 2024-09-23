using global::System;
using global::Android.App;
using global::Android.Widget;
using global::Android.Views;
using global::Android.OS;

namespace Binding
{
	sealed class activity_main : global::Xamarin.Android.Design.LayoutBinding
	{

		[global::Android.Runtime.PreserveAttribute (Conditional=true)]
		public activity_main (
			global::Android.App.Activity client,
			global::Xamarin.Android.Design.OnLayoutItemNotFoundHandler itemNotFoundHandler = null)
				: base (client, itemNotFoundHandler)
		{}

		[global::Android.Runtime.PreserveAttribute (Conditional=true)]
		public activity_main (
			global::Android.Views.View client,
			global::Xamarin.Android.Design.OnLayoutItemNotFoundHandler itemNotFoundHandler = null)
				: base (client, itemNotFoundHandler)
		{}


		#line 13 "Resources\layout\activity_main.xml"

		EditText __amountToshow;

		#line default
		#line hidden

		#line 13 "Resources\layout\activity_main.xml"

		// Declared in: Resources\layout\activity_main.xml:(13:10)
		// Declared in: Resources\layout\activity_main.xml:(13:10)
		public EditText amountToshow => FindView (global::dynamic_picture_adder.Resource.Id.amountToshow, ref __amountToshow);

		#line default
		#line hidden


		#line 19 "Resources\layout\activity_main.xml"

		Button __show;

		#line default
		#line hidden

		#line 19 "Resources\layout\activity_main.xml"

		// Declared in: Resources\layout\activity_main.xml:(19:10)
		// Declared in: Resources\layout\activity_main.xml:(19:10)
		public Button show => FindView (global::dynamic_picture_adder.Resource.Id.show, ref __show);

		#line default
		#line hidden


		#line 24 "Resources\layout\activity_main.xml"

		LinearLayout __toShow;

		#line default
		#line hidden

		#line 24 "Resources\layout\activity_main.xml"

		// Declared in: Resources\layout\activity_main.xml:(24:6)
		// Declared in: Resources\layout\activity_main.xml:(24:6)
		public LinearLayout toShow => FindView (global::dynamic_picture_adder.Resource.Id.toShow, ref __toShow);

		#line default
		#line hidden

	}
}
