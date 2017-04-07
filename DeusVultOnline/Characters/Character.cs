using System;
using DeusVultOnline.Controllers;

namespace DeusVultOnline.Characters
{
    public class Character : KeyedDocument<Character>
    {
        #region privateAttr
        private int _genSize;
        private int _genIntelligence;
        private int _genBeauty;
        private int _genStrength;
        private int _genToughness;
        private int _genMagic;

        #endregion

        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }

        public Religion Religion { get; protected set; }
        protected int ReligionLevel { get; set; }
        protected string ReligionRank => ReligionLevel==0?"":Religion.RankName[ReligionLevel];
        protected int ReligionSpellLevel => ReligionLevel == 0 ? 0 : Religion.SpellLevel[ReligionLevel];

        public void SetReligion(Religion rel, int lvl)
        {
            Religion = rel;
            ReligionLevel = lvl;

            var faithAttr = rel.Faith[lvl];
            foreach (var i in faithAttr)
            {
                var attribute = GetType().GetProperty(i.Key).GetValue(this) as Attribute;
                if (attribute != null)
                    attribute.Faith = i.Value;
            }

        }

        #region InitGenetics
        public int GenSize
        {
            get { return _genSize; }
            set
            {
                Diplomacy.Gen += value - _genSize;
                _genSize = value;
            }
        }

        public int GenIntelligence
        {
            get { return _genIntelligence; }
            set
            {
                Arts.Gen += value - _genIntelligence;
                Learning.Gen += value - _genIntelligence;
                Intrigue.Gen += value - _genIntelligence;
                Stewardship.Gen += value - _genIntelligence;
                _genIntelligence = value;
            }
        }

        public int GenBeauty
        {
            get { return _genBeauty; }
            set
            {
                Attraction.Gen += 2 * (value - _genBeauty);
                Diplomacy.Gen += value - _genBeauty;
                _genBeauty = value;
            }
        }

        public int GenStrength
        {
            get { return _genStrength; }
            set
            {
                Combat.Gen += value - _genStrength;
                Marshall.Gen += value - _genStrength;
                Intrigue.Gen += value - _genStrength;
                _genStrength = value;
            }
        }

        public int GenToughness
        {
            get { return _genToughness; }
            set
            {
                Armor.Gen += value - _genToughness;
                _genToughness = value;
            }
        }

        public int GenMagic
        {
            get { return _genMagic; }
            set
            {
                Magic.Gen += 2 * (value - _genMagic);
                _genMagic = value;
            }
        }
        #endregion

        public enum AttributeType
        {
            Marshall,
            Diplomacy,
            Stewardship,
            Intrigue,
            Learning,
            Arts,
            Magic,
            Attraction,
            Combta
        }

        public AttributeType Focus { get; set;} 

        //Attributes
        public Attribute Marshall { get; set;} 
        public Attribute Diplomacy { get; set;} 
        public Attribute Stewardship { get; set;} 
        public Attribute Intrigue { get; set; }
        public Attribute Learning { get; set; }
        public Attribute Arts { get; set; }
        public Attribute Magic { get; set; }
        public Attribute Attraction { get; set; }
        public Attribute Combat { get; set; }
        //CombatAttributes
        public Attribute Health { get; set; }
        public Attribute Attack { get; set; }
        public Attribute Dualwield { get; set; }
        public Attribute Technique { get; set; }
        public Attribute Armor { get; set; }

    }

}
