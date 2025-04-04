﻿using System;
using Microsoft.UI.Xaml.Controls.Primitives;
using Uno;
using Uno.Foundation.Extensibility;
using Uno.UI;

namespace Microsoft.UI.Xaml.Controls;

partial class TimePicker
{
	private static bool DEFAULT_NATIVE_STYLE = OperatingSystem.IsAndroid() || OperatingSystem.IsIOS();

	[UnoOnly]
	public static DependencyProperty UseNativeStyleProperty { get; } = DependencyProperty.Register(
		"UseNativeStyle",
		typeof(bool),
		typeof(TimePicker),
		new FrameworkPropertyMetadata(DEFAULT_NATIVE_STYLE));

	/// <summary>
	/// [UnoOnly] If we should use the native picker for the platform.
	/// IMPORTANT: must be set before the first time the picker is opened.
	/// </summary>
	[UnoOnly]
	public bool UseNativeStyle
	{
		get => (bool)GetValue(UseNativeStyleProperty);
		set => SetValue(UseNativeStyleProperty, value);
	}

	[UnoOnly]
	public static DependencyProperty UseNativeMinMaxDatesProperty { get; } = DependencyProperty.Register(
		"UseNativeMinMaxDates",
		typeof(bool),
		typeof(TimePicker),
		new FrameworkPropertyMetadata(false));

	/// <summary>
	/// [UnoOnly] When using native pickers (through the UseNativeStyle property),
	/// setting this to true will interpret MinYear/MaxYear as MinDate and MaxDate.
	/// </summary>
	/// <remarks>
	/// This property has no effect when not using native pickers.
	/// </remarks>
	[UnoOnly]
	public bool UseNativeMinMaxDates
	{
		get => (bool)GetValue(UseNativeMinMaxDatesProperty);
		set => SetValue(UseNativeMinMaxDatesProperty, value);
	}

	/// <summary>
	/// FlyoutPresenterStyle is an Uno-only property to allow the styling of the TimePicker's FlyoutPresenter.
	/// </summary>
	[UnoOnly]
	public Style FlyoutPresenterStyle
	{
		get => (Style)this.GetValue(FlyoutPresenterStyleProperty);
		set => this.SetValue(FlyoutPresenterStyleProperty, value);
	}

	[UnoOnly]
	public static DependencyProperty FlyoutPresenterStyleProperty { get; } =
		DependencyProperty.Register(
			nameof(FlyoutPresenterStyle),
			typeof(Style),
			typeof(TimePicker),
			new FrameworkPropertyMetadata(
				default(Style),
				FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));

	internal static TimePickerFlyout CreateFlyout(TimePicker timePicker)
	{
		var useNativeStyle = timePicker.UseNativeStyle;

		TimePickerFlyout flyout;
#if __ANDROID__ || __IOS__
		flyout = useNativeStyle ? new NativeTimePickerFlyout() : new TimePickerFlyout();
#elif __SKIA__
		if (useNativeStyle && ApiExtensibility.CreateInstance<ISkiaNativeTimePickerProviderExtension>(null, out var instance))
		{
			flyout = instance.CreateNativeTimePickerFlyout();
		}
		else
		{
			flyout = new TimePickerFlyout();
		}
#else
		flyout = new TimePickerFlyout();
#endif

		if (useNativeStyle)
		{
#if __IOS__
			flyout.Placement = timePicker.FlyoutPlacement;
#endif
			if (timePicker.FlyoutPresenterStyle is not null)
			{
				flyout.TimePickerFlyoutPresenterStyle = timePicker.FlyoutPresenterStyle;
			}

			void OnPicked(PickerFlyoutBase snd, TimePickedEventArgs evt)
			{
				timePicker.SelectedTime = evt.NewTime;
				timePicker.Time = evt.NewTime;

				if (evt.NewTime != evt.OldTime)
				{
					timePicker.TimeChanged?.Invoke(timePicker, new TimePickerValueChangedEventArgs(evt.NewTime, evt.OldTime));
				}

				flyout.TimePicked -= OnPicked;
			}

			flyout.TimePicked += OnPicked;
		}

		return flyout;
	}
}
