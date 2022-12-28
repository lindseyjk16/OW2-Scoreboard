﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


namespace OW2ScoreboardController
{
	/// <summary>
	/// Registers global hotkeys.
	/// Always dispose after use.
	/// </summary>
	public class HotKey : IDisposable
	{
		HotKeyForm form;
		/// <summary>
		/// Occurs when a hotkey is pressed.
		/// </summary>
		public event EventHandler HotKeyPush;

		/// <summary>
		/// Initialize a hotkey.
		/// Always dispose after use.
		/// </summary>
		/// <param name="modKey">Modifier key.</param>
		/// <param name="key">Keycode.</param>
		public HotKey( MOD_KEY modKey, Keys key )
		{
			form = new HotKeyForm( modKey, key, raiseHotKeyPush );
		}

		private void raiseHotKeyPush()
		{
			if( HotKeyPush != null )
			{
				HotKeyPush( this, EventArgs.Empty );
			}
		}

		public void Dispose()
		{
			form.Dispose();
		}

		private class HotKeyForm : Form
		{
			[DllImport( "user32.dll" )]
			extern static int RegisterHotKey( IntPtr HWnd, int ID, MOD_KEY MOD_KEY, Keys KEY );

			[DllImport( "user32.dll" )]
			extern static int UnregisterHotKey( IntPtr HWnd, int ID );

			const int WM_HOTKEY = 0x0312;
			int id;
			ThreadStart proc;

			public HotKeyForm( MOD_KEY modKey, Keys key, ThreadStart proc )
			{
				this.proc = proc;
				for( int i = 0x0000; i <= 0xbfff; i++ )
				{
					if( RegisterHotKey( this.Handle, i, modKey, key ) != 0 )
					{
						id = i;
						break;
					}
				}
			}

			protected override void WndProc( ref Message m )
			{
				base.WndProc( ref m );

				if( m.Msg == WM_HOTKEY )
				{
					if( (int)m.WParam == id )
					{
						proc();
					}
				}
			}

			protected override void Dispose( bool disposing )
			{
				UnregisterHotKey( this.Handle, id );
				base.Dispose( disposing );
			}
		}
	}

    /// <summary>
    /// Modifier key specified when initializing the HotKey class.
    /// </summary>
    [Flags]
	public enum MOD_KEY : int
	{
		NONE = 0x0000,
		ALT = 0x0001,
		CONTROL = 0x0002,
		SHIFT = 0x0004,
	}
}
