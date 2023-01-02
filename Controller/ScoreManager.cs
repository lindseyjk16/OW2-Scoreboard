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
			public bool IsTankRankEnabled;
			public bool IsDamageRankEnabled;
			public bool IsSupportRankEnabled;
			public string TankRankDivision;
			public int TankRankTier;
			public string DamageRankDivision;
			public int DamageRankTier;
			public string SupportRankDivision;
			public int SupportRankTier;
            public bool IsTankInPlacement;
			public bool IsDamageInPlacement;
			public bool IsSupportInPlacement;
			public bool IsOpenQueueMode;
			public string TimeStamp;

			/// <summary>
            /// Constructor.
            /// </summary>
            public Score(int Wins, int Loses, int Draws, bool IsTankRankEnabled, bool IsDamageRankEnabled, bool IsSupportRankEnabled, string TankRankDivision, int TankRankTier, string DamageRankDivision, int DamageRankTier, string SupportRankDivision, int SupportRankTier, bool IsTankInPlacement, bool IsDamageInPlacement, bool IsSupportInPlacement, bool IsOpenQueueMode)
            {
                this.Wins = Wins;
                this.Loses = Loses;
                this.Draws = Draws;
                this.IsTankRankEnabled = IsTankRankEnabled;
                this.IsDamageRankEnabled = IsDamageRankEnabled;
                this.IsSupportRankEnabled = IsSupportRankEnabled;
                this.IsTankInPlacement = IsTankInPlacement;
                this.IsDamageInPlacement = IsDamageInPlacement;
                this.IsSupportInPlacement = IsSupportInPlacement;
				this.TankRankDivision = TankRankDivision;
                this.TankRankTier = TankRankTier;
				this.DamageRankDivision = DamageRankDivision;
                this.DamageRankTier = DamageRankTier;
				this.SupportRankDivision = SupportRankDivision;
                this.SupportRankTier = SupportRankTier;
                this.IsOpenQueueMode = IsOpenQueueMode;
            }

            /// <summary>
            /// Returns the default Score.
            /// </summary>
            public static Score Default()
			{
                return new Score(0, 0, 0, true, true, true, "Bronze", 5, "Bronze", 5, "Bronze", 5, false, false, false, false);
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
