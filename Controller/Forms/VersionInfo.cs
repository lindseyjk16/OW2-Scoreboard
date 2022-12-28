using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OW2ScoreboardController
{
	public partial class VersionInfoForm : Form
	{
		public VersionInfoForm()
		{
			InitializeComponent();
		}

		private void VersionInfoForm_Load( object sender, EventArgs e )
		{
            // Disable maximize button
            this.MaximizeBox = false;

			// Set language
			SetLanguage();
		}

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			System.Diagnostics.Process.Start("https://github.com/lindseyjk16/OW2-Scoreboard");
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.Close();
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
            this.Text = Language.versionInfo.WindowTitle;
			this.VersionNumber.Text = Language.versionInfo.VersionNumber;
		}

	}
}
