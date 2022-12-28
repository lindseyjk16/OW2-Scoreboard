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

namespace OW2ScoreboardController
{
	public partial class SettingsForm : Form
	{
		// Relative path to logo image (no extension)
		private static string LogoFileNameWithoutExtension = "./user/Logo";

		public SettingsForm()
		{
			InitializeComponent();
		}

		private void SettingsForm_Load( object sender, EventArgs e )
		{
            // Disable maximize button
            this.MaximizeBox = false;

			// Read config and set values
			ConfigManager.Config Config = ConfigManager.Load();
			NameTextBox.Text = Config.Name;
			LogoPictureBox.ImageLocation = Config.LogoImageFilePath;
			MainColorBox.BackColor = ColorTranslator.FromHtml( Config.MainColorHtml );
			SubColorBox.BackColor = ColorTranslator.FromHtml( Config.SubColorHtml );
			FontColorBox.BackColor = ColorTranslator.FromHtml( Config.FontColorHtml );
			VolumeTrackbar.Value = Config.SoundVolume;
			ScoreBoardSizeTrackbar.Value = Config.ScoreBoardSize;
			if( Config.ScoreBoardPosition == "top" )
			{
				ScoreBoardPositionRadio_Top.Checked = true;
			}
			else
			{
				ScoreBoardPositionRadio_Bottom.Checked = true;

			}
			EnableProductionCheckbox.Checked = Config.EnableProduction;
			SetEnabledRegardingProductionControls( EnableProductionCheckbox.Checked );

			KeysConverter kc = new KeysConverter();
			if( Config.WinHotkey.KeyCode != Keys.None ) WinHotkeyCombobox.Text = kc.ConvertToString( Config.WinHotkey.KeyCode );
			if( Config.WinHotkey.ModKey.HasFlag( MOD_KEY.CONTROL ) ) WinHotkeyModCheckbox_Ctrl.Checked = true;
			if( Config.WinHotkey.ModKey.HasFlag( MOD_KEY.ALT ) ) WinHotkeyModCheckbox_Alt.Checked = true;
			if( Config.WinHotkey.ModKey.HasFlag( MOD_KEY.SHIFT ) ) WinHotkeyModCheckbox_Shift.Checked = true;
			if( Config.LoseHotkey.KeyCode != Keys.None ) LoseHotkeyCombobox.Text = kc.ConvertToString( Config.LoseHotkey.KeyCode );
			if( Config.LoseHotkey.ModKey.HasFlag( MOD_KEY.CONTROL ) ) LoseHotkeyModCheckbox_Ctrl.Checked = true;
			if( Config.LoseHotkey.ModKey.HasFlag( MOD_KEY.ALT ) ) LoseHotkeyModCheckbox_Alt.Checked = true;
			if( Config.LoseHotkey.ModKey.HasFlag( MOD_KEY.SHIFT ) ) LoseHotkeyModCheckbox_Shift.Checked = true;
			if( Config.DrawHotkey.KeyCode != Keys.None ) DrawHotkeyCombobox.Text = kc.ConvertToString( Config.DrawHotkey.KeyCode );
			if( Config.DrawHotkey.ModKey.HasFlag( MOD_KEY.CONTROL ) ) DrawHotkeyModCheckbox_Ctrl.Checked = true;
			if( Config.DrawHotkey.ModKey.HasFlag( MOD_KEY.ALT ) ) DrawHotkeyModCheckbox_Alt.Checked = true;
			if( Config.DrawHotkey.ModKey.HasFlag( MOD_KEY.SHIFT ) ) DrawHotkeyModCheckbox_Shift.Checked = true;

			// Set language
			SetLanguage();
		}

		private void LogoPictureBox_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Image File|*.bmp;*.png;*.jpg;*.jpeg;*.gif";

			if( ofd.ShowDialog() == DialogResult.OK )
			{
				LogoPictureBox.ImageLocation = ofd.FileName;
			}
		}

		private void ColorSelect( object sender, EventArgs e )
		{
			ColorDialog cd = new ColorDialog();
			PictureBox Sender = (PictureBox)sender;

			// Show the dialog
			if( cd.ShowDialog() == DialogResult.OK )
			{
				// Get selected colour
				Sender.BackColor = cd.Color;
			}
		}

		private void VolumeTrackbar_Scroll( object sender, EventArgs e )
		{
			Tooltip.SetToolTip( VolumeTrackbar, VolumeTrackbar.Value.ToString() );
		}

		private void ScoreBoardSizeTrackbar_Scroll( object sender, EventArgs e )
		{
			Tooltip.SetToolTip( ScoreBoardSizeTrackbar, ScoreBoardSizeTrackbar.Value.ToString() + "%" );
		}

		/// <summary>
		/// Clicked the OK button
		/// </summary>
		private void OKButton_Click( object sender, EventArgs e )
		{
			// Confirm the hotkeys are valid
			if( !ValidateHotkeys() )
			{
                // Get language struct according to settings
                // NOTE: Only English is currently supported
                LanguageManager.Language Language = LanguageManager.Get();

                string WarningMesage = Language.InvalidHotkeyWarningMessage;
				string WarningTitle = Language.InvalidHotkeyWarningTitle;

				DialogResult result = MessageBox.Show
				(
					WarningMesage,
					WarningTitle,
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning,
					MessageBoxDefaultButton.Button2
				);

				if( result == DialogResult.No )
				{
					return;
				}
			}

			// Convert the display position of the scoreboard to a string
			string ScoreBoardPosition = ScoreBoardPositionRadio_Top.Checked ? "top" : "bottom";

			// If the logo image is selected, copy it into the application folder
			string Extension = Path.GetExtension( LogoPictureBox.ImageLocation );
			if( LogoPictureBox.ImageLocation != LogoFileNameWithoutExtension + Extension && LogoPictureBox.ImageLocation != null && LogoPictureBox.ImageLocation != string.Empty )
			{
				if( !Directory.Exists( Path.GetDirectoryName( LogoFileNameWithoutExtension ) ) )
				{
					Directory.CreateDirectory( Path.GetDirectoryName( LogoFileNameWithoutExtension ) );
				}
				File.Copy( LogoPictureBox.ImageLocation, LogoFileNameWithoutExtension + Extension, true );
				LogoPictureBox.ImageLocation = LogoFileNameWithoutExtension + Extension;
			}

			// Create hotkey data
			KeysConverter kc = new KeysConverter();
			ConfigManager.HotkeyData WinHotkey = new ConfigManager.HotkeyData();
			if( !string.IsNullOrEmpty( WinHotkeyCombobox.Text ) ) WinHotkey.KeyCode = (Keys)kc.ConvertFromString( WinHotkeyCombobox.Text );
			if( WinHotkeyModCheckbox_Ctrl.Checked ) WinHotkey.ModKey |= MOD_KEY.CONTROL;
			if( WinHotkeyModCheckbox_Alt.Checked ) WinHotkey.ModKey |= MOD_KEY.ALT;
			if( WinHotkeyModCheckbox_Shift.Checked ) WinHotkey.ModKey |= MOD_KEY.SHIFT;

			ConfigManager.HotkeyData LoseHotkey = new ConfigManager.HotkeyData();
			if( !string.IsNullOrEmpty( LoseHotkeyCombobox.Text ) ) LoseHotkey.KeyCode = (Keys)kc.ConvertFromString( LoseHotkeyCombobox.Text );
			if( LoseHotkeyModCheckbox_Ctrl.Checked ) LoseHotkey.ModKey |= MOD_KEY.CONTROL;
			if( LoseHotkeyModCheckbox_Alt.Checked ) LoseHotkey.ModKey |= MOD_KEY.ALT;
			if( LoseHotkeyModCheckbox_Shift.Checked ) LoseHotkey.ModKey |= MOD_KEY.SHIFT;

			ConfigManager.HotkeyData DrawHotkey = new ConfigManager.HotkeyData();
			if( !string.IsNullOrEmpty( DrawHotkeyCombobox.Text ) ) DrawHotkey.KeyCode = (Keys)kc.ConvertFromString( DrawHotkeyCombobox.Text );
			if( DrawHotkeyModCheckbox_Ctrl.Checked ) DrawHotkey.ModKey |= MOD_KEY.CONTROL;
			if( DrawHotkeyModCheckbox_Alt.Checked ) DrawHotkey.ModKey |= MOD_KEY.ALT;
			if( DrawHotkeyModCheckbox_Shift.Checked ) DrawHotkey.ModKey |= MOD_KEY.SHIFT;

			// Create a config
			ConfigManager.Config Config = new ConfigManager.Config
			(
				NameTextBox.Text,
				LogoPictureBox.ImageLocation,
				MainColorBox.BackColor,
				SubColorBox.BackColor,
				FontColorBox.BackColor,
				VolumeTrackbar.Value,
				ScoreBoardSizeTrackbar.Value,
				ScoreBoardPosition,
				WinHotkey,
				LoseHotkey,
				DrawHotkey,
				EnableProductionCheckbox.Checked
			);

			// Save
			ConfigManager.Save( Config );

			// Close form
			this.Close();
		}

		private void CancelButton_Click( object sender, EventArgs e )
		{
			// Close form
			this.Close();
		}

		private void WinHotkeyClearButton_Click( object sender, EventArgs e )
		{
			WinHotkeyCombobox.SelectedIndex = -1;
			WinHotkeyModCheckbox_Ctrl.Checked = false;
			WinHotkeyModCheckbox_Alt.Checked = false;
			WinHotkeyModCheckbox_Shift.Checked = false;
		}

		private void LoseHotkeyClearButton_Click( object sender, EventArgs e )
		{
			LoseHotkeyCombobox.SelectedIndex = -1;
			LoseHotkeyModCheckbox_Ctrl.Checked = false;
			LoseHotkeyModCheckbox_Alt.Checked = false;
			LoseHotkeyModCheckbox_Shift.Checked = false;
		}

		private void DrawHotkeyClearButton_Click( object sender, EventArgs e )
		{
			DrawHotkeyCombobox.SelectedIndex = -1;
			DrawHotkeyModCheckbox_Ctrl.Checked = false;
			DrawHotkeyModCheckbox_Alt.Checked = false;
			DrawHotkeyModCheckbox_Shift.Checked = false;
		}

		private void EnableProductionCheckbox_CheckedChanged( object sender, EventArgs e )
		{
			SetEnabledRegardingProductionControls( EnableProductionCheckbox.Checked );
		}

		/// <summary>
		/// Checks if the hotkey settings are valid.
		/// </summary>
		/// <returns>True if set correctly, false otherwise.</returns>
		private bool ValidateHotkeys()
		{
			bool ret = true;
			if( WinHotkeyCombobox.Text == "F12" && !WinHotkeyModCheckbox_Alt.Checked && !WinHotkeyModCheckbox_Ctrl.Checked && !WinHotkeyModCheckbox_Shift.Checked ||
				LoseHotkeyCombobox.Text == "F12" && !LoseHotkeyModCheckbox_Alt.Checked && !LoseHotkeyModCheckbox_Ctrl.Checked && !LoseHotkeyModCheckbox_Shift.Checked ||
				DrawHotkeyCombobox.Text == "F12" && !DrawHotkeyModCheckbox_Alt.Checked && !DrawHotkeyModCheckbox_Ctrl.Checked && !DrawHotkeyModCheckbox_Shift.Checked )
			{
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// Enable or disable the win/loss animation control settings.
		/// </summary>
		private void SetEnabledRegardingProductionControls( bool Enabled )
		{
			Control[] Controls = { NameTextBox, LogoPictureBox, MainColorBox, SubColorBox, FontColorBox, VolumeTrackbar };
			foreach( var Control in Controls )
			{
				Control.Enabled = Enabled;
			}
		}

        /// <summary>
        /// Sets language.
        /// <para>NOTE: Only English is currently supported.</para>
        /// </summary>
        private void SetLanguage()
		{
            // Get language struct according to settings
            LanguageManager.Language Language = LanguageManager.Get();

			// Set localization
			this.Text = Language.settingsForm.WindowTitle;
			SettingsTabControl.TabPages[0].Text = Language.settingsForm.TabPage_General;
			ProductionGroup.Text = Language.settingsForm.ProductionGroup;
			EnableProductionCheckbox.Text = Language.settingsForm.EnableProductionCheckbox;
			NameLabel.Text = Language.settingsForm.NameLabel;
			LogoLabel.Text = Language.settingsForm.LogoLabel;
			MainColorLabel.Text = Language.settingsForm.MainColorLabel;
			SubColorLabel.Text = Language.settingsForm.SubColorLabel;
			FontColorLabel.Text = Language.settingsForm.FontColorLabel;
			VolumeLabel.Text = Language.settingsForm.VolumeLabel;
			ScoreBoardGroup.Text = Language.settingsForm.ScoreBoardGroup;
			ScoreBoardSizeLabel.Text = Language.settingsForm.ScoreBoardSizeLabel;
			ScoreBoardPositionLabel.Text = Language.settingsForm.ScoreBoardPositionLabel;
			ScoreBoardPositionRadio_Top.Text = Language.settingsForm.ScoreBoardPositionRadio_Top;
			ScoreBoardPositionRadio_Bottom.Text = Language.settingsForm.ScoreBoardPositionRadio_Bottom;
			OKButton.Text = Language.settingsForm.OKButton;
			CancelButton.Text = Language.settingsForm.CancelButton;
			SettingsTabControl.TabPages[1].Text = Language.settingsForm.TabPage_Hotkey;
			WinHotkeyClearButton.Text = Language.settingsForm.HotkeyClearButton;
			LoseHotkeyClearButton.Text = Language.settingsForm.HotkeyClearButton;
			DrawHotkeyClearButton.Text = Language.settingsForm.HotkeyClearButton;
		}
	}
}
