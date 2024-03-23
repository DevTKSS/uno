﻿// <autogenerated />
namespace MyProject
{
	/// <summary>
	/// Contains all the static resources defined for the application
	/// </summary>
	public sealed partial class GlobalStaticResources
	{
		static bool _initialized;
		private static bool _stylesRegistered;
		private static bool _dictionariesRegistered;
		internal static global::Uno.UI.Xaml.XamlParseContext __ParseContext_ { get; } = new global::Uno.UI.Xaml.XamlParseContext()
		{
			AssemblyName = "TestProject",
		}
		;

		static GlobalStaticResources()
		{
			Initialize();
		}
		public static void Initialize()
		{
			if (!_initialized)
			{
				_initialized = true;
				global::Uno.UI.GlobalStaticResources.Initialize();
				global::Uno.UI.Toolkit.GlobalStaticResources.Initialize();
				global::Uno.UI.GlobalStaticResources.RegisterDefaultStyles();
				global::Uno.UI.Toolkit.GlobalStaticResources.RegisterDefaultStyles();
				global::Uno.UI.GlobalStaticResources.RegisterResourceDictionariesBySource();
				global::Uno.UI.Toolkit.GlobalStaticResources.RegisterResourceDictionariesBySource();
			}
		}
		public static void RegisterDefaultStyles()
		{
			if(!_stylesRegistered)
			{
				_stylesRegistered = true;
				RegisterDefaultStyles_MyDictionary_b7707bcf1e73425b710b6a5d04177088();
			}
		}
		// Register ResourceDictionaries using ms-appx:/// syntax, this is called for external resources
		public static void RegisterResourceDictionariesBySource()
		{
			if(!_dictionariesRegistered)
			{
				_dictionariesRegistered = true;
				global::Uno.UI.ResourceResolver.RegisterResourceDictionaryBySource(uri: "ms-appx:///TestProject/C:/Project/0/MyDictionary.xaml", context: __ParseContext_, dictionary: () => MyDictionary_b7707bcf1e73425b710b6a5d04177088_ResourceDictionary);
			}
		}
		// Register ResourceDictionaries using ms-resource:/// syntax, this is called for local resources
		internal static void RegisterResourceDictionariesBySourceLocal()
		{
			global::Uno.UI.ResourceResolver.RegisterResourceDictionaryBySource(uri: "ms-resource:///Files/C:/Project/0/MyDictionary.xaml", context: null, dictionary: () => MyDictionary_b7707bcf1e73425b710b6a5d04177088_ResourceDictionary, null);
			global::Uno.UI.ResourceResolver.RegisterResourceDictionaryBySource(uri: "ms-appx:///C:/Project/0/MyDictionary.xaml", context: null, dictionary: () => MyDictionary_b7707bcf1e73425b710b6a5d04177088_ResourceDictionary);
		}
		static partial void RegisterDefaultStyles_MyDictionary_b7707bcf1e73425b710b6a5d04177088();
		
	}
}