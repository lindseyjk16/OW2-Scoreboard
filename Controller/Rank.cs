using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OW2ScoreboardController
{
    /// <summary>
    /// Overwatch 2 skill division.
    /// </summary>
    internal enum RankDivision
    {
        Bronze,
        Silver,
        Gold,
        Platinum,
        Diamond,
        Master,
        Grandmaster
    }

    /// <summary>
    /// Tier within an Overwatch 2 skill divison.
    /// </summary>
    internal enum RankTier
    {
        One = 1,
        Two,
        Three,
        Four,
        Five
    }

    /// <summary>
    /// Enum for a combined Overwatch 2 skill division and tier.
    /// </summary>
    internal abstract class RankEnum : IComparable
    {
        /// <summary>
        /// This rank's skill division.
        /// </summary>
        public RankDivision Division { get; protected set; }

        /// <summary>
        /// This rank's tier within its skill division.
        /// </summary>
        public RankTier Tier { get; protected set; }

        /// <summary>
        /// Overall order of the Overwatch 2 rank, from Bronze 5 being the lowest to GM 1 being the highest.
        /// A combination of <see cref="RankDivision"/> and <see cref="RankTier"/> enums.
        /// </summary>
        public int Value
        { 
            get
            {
                return ((int)Division * NumberOfTiers) + Math.Abs(NumberOfTiers - (int)Tier);
            }
        }

        /// <summary>
        /// Total number of Overwatch 2 skill divisons.
        /// </summary>
        public static int NumberOfDivisions
        {
            get { return Enum.GetValues(typeof(RankDivision)).Length; }
        }

        /// <summary>
        /// Total number of tiers within Overwatch 2 skill divisons.
        /// </summary>
        public static int NumberOfTiers
        {
            get { return Enum.GetValues(typeof(RankTier)).Length; }
        }
        
        /// <summary>
        /// The name of this rank.
        /// </summary>
        public string RankName
        {
            get { return $"{Division} {(int)Tier}"; }
        }

        /// <summary>
        /// Constructor using <see cref="RankDivision"/> and <see cref="RankTier"/> enums.
        /// </summary>
        protected RankEnum(RankDivision division, RankTier tier)
        {
            Division = division;
            Tier = tier;
        }

        /// <summary>
        /// Constructor using <see cref="RankDivision"/> and <see cref="RankTier"/> enum values.
        /// </summary>
        protected RankEnum(int division, int tier)
        {
            if (!Enum.IsDefined(typeof(RankDivision), division) || !Enum.IsDefined(typeof(RankTier), tier))
                throw new InvalidCastException("Invalid rank value"); 
            
            Division = (RankDivision)division;
            Tier = (RankTier)tier;
        }

        /// <summary>
        /// Constructor using <see cref="RankDivision"/>'s string representation and the <see cref="RankTier"/> enum values.
        /// </summary>
        protected RankEnum(string division, int tier)
        {
            if (!Enum.IsDefined(typeof(RankTier), tier))
                throw new InvalidCastException("Invalid tier value");
            
            try
            {
                Division = (RankDivision)Enum.Parse(typeof(RankDivision), division);
                Tier = (RankTier)tier;
            }
            catch
            {
                throw new InvalidCastException("Invalid division string");
            }
        }

        /// <summary>
        /// Constructor using combined Rank enum value, corresponding to <see cref="Value"/>.
        /// </summary>
        protected RankEnum(int value)
        {
            int tier = value % NumberOfTiers;
            int division = (value - tier) / NumberOfTiers;

            if (!Enum.IsDefined(typeof(RankDivision), division) || !Enum.IsDefined(typeof(RankTier), tier))
                throw new InvalidCastException("Invalid rank value");

            Division = (RankDivision)division;
            Tier = (RankTier)tier;
        }

        public override string ToString()
        {
            return RankName;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RankEnum))
                return false;

            return Value.Equals(((RankEnum)obj).Value);
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = hash * 23 + Value.GetHashCode();
            return hash;
        }

        public int CompareTo(object other)
        {
            if (other == null)
                return 1;

            if (other is RankEnum rank)
            {
                return Value.CompareTo(rank.Value);
            }
            else
            {
                throw new ArgumentException("Object is not a Rank");
            }
        }
    }

    /// <summary>
    /// An Overwatch 2 rank.
    /// </summary>
    internal class Rank : RankEnum
    {
        /// <summary>
        /// Constructor using <see cref="RankDivision"/> and <see cref="RankTier"/> enums.
        /// </summary>
        public Rank(RankDivision division, RankTier tier) : base(division, tier) { }

        /// <summary>
        /// Constructor using <see cref="RankDivision"/> and <see cref="RankTier"/> enum values.
        /// </summary>
        public Rank(int tier, int division) : base(division, tier) { }

        /// <summary>
        /// Constructor using <see cref="RankDivision"/>'s string representation and the <see cref="RankTier"/> enum values.
        /// </summary>
        public Rank(string division, int tier) : base(division, tier) { }

        /// <summary>
        /// Constructor using combined Rank enum value, corresponding to <see cref="RankEnum.Value"/>.
        /// </summary>
        public Rank(int value) : base(value) { }
    }
}
