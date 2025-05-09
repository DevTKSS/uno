﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Core
{
#if __ANDROID__ || __APPLE_UIKIT__
	[TestClass]
	public class Given_CoreDispatcher
	{
		[TestMethod]
		public async Task When_RunAsync()
		{
			const string Success = "success";
			string result = string.Empty;
			try
			{
				await CoreDispatcher.Main.RunAsync(() => result = Success);
			}
			catch (Exception)
			{
				result = "failure";
			}
			Assert.AreEqual(Success, result);

			result = string.Empty;
			try
			{
				await CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, () => result = Success);
			}
			catch (Exception)
			{
				result = "failure";
			}
			Assert.AreEqual(Success, result);

			result = string.Empty;
			try
			{
				await Task.Run(() => result = Success);
			}
			catch (Exception)
			{
				result = "failure";
			}
			Assert.AreEqual(Success, result);
		}
	}
	internal static class CoreDispatcherExtensions
	{
		internal static IAsyncAction RunAsync(this CoreDispatcher coreDispatcher, DispatchedHandler dispatchedHandler)
		{
			return coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, dispatchedHandler);
		}
	}
#endif
}
