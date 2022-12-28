using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OW2ScoreboardController
{
	/// <summary>
	/// Manages UI localization.
	/// </summary>
	public static class LanguageManager
	{
        /// <summary>
        /// Language code (ex: "en-US") saved in the settings, or the OS's language code if set to "Automatic".
        /// </summary>
        public static string LanguageCode
        {
            get
            {
                if (Properties.Settings.Default.Language == "Automatic")
                {
                    // Use OS Language
                    return System.Globalization.CultureInfo.CurrentCulture.Name;
                }
                else
                {
                    return Properties.Settings.Default.Language;
                }
            }
        }

        /// <summary>
        /// Language class.
        /// </summary>
        public class Language
		{
			/// <summary>
			/// Main form.
			/// </summary>
			public MainForm mainForm;
			public struct MainForm
			{
				//------------------------------------------------------------------
				// Menu bar
				//------------------------------------------------------------------

				// File
				public string FileMenu;
				public string MenuItem_Exit;                                        // 終了

				// Options
				public string OptionMenu;
				public string MenuItem_AlwayOnTop;                                  // Always On Top
				public string MenuItem_StopUpdate;                                  // Pause Updates
				public string MenuItem_ClearScore;                                  // Clear Score
				public string MenuItem_SwitchMode;                                  // Switch Mode
                public string MenuItem_SwitchMode_RoleQueue;                        // Switch Mode -> Role Queue
                public string MenuItem_SwitchMode_OpenQueue;                        // Switch Mode -> Open Queue
				public string MenuItem_Language;                                    // Language
				public string MenuItem_Language_Automatic;                          // Language -> Automatic
				public string MenuItem_Settings;                                    // Settings

				// Help
				public string HelpMenu;
				public string MenuItem_Manual;                                      // Help
				public string MenuItem_Version;                                     // Version Information
			}

			/// <summary>
			/// Settings form.
			/// </summary>
			public SettingsForm settingsForm;
			public struct SettingsForm
			{
				public string WindowTitle;                                          // Window Title

				//------------------------------------------------------------------
				// General Tab
				//------------------------------------------------------------------
				public string TabPage_General;                                      // General Tab Title

				// Win/Loss Animation Group Box
				public string ProductionGroup;                                      // Win/Loss Animation (Group Header)
                public string EnableProductionCheckbox;                             // Enable Win/Loss Animation
                public string NameLabel;                                            // Name
				public string LogoLabel;                                            // Logo
				public string MainColorLabel;                                       // Primary Colour
				public string SubColorLabel;                                        // Secondary Colour
				public string FontColorLabel;                                       // Font Colour
				public string VolumeLabel;                                          // Volume

				// Scoreboard Group Box
				public string ScoreBoardGroup;                                      // Scoreboard (Group Header)
				public string ScoreBoardSizeLabel;                                  // Size
				public string ScoreBoardPositionLabel;                              // Scoreboard Position
				public string ScoreBoardPositionRadio_Top;                          // Scoreboard Position -> Top
                public string ScoreBoardPositionRadio_Bottom;                       // Scoreboard Position -> Bottom

                // Buttons
                public string OKButton;                                             // OK
				public string CancelButton;                                         // Cancel

				//------------------------------------------------------------------
				//  HotKey Tab
				//------------------------------------------------------------------
				public string TabPage_Hotkey;                                       // HotKey Tab Title

				public string HotkeyClearButton;                                    // Clear
			}

			/// <summary>
			/// Version Info form.
			/// </summary>
			public VersionInfo versionInfo;
			public struct VersionInfo
			{
				public string WindowTitle;                                          // Window Title
				public string VersionNumber;										// Version Number
			}

            // Warning displayed when F12 is assigned to a single hotkey
            public string InvalidHotkeyWarningTitle;
			public string InvalidHotkeyWarningMessage;

			// Clear score confirmation message
			public string ScoreClearConfirmMessage;
			public string ScoreClearConfirmTitle;

		}

        /// <summary>
        /// Get the language struct based on the specified language code.
        /// Defaults to English if language is not available.
		/// <para>NOTE: Only English is currently supported.</para>
        /// </summary>
        /// <param name="Code">Code of the language to retrieve. (ex: "en-US")</param>
        public static Language Get( string Code )
		{
            return GetEnglish();

			/*
			if (Code == "ja-JP")
			{
				return GetJapanese();
			}
			else
			{
				return GetEnglish();
			}
			*/
		}

        /// <summary>
        /// Get the language struct based on the language code saved in the settings. 
        /// Defaults to English if "Automatic" language is not available.
		/// <para>NOTE: Only English is currently supported.</para>
        /// </summary>
        public static Language Get()
		{
            return Get(LanguageCode);
        }

		/// <summary>
		/// Get the Japanese language struct.
		/// </summary>
		private static Language GetJapanese()
		{
			Language Japanese = new Language();

			// Main form
			Japanese.mainForm.FileMenu = "ファイル (&F)";
			Japanese.mainForm.MenuItem_Exit = "終了 (&X)";
			Japanese.mainForm.OptionMenu = "オプション (&O)";
			Japanese.mainForm.MenuItem_AlwayOnTop = "常に最前面に表示";
			Japanese.mainForm.MenuItem_StopUpdate = "反映を一時停止";
			Japanese.mainForm.MenuItem_ClearScore = "スコアをクリア";
			Japanese.mainForm.MenuItem_SwitchMode = "モードを切り替え";
			Japanese.mainForm.MenuItem_SwitchMode_RoleQueue = "ロールキュー";
			Japanese.mainForm.MenuItem_SwitchMode_OpenQueue = "オープンキュー";
			Japanese.mainForm.MenuItem_Language = "Language (&L)";
			Japanese.mainForm.MenuItem_Language_Automatic = "自動";
			Japanese.mainForm.MenuItem_Settings = "設定 (&C)...";
			Japanese.mainForm.HelpMenu = "ヘルプ(&H)";
			Japanese.mainForm.MenuItem_Manual = "ヘルプ";
			Japanese.mainForm.MenuItem_Version = "バージョン情報...";

			// Settings form
			Japanese.settingsForm.WindowTitle = "OW2Scoreboard 設定";
			Japanese.settingsForm.TabPage_General = "基本";
			Japanese.settingsForm.ProductionGroup = "勝敗演出";
			Japanese.settingsForm.EnableProductionCheckbox = "勝敗演出を有効にする";
			Japanese.settingsForm.NameLabel = "名前:";
			Japanese.settingsForm.LogoLabel = "ロゴ:";
			Japanese.settingsForm.MainColorLabel = "メインカラー:";
			Japanese.settingsForm.SubColorLabel = "サブカラー:";
			Japanese.settingsForm.FontColorLabel = "フォントカラー:";
			Japanese.settingsForm.VolumeLabel = "音量";
			Japanese.settingsForm.ScoreBoardGroup = "スコアボード";
			Japanese.settingsForm.ScoreBoardSizeLabel = "大きさ";
			Japanese.settingsForm.ScoreBoardPositionLabel = "表示位置";
			Japanese.settingsForm.ScoreBoardPositionRadio_Top = "上";
			Japanese.settingsForm.ScoreBoardPositionRadio_Bottom = "下";
			Japanese.settingsForm.OKButton = "OK";
			Japanese.settingsForm.CancelButton = "キャンセル";
			Japanese.settingsForm.TabPage_Hotkey = "ホットキー";
			Japanese.settingsForm.HotkeyClearButton = "クリア";

            // Version Info form
            Japanese.versionInfo.WindowTitle = "OW2Scoreboard バージョン情報";
			Japanese.versionInfo.VersionNumber = "バージョン " + Assembly.GetExecutingAssembly().GetName().Version;

            // Warning displayed when F12 is assigned to a single hotkey
            Japanese.InvalidHotkeyWarningMessage = "F12 キーは単体で設定しても動作しないことがあります。\r\nCtrl, Shift, Alt のいずれかと併せてご使用ください。\r\n\r\n警告を無視してこのまま続行しますか？";
			Japanese.InvalidHotkeyWarningTitle = "警告";

            // Clear score confirmation message
            Japanese.ScoreClearConfirmMessage = "スコアをクリアしてよろしいですか？";
			Japanese.ScoreClearConfirmTitle = "スコアのクリア";

			return Japanese;
		}

		/// <summary>
		/// Get the English language struct.
		/// </summary>
		private static Language GetEnglish()
		{
			Language English = new Language();

			// Main form
			English.mainForm.FileMenu = "File (&F)";
			English.mainForm.MenuItem_Exit = "Quit (&X)";
			English.mainForm.OptionMenu = "Options (&O)";
			English.mainForm.MenuItem_AlwayOnTop = "Always On Top";
			English.mainForm.MenuItem_StopUpdate = "Suspend Updates";
			English.mainForm.MenuItem_ClearScore = "Clear Score";
			English.mainForm.MenuItem_SwitchMode = "Switch Mode";
			English.mainForm.MenuItem_SwitchMode_RoleQueue = "Role Queue";
			English.mainForm.MenuItem_SwitchMode_OpenQueue = "Open Queue";
			English.mainForm.MenuItem_Language = "Language (&L)";
			English.mainForm.MenuItem_Language_Automatic = "Automatic";
			English.mainForm.MenuItem_Settings = "Settings (&C)...";
			English.mainForm.HelpMenu = "Help (&H)";
			English.mainForm.MenuItem_Manual = "Help";
			English.mainForm.MenuItem_Version = "Version Info...";

			// Settings form
			English.settingsForm.WindowTitle = "OW2Scoreboard Settings";
			English.settingsForm.TabPage_General = "General";
			English.settingsForm.ProductionGroup = "Win-Loss Animation";
			English.settingsForm.EnableProductionCheckbox = "Enable Win-Loss Animation";
			English.settingsForm.NameLabel = "Name:";
			English.settingsForm.LogoLabel = "Image:";
			English.settingsForm.MainColorLabel = "Primary Color:";
			English.settingsForm.SubColorLabel = "Secondary Color:";
			English.settingsForm.FontColorLabel = "Font Color:";
			English.settingsForm.VolumeLabel = "Volume";
			English.settingsForm.ScoreBoardGroup = "Scoreboard";
			English.settingsForm.ScoreBoardSizeLabel = "Size";
			English.settingsForm.ScoreBoardPositionLabel = "Location";
			English.settingsForm.ScoreBoardPositionRadio_Top = "Top";
			English.settingsForm.ScoreBoardPositionRadio_Bottom = "Bottom";
			English.settingsForm.OKButton = "OK";
			English.settingsForm.CancelButton = "Cancel";
			English.settingsForm.TabPage_Hotkey = "HotKey";
			English.settingsForm.HotkeyClearButton = "Clear";

			// Version Info form
			English.versionInfo.WindowTitle = "OW2Scoreboard Version Info";
            English.versionInfo.VersionNumber = "Version " + Assembly.GetExecutingAssembly().GetName().Version;

            // Warning displayed when F12 is assigned to a single hotkey
            English.InvalidHotkeyWarningMessage = "The F12 key may not operate even if it is set as a single hotkey.\r\nPlease use it together with Ctrl, Shift, Alt.\r\n\r\nIgnore the warning and continue this way?";
			English.InvalidHotkeyWarningTitle = "Caution";

            // Clear score confirmation message
            English.ScoreClearConfirmMessage = "Are you sure you want to clear the score?";
			English.ScoreClearConfirmTitle = "Clear Score";

			return English;
		}
	}
}
