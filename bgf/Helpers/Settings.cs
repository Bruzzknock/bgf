using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace bgf.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string SettingsKey = "settings_key";
        private const string Password = " ";
		private static readonly string SettingsDefault = string.Empty;

		#endregion


		public static string GeneralSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SettingsKey, value);
			}
		}

        public static string GeneralPassword
        {
            get
            {
                return AppSettings.GetValueOrDefault(Password, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Password, value);
            }
        }

        public static void Clear()
        {
            AppSettings.Clear();


        }
    }
}