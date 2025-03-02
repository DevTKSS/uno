using Microsoft.UI.Xaml;
public partial namespace Uno.UI.Xaml.Markup
{
	public interface IXamlRootProvider
	{
		public XamlRoot GetXamlRoot();
		public void Initialize(XamlRoot XamlRoot);
	}
}
