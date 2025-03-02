public partial namespace Uno.UI.Xaml.Markup
{
	public class XamlRootProvider(ILogger<XamlRootProvider>? logger = null) : IXamlRootProvider
	{
		private readonly ILogger<XamlRootProvider>? _logger = logger;
		private static XamlRootProvider? _xamlRoot;
		public XamlRoot? GetXamlRoot()
		{
			if(_xamlRoot == null)
			{
				_logger?.LogError("XamlRootProvider has not been initialized. Call Initialize first.");
			}
			return _xamlRoot;
		};
		public void Initialize(XamlRoot XamlRoot);
	}
}
