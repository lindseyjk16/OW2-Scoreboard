using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using DropDownControls;
using System.Collections;

namespace OW2ScoreboardController
{
	public partial class MainForm : Form
	{
		HotKey WinHotkey;
		HotKey LoseHotkey;
		HotKey DrawHotkey;

		public MainForm()
		{
			InitializeComponent();
		}

		private void OnLoad( object sender, EventArgs e )
		{
			// Restore previous window position
			Point WindowPosition = Properties.Settings.Default.WindowPosition;
			Point UnsetValue = new Point(-1234, -5678);
			if( WindowPosition != UnsetValue )
			{
				DesktopLocation = WindowPosition;
			}

			// Disable maximize button
			this.MaximizeBox = false;

			// Restore language settings
			switch(Properties.Settings.Default.Language)
			{
				case "ja-JP":
					MenuItem_Language_Japanese_Click(null, null);
					break;
				case "en-US":
					MenuItem_Language_English_Click(null, null);
					break;
				case "Automatic":
				default:
					MenuItem_Language_Automatic_Click(null, null);
					break;
			}
			SetLanguage();

			// Populate rank dropdowns
			PopulateRanks();

			// Read score and set values
			ScoreManager.Score Score = ScoreManager.Load();

            Rank tankRank = new Rank(Score.TankRankDivision, Score.TankRankTier);
			Rank damageRank = new Rank(Score.DamageRankDivision, Score.DamageRankTier);
			Rank supportRank = new Rank(Score.SupportRankDivision, Score.SupportRankTier);

            WinsUpDown.Value = Score.Wins;
			LosesUpDown.Value = Score.Loses;
			DrawsUpDown.Value = Score.Draws;
			TankRankEnabledCheckBox.Checked = Score.IsTankRankEnabled;
			DamageRankEnabledCheckBox.Checked = Score.IsDamageRankEnabled;
			SupportRankEnabledCheckBox.Checked = Score.IsSupportRankEnabled;
            TankRankDropdown.SelectedValue = tankRank.Value;
            DamageRankDropdown.SelectedValue = damageRank.Value;
            SupportRankDropdown.SelectedValue = supportRank.Value;
            TankInPlacementCheckbox.Checked = Score.IsTankInPlacement;
			DamageInPlacementCheckbox.Checked = Score.IsDamageInPlacement;
			SupportInPlacementCheckbox.Checked = Score.IsSupportInPlacement;
			SetQueueMode(Score.IsOpenQueueMode);

			// Enable hotkeys
			SetHotkeysFromConfig();
		}

		/// <summary>
		/// Populate rank dropdowns.
		/// </summary>
		private void PopulateRanks()
		{
			List<Rank> allRanks = new List<Rank>();
			
			foreach(RankDivision division in Enum.GetValues(typeof(RankDivision)))
			{
				foreach(RankTier tier in Enum.GetValues(typeof(RankTier)))
				{
					allRanks.Add(new Rank(division, tier));
				}
			}

            TankRankDropdown.ValueMember = "Value";
            TankRankDropdown.DisplayMember = "RankName";
            TankRankDropdown.GroupMember = "Division";
            TankRankDropdown.DataSource = new BindingSource(allRanks, String.Empty);

            DamageRankDropdown.ValueMember = "Value";
            DamageRankDropdown.DisplayMember = "RankName";
            DamageRankDropdown.GroupMember = "Division";
            DamageRankDropdown.DataSource = new BindingSource(allRanks, String.Empty);

            SupportRankDropdown.ValueMember = "Value";
            SupportRankDropdown.DisplayMember = "RankName";
            SupportRankDropdown.GroupMember = "Division";
            SupportRankDropdown.DataSource = new BindingSource(allRanks, String.Empty);
        }

        private void LosesUpDown_ValueChanged( object sender, EventArgs e )
		{
			if( LosesUpDown.Value.ToString() == "" )
			{
				LosesUpDown.Value = 0;
			}

			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void WinsUpDown_ValueChanged( object sender, EventArgs e )
		{
			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

        private void TankRankDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!MenuItem_StopUpdate.Checked)
            {
                ResetTimer();
            }
            else
            {
                SaveTimer.Enabled = false;
            }
        }

        private void DamageRankDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!MenuItem_StopUpdate.Checked)
            {
                ResetTimer();
            }
            else
            {
                SaveTimer.Enabled = false;
            }
        }

        private void SupportRankDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!MenuItem_StopUpdate.Checked)
            {
                ResetTimer();
            }
            else
            {
                SaveTimer.Enabled = false;
            }
        }

        private void DrawsUpDown_ValueChanged( object sender, EventArgs e )
		{
			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void SaveTimer_Tick( object sender, EventArgs e )
		{
			SaveScore();

			SaveTimer.Enabled = false;
			WinButton.Enabled = true;
			LoseButton.Enabled = true;
			DrawButton.Enabled = true;
		}

		private void SaveScore()
		{
			Rank tankRank = (Rank)TankRankDropdown.SelectedItem;
			Rank damageRank = (Rank)DamageRankDropdown.SelectedItem;
			Rank supportRank = (Rank)SupportRankDropdown.SelectedItem;

            ScoreManager.Score Score = new ScoreManager.Score
			(
				(int)WinsUpDown.Value, (int)LosesUpDown.Value, (int)DrawsUpDown.Value,
				TankRankEnabledCheckBox.Checked, DamageRankEnabledCheckBox.Checked, SupportRankEnabledCheckBox.Checked,
                tankRank.Division.ToString(), (int)tankRank.Tier,
                damageRank.Division.ToString(), (int)damageRank.Tier,
                supportRank.Division.ToString(), (int)supportRank.Tier,
                TankInPlacementCheckbox.Checked, DamageInPlacementCheckbox.Checked, SupportInPlacementCheckbox.Checked,
				MenuItem_SwitchMode_OpenQueue.Checked
			);
			ScoreManager.Save(Score);
		}

		private void ResetTimer()
		{
			SaveTimer.Enabled = false;
			SaveTimer.Enabled = true;
		}

		private void WinButton_Click( object sender, EventArgs e )
		{
			if( WinButton.Enabled )
			{
				WinsUpDown.Value++;

				if( !MenuItem_StopUpdate.Checked )
				{
					WinButton.Enabled = false;
					LoseButton.Enabled = false;
					DrawButton.Enabled = false;
					ResetTimer();
				}
			}
		}

		private void LoseButton_Click( object sender, EventArgs e )
		{
			if( LoseButton.Enabled )
			{
				LosesUpDown.Value++;

				if( !MenuItem_StopUpdate.Checked )
				{
					WinButton.Enabled = false;
					LoseButton.Enabled = false;
					DrawButton.Enabled = false;
					ResetTimer();
				}
			}
		}

		private void DrawButton_Click( object sender, EventArgs e )
		{
			if( DrawButton.Enabled )
			{
				DrawsUpDown.Value++;

				if( !MenuItem_StopUpdate.Checked )
				{
					WinButton.Enabled = false;
					LoseButton.Enabled = false;
					DrawButton.Enabled = false;
					ResetTimer();
				}
			}
		}

		private void MenuItem_ClearScore_Click( object sender, EventArgs e )
		{
			// Get language struct according to settings
			// NOTE: Only English is currently supported
			LanguageManager.Language Language = LanguageManager.Get();

			string ConfirmMessage = Language.ScoreClearConfirmMessage;
			string ConfirmTitle = Language.ScoreClearConfirmTitle;


			DialogResult Result = MessageBox.Show( ConfirmMessage,
				ConfirmTitle,
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Information,
				MessageBoxDefaultButton.Button2 );

			if( Result == DialogResult.OK )
			{
				WinsUpDown.Value = 0;
				LosesUpDown.Value = 0;
				DrawsUpDown.Value = 0;

				if( !MenuItem_StopUpdate.Checked )
				{
					WinButton.Enabled = false;
					LoseButton.Enabled = false;
					DrawButton.Enabled = false;
					ResetTimer();
				}
			}
		}

		private void MenuItem_Version_Click( object sender, EventArgs e )
		{
			Form VersionInfoForm = new VersionInfoForm();
			VersionInfoForm.ShowInTaskbar = false;
			VersionInfoForm.ShowDialog();
		}

		private void MenuItem_Manual_Click( object sender, EventArgs e )
		{
			// Open localized help document according to settings
			// Defaults to English if language is unavailable
			// NOTE: Only English is currently supported
			string Language = LanguageManager.LanguageCode;

            System.Diagnostics.Process.Start("https://github.com/lindseyjk16/OW2Scoreboard/blob/master/Help_en.md");

            /*
			if (Language == "ja-JP")
			{
				System.Diagnostics.Process.Start("https://github.com/lindseyjk16/OW2Scoreboard/blob/master/Help_ja.md");
			}
			else
			{
				System.Diagnostics.Process.Start("https://github.com/lindseyjk16/OW2Scoreboard/blob/master/Help_en.md");
			}
			*/
        }

		private void MenuItem_AlwayOnTop_Click( object sender, EventArgs e )
		{
			this.TopMost = MenuItem_AlwayOnTop.Checked;
			Properties.Settings.Default.AlwaysOnTop = MenuItem_AlwayOnTop.Checked;
		}

		private void MenuItem_Exit_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void MenuItem_Settings_Click( object sender, EventArgs e )
		{
			// Disable hotkeys
			if( WinHotkey != null ) WinHotkey.Dispose();
			if( LoseHotkey != null ) LoseHotkey.Dispose();
			if( DrawHotkey != null ) DrawHotkey.Dispose();
			WinHotkey = new HotKey( MOD_KEY.NONE, Keys.None );
			LoseHotkey = new HotKey( MOD_KEY.NONE, Keys.None );
			DrawHotkey = new HotKey( MOD_KEY.NONE, Keys.None );

			Form SettingsForm = new SettingsForm();
			SettingsForm.ShowInTaskbar = false;
			SettingsForm.ShowDialog();
			SetHotkeysFromConfig();
		}

		private void MenuItem_StopUpdate_Click( object sender, EventArgs e )
		{
			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
		}

		private void WinsUpDown_KeyUp( object sender, KeyEventArgs e )
		{
			if( WinsUpDown.Text == string.Empty )
			{
				WinsUpDown.Value = 0;
				WinsUpDown.Text = "0";
			}

			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
		}

		private void LosesUpDown_KeyUp( object sender, KeyEventArgs e )
		{
			if( LosesUpDown.Text == string.Empty )
			{
				LosesUpDown.Value = 0;
				LosesUpDown.Text = "0";
			}

			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
		}

		private void DrawsUpDown_KeyUp( object sender, KeyEventArgs e )
		{
			if( DrawsUpDown.Text == string.Empty )
			{
				DrawsUpDown.Value = 0;
				DrawsUpDown.Text = "0";
			}

			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
		}

		private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
		{
			// Dispose hotkeys
			if( WinHotkey != null ) WinHotkey.Dispose();
			if( LoseHotkey != null ) LoseHotkey.Dispose();
			if( DrawHotkey != null ) DrawHotkey.Dispose();

			// Remember window position
			Properties.Settings.Default.WindowPosition = DesktopLocation;

			// Save score and settings
			SaveScore();
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// Load config and enable hotkeys.
		/// </summary>
		private void SetHotkeysFromConfig()
		{
			ConfigManager.Config Config = ConfigManager.Load();
			if (Config.WinHotkey.KeyCode != Keys.None && Config.WinHotkey != null)
			{
				WinHotkey = new HotKey(Config.WinHotkey.ModKey, Config.WinHotkey.KeyCode);
				WinHotkey.HotKeyPush += new EventHandler(WinButton_Click);
			}
			if (Config.LoseHotkey.KeyCode != Keys.None && Config.LoseHotkey != null)
			{
				LoseHotkey = new HotKey(Config.LoseHotkey.ModKey, Config.LoseHotkey.KeyCode);
				LoseHotkey.HotKeyPush += new EventHandler(LoseButton_Click);
			}
			if (Config.DrawHotkey.KeyCode != Keys.None && Config.DrawHotkey != null)
			{
				DrawHotkey = new HotKey(Config.DrawHotkey.ModKey, Config.DrawHotkey.KeyCode);
				DrawHotkey.HotKeyPush += new EventHandler(DrawButton_Click);
			}
		}

        /// <summary>
        /// Set language.
        /// <para>NOTE: Only English is currently supported.</para>
        /// </summary>
        private void SetLanguage()
		{
            // Get language struct according to settings
            LanguageManager.Language Language = LanguageManager.Get();

			// Set localization
			FileMenu.Text = Language.mainForm.FileMenu;
			MenuItem_Exit.Text = Language.mainForm.MenuItem_Exit;
			OptionMenu.Text = Language.mainForm.OptionMenu;
			MenuItem_AlwayOnTop.Text = Language.mainForm.MenuItem_AlwayOnTop;
			MenuItem_StopUpdate.Text = Language.mainForm.MenuItem_StopUpdate;
			MenuItem_ClearScore.Text = Language.mainForm.MenuItem_ClearScore;
			MenuItem_SwitchMode.Text = Language.mainForm.MenuItem_SwitchMode;
			MenuItem_SwitchMode_RoleQueue.Text = Language.mainForm.MenuItem_SwitchMode_RoleQueue;
			MenuItem_SwitchMode_OpenQueue.Text = Language.mainForm.MenuItem_SwitchMode_OpenQueue;
			MenuItem_Language.Text = Language.mainForm.MenuItem_Language;
			MenuItem_Language_Automatic.Text = Language.mainForm.MenuItem_Language_Automatic;
			MenuItem_Settings.Text = Language.mainForm.MenuItem_Settings;
			HelpMenu.Text = Language.mainForm.HelpMenu;
			MenuItem_Manual.Text = Language.mainForm.MenuItem_Manual;
			MenuItem_Version.Text = Language.mainForm.MenuItem_Version;
		}

		private void MenuItem_Language_Automatic_Click(object sender, EventArgs e)
		{
			MenuItem_Language_Automatic.Checked = true;
			MenuItem_Language_Japanese.Checked = false;
			MenuItem_Language_English.Checked = false;

			Properties.Settings.Default.Language = "Automatic";
			SetLanguage();
		}

		private void MenuItem_Language_Japanese_Click(object sender, EventArgs e)
		{
			MenuItem_Language_Automatic.Checked = false;
			MenuItem_Language_Japanese.Checked = true;
			MenuItem_Language_English.Checked = false;

			Properties.Settings.Default.Language = "ja-JP";
			SetLanguage();
		}

		private void MenuItem_Language_English_Click(object sender, EventArgs e)
		{
			MenuItem_Language_Automatic.Checked = false;
			MenuItem_Language_Japanese.Checked = false;
			MenuItem_Language_English.Checked = true;

			Properties.Settings.Default.Language = "en-US";
			SetLanguage();
		}

		private void InPlacementCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}

			TankRankDropdown.Enabled = !TankInPlacementCheckbox.Checked;
        }

		private void DamageInPlacementCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}

			DamageRankDropdown.Enabled = !DamageInPlacementCheckbox.Checked;
        }

		private void SupportInPlacementCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}

			SupportRankDropdown.Enabled = !SupportInPlacementCheckbox.Checked;
        }

		private void MainForm_Shown(object sender, EventArgs e)
		{
			// Always restore display state to foreground
			this.TopMost = Properties.Settings.Default.AlwaysOnTop;
			MenuItem_AlwayOnTop.Checked = this.TopMost;
		}

		private void StartingRateTankCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool enabled = TankRankEnabledCheckBox.Checked;
            TankRankDropdown.Enabled = enabled && !TankInPlacementCheckbox.Checked;
			TankInPlacementCheckbox.Enabled = enabled;

			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void StartingRateDamageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool enabled = DamageRankEnabledCheckBox.Checked;
            DamageRankDropdown.Enabled = enabled && !DamageInPlacementCheckbox.Checked;
            DamageInPlacementCheckbox.Enabled = enabled;

			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void StartingRateSupportCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool enabled = SupportRankEnabledCheckBox.Checked;
            SupportRankDropdown.Enabled = enabled && !SupportInPlacementCheckbox.Checked;
            SupportInPlacementCheckbox.Enabled = enabled;

			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void MenuItem_SwitchOpenQueueMode_Click(object sender, EventArgs e)
		{
			SetQueueMode(true);
		}

		private void MenuItem_SwitchRoleQueueMode_Click(object sender, EventArgs e)
		{
			SetQueueMode(false);
		}

		private void SetQueueMode(bool IsOpenQueueMode)
		{
			MenuItem_SwitchMode_OpenQueue.Checked = IsOpenQueueMode;
			MenuItem_SwitchMode_RoleQueue.Checked = !IsOpenQueueMode;

			TankRankEnabledCheckBox.Enabled = !IsOpenQueueMode;
			DamageRankEnabledCheckBox.Enabled = !IsOpenQueueMode;
			SupportRankEnabledCheckBox.Enabled = !IsOpenQueueMode;

			//TankStartingRateUpDown.Enabled = (IsOpenQueueMode && !TankInPlacementCheckbox.Checked || (TankStartingRateEnabledCheckBox.Checked && !TankInPlacementCheckbox.Checked));
			//DamageStartingRateUpDown.Enabled = (!IsOpenQueueMode && DamageStartingRateEnabledCheckBox.Checked && !DamageInPlacementCheckbox.Checked);
			//SupportStartingRateUpDown.Enabled = (!IsOpenQueueMode && SupportStartingRateEnabledCheckBox.Checked && !SupportInPlacementCheckbox.Checked);

            TankRankDropdown.Enabled = (IsOpenQueueMode && !TankInPlacementCheckbox.Checked || (TankRankEnabledCheckBox.Checked && !TankInPlacementCheckbox.Checked));
            DamageRankDropdown.Enabled = (!IsOpenQueueMode && DamageRankEnabledCheckBox.Checked && !DamageInPlacementCheckbox.Checked);
            SupportRankDropdown.Enabled = (!IsOpenQueueMode && SupportRankEnabledCheckBox.Checked && !SupportInPlacementCheckbox.Checked);

            TankInPlacementCheckbox.Enabled = (IsOpenQueueMode || TankRankEnabledCheckBox.Checked);
			DamageInPlacementCheckbox.Enabled = (!IsOpenQueueMode && DamageRankEnabledCheckBox.Checked);
			SupportInPlacementCheckbox.Enabled = (!IsOpenQueueMode && SupportRankEnabledCheckBox.Checked);

			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}
	}
}
