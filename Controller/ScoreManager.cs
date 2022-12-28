using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OW2ScoreboardController
{
	/// <summary>
	/// Manages saving and loading scores to/from file.
	/// </summary>
	public static class ScoreManager
	{
		// Score file path
		private static string ScoreFilePath = "./score.json";

		/// <summary>
		/// Score class.
		/// </summary>
		public class Score
		{
			public int Wins;
			public int Loses;
			public int Draws;
			public bool IsTankStartingRateEnabled;
			public bool IsDamageStartingRateEnabled;
			public bool IsSupportStartingRateEnabled;
			public int TankStartingRate;
			public int DamageStartingRate;
			public int SupportStartingRate;
			public bool IsTankInPlacement;
			public bool IsDamageInPlacement;
			public bool IsSupportInPlacement;
			public bool IsOpenQueueMode;
			public string TimeStamp;

			/// <summary>
			/// Constructor.
			/// </summary>
			public Score( int Wins, int Loses, int Draws, bool IsTankStartingRateEnabled, bool IsDamageStartingRateEnabled, bool IsSupportStartingRateEnabled, int TankStartingRate, int DamageStartingRate, int SupportStartingRate, bool IsTankInPlacement, bool IsDamageInPlacement, bool IsSupportInPlacement, bool IsOpenQueueMode)
			{
				this.Wins = Wins;
				this.Loses = Loses;
				this.Draws = Draws;
				this.IsTankStartingRateEnabled = IsTankStartingRateEnabled;
				this.IsDamageStartingRateEnabled = IsDamageStartingRateEnabled;
				this.IsSupportStartingRateEnabled = IsSupportStartingRateEnabled;
				this.IsTankInPlacement = IsTankInPlacement;
				this.IsDamageInPlacement = IsDamageInPlacement;
				this.IsSupportInPlacement = IsSupportInPlacement;
				this.TankStartingRate = TankStartingRate;
				this.DamageStartingRate = DamageStartingRate;
				this.SupportStartingRate = SupportStartingRate;
				this.IsOpenQueueMode = IsOpenQueueMode;
			}

			/// <summary>
			/// Returns the default Score.
			/// </summary>
			public static Score Default()
			{
				return new Score( 0, 0, 0, true, true, true, 1, 1, 1, false, false, false, false );
			}
		}

		/// <summary>
		/// Save Score to Json file.
		/// </summary>
		public static void Save( Score Score )
		{
			Score.TimeStamp = System.DateTime.Now.ToString();

			string ScoreJson = JsonConvert.SerializeObject( Score, Formatting.Indented );
			FileStream fs = new FileStream( ScoreFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite );
			StreamWriter sw = new StreamWriter( fs );
			sw.Write( ScoreJson );
			sw.Close();
			fs.Close();
		}

		/// <summary>
		/// Read Score from Json file.
		/// </summary>
		public static Score Load()
		{
			Score ret;

			// Create default if score.json does not exist
			if( !File.Exists( ScoreFilePath ) )
			{
				Score DefaultScore = Score.Default();
				string DefaultScoreJson = JsonConvert.SerializeObject( DefaultScore, Formatting.Indented );

				FileStream fs = new FileStream( ScoreFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite );
				StreamWriter sw = new StreamWriter( fs );
				sw.Write( DefaultScoreJson );
				sw.Close();
				fs.Close();

				ret = DefaultScore;
			}
			// Load score.json if it exists
			else
			{
				StreamReader sr = new StreamReader( ScoreFilePath, Encoding.UTF8 );
				string ScoreJson = sr.ReadToEnd();
				sr.Close();

				ret = JsonConvert.DeserializeObject<Score>( ScoreJson );
			}

			return ret;
		}
	}
}
