﻿using System;
using System.Collections.Generic;
using System.Text;
using Windows.Devices.Input;
using Windows.Foundation;
using Uno.Disposables;
using Uno.UI;

namespace Microsoft.UI.Xaml.Controls;

partial class ScrollContentPresenter
{
	partial void InitializePartial()
	{
		PointerMoved += OnPointerMoved;
	}

	private void OnPointerMoved(object sender, Input.PointerRoutedEventArgs e)
	{
		if ((PointerDeviceType)e.Pointer.PointerDeviceType == PointerDeviceType.Touch)
		{
			// Prevent PointerMoved being called on parent, as on UWP.
			// Note: We only want to do this if the ScrollViewer is actually scrollable (in any direction), but at present on Android
			// PointerMoved is only raised if content is scrollable - presumably because it's in this case that the inner
			// NativeScrollContentPresenter 'blocks' the touch according to Uno's pointer logic.
			e.Handled = true;
		}
	}
}
