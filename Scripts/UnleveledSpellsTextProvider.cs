using DaggerfallConnect.Arena2;
using DaggerfallWorkshop.Utility;

namespace UnleveledSpellsMod
{ 
    public class UnleveledSpellsTextProvider : FallbackTextProvider
    {
        public UnleveledSpellsTextProvider(ITextProvider fallback)
            : base(fallback)
        {

        }

        public override TextFile.Token[] GetRSCTokens(int id)
        {
            switch(id)
            {
                case 1202: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Paralyze",
                    "Alteration",
                    "Duration: %bdr round(s)",
                    "Chance: %bch%",
                    "\"Causes target to be paralyzed.",
                    "Chance of success is %bch%.",
                    "If successful, target will be paralyzed",
                    "for %bdr round(s), unless target is cured.\""
                    );

                case 1204: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Continuous Damage -- Health",
                    "Destruction",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's health to be damaged.",
                    "Target will lose %1bm to %2bm points of health",
                    "every round, for %bdr rounds.\""
                    );

                case 1205: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Continuous Damage -- Fatigue",
                    "Destruction",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Fatigue to be damaged.",
                    "Target will lose %1bm to %2bm points of Fatigue every round,",
                    "for %bdr rounds.\""
                    );

                case 1206: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Continuous Damage -- Spell Points",
                    "Destruction",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Spell Points to be damaged.",
                    "Target will lose %1bm to %2bm Spell Points",
                    "every round, for %bdr rounds.\""
                    );

                case 1207: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Create Item",
                    "Mysticism",
                    "Duration: %bdr round(s)",
                    "\"Creates one useful item of the caster's choosing.",
                    "Item lasts for %bdr round(s).\""
                    );

                case 1209: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Cure -- Disease",
                    "Restoration",
                    "Chance: %bch%",
                    "\"Cures target of disease.",
                    "Chance of success is %bch%.\""
                    );

                case 1210: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Cure -- Poison",
                    "Restoration",
                    "Chance: %bch%",
                    "\"Cures target of poison.",
                    "Chance of success is %bch%.\""
                    );

                case 1211: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Cure -- Paralysis",
                    "Restoration",
                    "Chance: %bch%",
                    "\"Cures target of paralysis.",
                    "Chance of success is %bch%.\""
                    );

                case 1212: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Damage -- Health",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Health to be damaged.",
                    "Target will lose %1bm to %2bm points of Health.\""
                    );

                case 1213: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Damage -- Fatigue",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Fatigue to be damaged.",
                    "Target will lose %1bm to %2bm points of Fatigue.\""
                    );

                case 1214: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Damage -- Spell Points",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Spell Points to be damaged.",
                    "Target will lose %1bm to %2bm Spell Points.\""
                    );

                case 1215: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Disintegrate",
                    "Destruction",
                    "Chance: %bch%",
                    "\"Causes target to disintegrate.",
                    "Chance of success is %bch%.\""
                    );

                case 1216: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Dispel -- Magic",
                    "Mysticism",
                    "Chance: %bch%",
                    "\"Causes magic to be dispelled, removing",
                    "all active effects on the target.",
                    "Chance of success is %bch%.\""
                    );

                case 1217: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Dispel -- Undead",
                    "Mysticism",
                    "Chance: %bch%",
                    "\"Causes undead creatures to be dispelled.",
                    "Chance of success is %bch%.\""
                    );

                case 1218: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Dispel -- Daedra",
                    "Mysticism",
                    "Chance: %bch%",
                    "\"Causes Daedra to be dispelled.",
                    "Chance of success is %bch%.\""
                    );

                case 1219: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Strength",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Strength to be drained.",
                    "Target will lose %1bm to %2bm points of Strength,",
                    "until healed.\""
                    );

                case 1220: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Intelligence",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Intelligence to be drained.",
                    "Target will lose %1bm to %2bm points of Intelligence,",
                    "until healed.\""
                    );

                case 1221: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Willpower",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Willpower to be drained.",
                    "Target will lose %1bm to %2bm points of Willpower,",
                    "until healed.\""
                    );

                case 1222: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Agility",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Agility to be drained.",
                    "Target will lose %1bm to %2bm points of Agility,",
                    "until healed.\""
                    );

                case 1223: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Endurance",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Endurance to be drained.",
                    "Target will lose %1bm to %2bm points of Endurance,",
                    "until healed.\""
                    );

                case 1224: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Speed",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Speed to be drained.",
                    "Target will lose %1bm to %2bm points of Speed,",
                    "until healed.\""
                    );

                case 1225: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Personality",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Personality to be drained.",
                    "Target will lose %1bm to %2bm points of Personality,",
                    "until healed.\""
                    );

                case 1226: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Luck",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Causes target's Luck to be drained.",
                    "Target will lose %1bm to %2bm points of Luck,",
                    "until healed.\""
                    );

                case 1227: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Elemental Resistance -- Fire",
                    "Alteration",
                    "Duration: %bdr round(s)",
                    "Chance: %bch%",
                    "\"Causes target to be more resistant to fire.",
                    "Spell lasts %bdr round(s).",
                    "Chance of resisting is %bch%.\""
                    );

                case 1228: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Elemental Resistance -- Frost",
                    "Alteration",
                    "Duration: %bdr round(s)",
                    "Chance: %bch%",
                    "\"Causes target to be more resistant to cold.",
                    "Spell lasts %bdr round(s).",
                    "Chance of resisting is %bch%.\""
                    );

                case 1229: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Elemental Resistance -- Poison",
                    "Alteration",
                    "Duration: %bdr round(s)",
                    "Chance: %bch%",
                    "\"Causes target to be more resistant to poison and disease.",
                    "Spell lasts %bdr round(s).",
                    "Chance of resisting is %bch%.\""
                    );

                case 1230: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Elemental Resistance -- Shock",
                    "Alteration",
                    "Duration: %bdr round(s)",
                    "Chance: %bch%",
                    "\"Causes target to be more resistant to shock.",
                    "Spell lasts %bdr round(s).",
                    "Chance of resisting is %bch%.\""
                    );

                case 1231: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Elemental Resistance -- Magic",
                    "Alteration",
                    "Duration: %bdr round(s)",
                    "Chance: %bch%",
                    "\"Causes target to be more resistant to magic.",
                    "Spell lasts %bdr round(s).",
                    "Chance of resisting is %bch%.\""
                    );

                case 1232: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Strength",
                    "Restoration",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Increases target's Strength.",
                    "Target will gain %1bm to %2bm points of Strength.",
                    "Increase lasts %bdr round(s).\""
                    );

                case 1233: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Intelligence",
                    "Restoration",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Increases target's Intelligence.",
                    "Target will gain %1bm to %2bm points of Intelligence.",
                    "Increase lasts %bdr round(s).\""
                    );

                case 1234: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Willpower",
                    "Restoration",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Increases target's Willpower.",
                    "Target will gain %1bm to %2bm points of Willpower.",
                    "Increase lasts %bdr round(s).\""
                    );

                case 1235: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Agility",
                    "Restoration",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Increases target's Agility.",
                    "Target will gain %1bm to %2bm points of Agility.",
                    "Increase lasts %bdr round(s).\""
                    );

                case 1236: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Endurance",
                    "Restoration",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Increases target's Endurance.",
                    "Target will gain %1bm to %2bm points of Endurance.",
                    "Increase lasts %bdr round(s).\""
                    );

                case 1237: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Personality",
                    "Restoration",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Increases target's Personality.",
                    "Target will gain %1bm to %2bm points of Personality.",
                    "Increase lasts %bdr round(s).\""
                    );

                case 1238: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Speed",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Increases target's Speed.",
                    "Target will gain %1bm to %2bm points of Speed.",
                    "Increase lasts %bdr round(s).\""
                    );

                case 1239: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Luck",
                    "Restoration",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Increases target's Luck.",
                    "Target will gain %1bm to %2bm points of Luck.",
                    "Increase lasts %bdr round(s).\""
                    );

                case 1240: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Strength",
                    "Restoration",
                    "Magnitude: %1bm - %2bm",
                    "\"Heals target's Strength.",
                    "Target will heal %1bm to %2bm points of Strength,",
                    "up to normal level.\""
                    );

                case 1241: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Intelligence",
                    "Restoration",
                    "Magnitude: %1bm - %2bm",
                    "\"Heals target's Intelligence.",
                    "Target will heal %1bm to %2bm points of Intelligence,",
                    "up to normal level.\""
                    );

                case 1242: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Willpower",
                    "Restoration",
                    "Magnitude: %1bm - %2bm",
                    "\"Heals target's Willpower.",
                    "Target will heal %1bm to %2bm points of Willpower,",
                    "up to normal level.\""
                    );

                case 1243: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Agility",
                    "Restoration",
                    "Magnitude: %1bm - %2bm",
                    "\"Heals target's Agility.",
                    "Target will heal %1bm to %2bm points of Agility,",
                    "up to normal level.\""
                    );

                case 1244: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Endurance",
                    "Restoration",
                    "Magnitude: %1bm - %2bm",
                    "\"Heals target's Endurance.",
                    "Target will heal %1bm to %2bm points of Endurance,",
                    "up to normal level.\""
                    );

                case 1245: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Personality",
                    "Restoration",
                    "Magnitude: %1bm - %2bm",
                    "\"Heals target's Personality.",
                    "Target will heal %1bm to %2bm points of Personality,",
                    "up to normal level.\""
                    );

                case 1246: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Speed",
                    "Restoration",
                    "Magnitude: %1bm - %2bm",
                    "\"Heals target's Speed.",
                    "Target will heal %1bm to %2bm points of Speed,",
                    "up to normal level.\""
                    );

                case 1247: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Luck",
                    "Restoration",
                    "Magnitude: %1bm - %2bm",
                    "\"Heals target's Luck.",
                    "Target will heal %1bm to %2bm points of Luck,",
                    "up to normal level.\""
                    );

                case 1248: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Health",
                    "Restoration",
                    "Magnitude: %1bm - %2bm",
                    "\"Heals target's Health.",
                    "Target will heal %1bm to %2bm points of Health,",
                    "up to normal level.\""
                    );

                case 1249: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Fatigue",
                    "Restoration",
                    "Magnitude: %1bm - %2bm",
                    "\"Heals target's Fatigue.",
                    "Target will heal %1bm to %2bm points of Fatigue,",
                    "up to normal level.\""
                    );

                case 1250: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Strength",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Transfers target's Strength to caster.",
                    "Target will be drained of %1bm to %2bm points of Strength,",
                    "while the caster is healed for the same amount.\""
                    );

                case 1251: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Intelligence",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Transfers target's Intelligence to caster.",
                    "Target will be drained of %1bm to %2bm points of Intelligence,",
                    "while the caster is healed for the same amount.\""
                    );

                case 1252: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Willpower",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Transfers target's Willpower to caster.",
                    "Target will be drained of %1bm to %2bm points of Willpower,",
                    "while the caster is healed for the same amount.\""
                    );

                case 1253: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Agility",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Transfers target's Agility to caster.",
                    "Target will be drained of %1bm to %2bm points of Agility,",
                    "while the caster is healed for the same amount.\""
                    );

                case 1254: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Endurance",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Transfers target's Endurance to caster.",
                    "Target will be drained of %1bm to %2bm points of Endurance,",
                    "while the caster is healed for the same amount.\""
                    );

                case 1255: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Personality",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Transfers target's Personality to caster.",
                    "Target will be drained of %1bm to %2bm points of Personality,",
                    "while the caster is healed for the same amount.\""
                    );

                case 1256: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Speed",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Transfers target's Speed to caster.",
                    "Target will be drained of %1bm to %2bm points of Speed,",
                    "while the caster is healed for the same amount.\""
                    );

                case 1257: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Luck",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Transfers target's Luck to caster.",
                    "Target will be drained of %1bm to %2bm points of Luck,",
                    "while the caster is healed for the same amount.\""
                    );

                case 1258: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Health",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Transfers target's Health to caster.",
                    "Target will be drained of %1bm to %2bm points of Health,",
                    "while the caster is healed for the same amount.\""
                    );

                case 1259: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Fatigue",
                    "Destruction",
                    "Magnitude: %1bm - %2bm",
                    "\"Transfers target's Fatigue to caster.",
                    "Target will be drained of %1bm to %2bm points of Fatigue,",
                    "while the caster is healed for the same amount.\""
                    );

                case 1260: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Invisibility (Normal)",
                    "Illusion",
                    "Duration: %bdr round(s)",
                    "\"Turns target invisible.",
                    "Target will remain invisible for %bdr round(s).",
                    "If target attacks something (weapon or spell), invisibility is dispelled.\""
                    );

                case 1261: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Invisibility (True)",
                    "Illusion",
                    "Duration: %bdr round(s)",
                    "\"Turns target invisible.",
                    "Target will remain invisible for %bdr round(s).",
                    "Even if target attacks something (weapon or spell),",
                    "target will still remain invisible.\""
                    );

                case 1262: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Levitate",
                    "Thaumaturgy",
                    "Duration: %bdr round(s)",
                    "\"Target is able to float above the ground.",
                    "Target will levitate for %bdr round(s).\""
                    );

                case 1263: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Light",
                    "Illusion",
                    "Duration: %bdr round(s)",
                    "\"Bright light source created around target.",
                    "Light will remain for %bdr round(s).\""
                    );

                case 1264: return UnleveledSpells.Instance.UnleveledOpenAndLock
                        ? CreateTokens(TextFile.Formatting.JustifyCenter,
                        "Lock",
                        "Mysticism",
                        "Magnitude: %1bm - %2bm",
                        "\"Locks door to a lock-level between %1bm and %2bm.",
                        "Spell is first cast on the user, and then the effect",
                        "must be applied on an open or closed unlocked door.\""
                        )
                        : CreateTokens(TextFile.Formatting.JustifyCenter,
                        "Lock",
                        "Mysticism",
                        "Chance: %bch%",
                        "\"Locks door to a lock-level equal to the caster's level.",
                        "Chance of success is %bch%.",
                        "Spell is first cast on the user, and then the effect",
                        "must be applied on an open or closed unlocked door.\""
                        );

                case 1265: return UnleveledSpells.Instance.UnleveledOpenAndLock
                        ? CreateTokens(TextFile.Formatting.JustifyCenter,
                        "Open",
                        "Mysticism",
                        "Magnitude: %1bm - %2bm",
                        "\"Opens door with lock-level up to a value between %1bm and %2bm.\""
                        )
                        : CreateTokens(TextFile.Formatting.JustifyCenter,
                        "Open",
                        "Mysticism",
                        "Chance: %bch%",
                        "\"Opens door with lock-level equal to or less than",
                        "the caster's level. Chance of success is %bch%.\""
                        );

                case 1266: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Regeneration",
                    "Restoration",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Regenerates target's Health. Target will gain %1bm to %2bm",
                    "points of Health. Increases continue for %bdr round(s).\""
                    );

                case 1267: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Silence",
                    "Mysticism",
                    "Duration: %bdr round(s)",
                    "Chance: %bch%",
                    "\"Silences target, making casting spells impossible.",
                    "Chance of success is %bch%. Silence lasts %bdr round(s).\""
                    );

                case 1268: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Spell Absorption",
                    "Restoration",
                    "Duration: %bdr round(s)",
                    "Chance: %bch%",
                    "\"Target is able to absorb incoming spells, adding their",
                    "energy to their own store. Chance of success is %bch%.",
                    "Absorption lasts %bdr round(s). If the store is too full,",
                    "the effect always fails.\""
                    );

                case 1269: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Spell Reflection",
                    "Thaumaturgy",
                    "Duration: %bdr round(s)",
                    "Chance: %bch%",
                    "\"Target is able to reflect incoming spells back at its caster.",
                    "Chance of success is %bch%. Reflection lasts %bdr round(s).",
                    "Spells can only be reflected once.\""
                    );

                case 1270: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Spell Resistance",
                    "Thaumaturgy",
                    "Duration: %bdr round(s)",
                    "Chance: %bch%",
                    "\"Target is able to resist incoming spells.",
                    "Chance of success is %bch%. Resistance lasts %bdr round(s).",
                    "Will not resist spells cast on self.\""
                    );

                case 1271: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Chameleon (Normal)",
                    "Illusion",
                    "Duration: %bdr round(s)",
                    "\"Changes the color of the target and makes them difficult to see.",
                    "Target will remain so for %bdr round(s). Target has 8% chance to be detected.",
                    "If target attacks something (weapon or spell),",
                    "the chameleon effect is aborted.\""
                    );

                case 1272: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Chameleon (True)",
                    "Illusion",
                    "Duration: %bdr round(s)",
                    "\"Changes the color of the target and makes them difficult to see.",
                    "Target will remain so for %bdr round(s). Target has 8% chance to be detected.",
                    "Even if target attacks something (weapon or spell),",
                    "the chameleon effect will remain.\""
                    );

                case 1273: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Shadow (Normal)",
                    "Illusion",
                    "Duration: %bdr round(s)",
                    "\"Transforms the target into a shade and makes them very difficult to see. ",
                    "Target will remain so for %bdr round(s). Target has 4% chance to be detected.",
                    "If target attacks something (weapon or spell),",
                    "the shadow effect is aborted.\""
                    );

                case 1274: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Shadow (True)",
                    "Illusion",
                    "Duration: %bdr round(s)",
                    "\"Transforms the target into a shade and makes them very difficult to see. ",
                    "Target will remain so for %bdr round(s). Target has 4% chance to be detected.",
                    "Even if target attacks something (weapon or spell),",
                    "the shadow effect will remain.\""
                    );

                case 1275: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Slowfall",
                    "Alteration",
                    "Duration: %bdr round(s)",
                    "\"Causes target to fall at a safe, constant rate,",
                    "greatly reducing falling damage. Spell will",
                    "remain active for %bdr round(s)."
                    );

                case 1276: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Free Action",
                    "Restoration",
                    "Duration: %bdr round(s)",
                    "\"Renders the target immune to the effects of paralysis",
                    "for %bdr round(s). Paralysis effects are not dispelled,",
                    "and may resume after Free Action ends.\""
                    );

                case 1277: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Jumping",
                    "Alteration",
                    "Duration: %bdr round(s)",
                    "\"Causes target to jump higher than natural capacity, with more control.",
                    "After being cast, spell remains active for %bdr round(s).\""
                    );

                case 1278: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Climbing",
                    "Alteration",
                    "Duration: %bdr round(s)",
                    "\"Causes target to climb at twice the natural rate.",
                    "After being cast, spell remains active for %bdr round(s).\""
                    );

                case 1282: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Water Breathing",
                    "Alteration",
                    "Duration: %bdr round(s)",
                    "\"Causes target to be able to breathe normally under water.",
                    "Water breathing lasts %bdr round(s).\""
                    );

                case 1283: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Water Walking",
                    "Thaumaturgy",
                    "Duration: %bdr round(s)",
                    "\"Allows the target to navigate waters as naturally as walking.",
                    "After being cast, spell will remain active for %bdr round(s).",
                    "Target will ignore encumbrance penalties while swimming.\""
                    );

                case 1285: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Pacify Animal",
                    "Thaumaturgy",
                    "Chance: %bch%",
                    "\"Pacifies any living beast of subhumanoid intelligence.",
                    "Chance for success is %bch%.\""
                    );

                case 1286: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Pacify Undead",
                    "Thaumaturgy",
                    "Chance: %bch%",
                    "\"Pacifies undead creatures.",
                    "Chance for success is %bch%.\""
                    );

                case 1287: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Pacify Humanoid",
                    "Thaumaturgy",
                    "Chance: %bch%",
                    "\"Pacifies humanoid creatures.",
                    "Chance for success is %bch%.\""
                    );

                case 1288: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Pacify Daedra",
                    "Thaumaturgy",
                    "Chance: %bch%",
                    "\"Pacifies Daedra.",
                    "Chance for success is %bch%.\""
                    );

                case 1289: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Charm",
                    "Thaumaturgy",
                    "Chance: %bch%",
                    "\"Pacifies human enemies.",
                    "Chance for success is %bch%.\""
                    );

                case 1290: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Shield",
                    "Alteration",
                    "Duration: %bdr round(s)",
                    "Magnitude: %1bm - %2bm",
                    "\"Creates shield around caster that absorbs the equivalent",
                    "of %1bm - %2bm Health Points. When the shield",
                    "has taken its maximum damage, or %bdr round(s) have elapsed,",
                    "shield will be dispelled.\""
                    );

                case 1296: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Detect Magic",
                    "Thaumaturgy",
                    "Duration: %bdr round(s)",
                    "\"Caster is able to detect all magic around them,",
                    "such as creatures with active magical effects.",
                    "Spell will remain active for %bdr round(s).\""
                    );

                case 1297: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Detect Enemy",
                    "Thaumaturgy",
                    "Duration: %bdr round(s)",
                    "\"Caster is able to detect all enemies around them.",
                    "Spell will remain active for %bdr round(s).\""
                    );

                case 1298: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Detect Treasure",
                    "Thaumaturgy",
                    "Duration: %bdr round(s)",
                    "\"Caster is able to detect all treasure around them.",
                    "Spell will remain active for %bdr round(s).\""
                    );

                case 1299: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Identify",
                    "Thaumaturgy",
                    "Chance: %bch%",
                    "\"Identifies the target of the spell.",
                    "Chance of success is %bch%.\""
                    );

                case 1302: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Teleport",
                    "Mysticism",
                    "\"Teleports caster to a marked location. The caster",
                    "must cast the spell in the designated location initially,",
                    "then will be able to teleport there later. Each casting",
                    "will allow the caster to change the target location of",
                    "the spell.\""
                    );

                case 1303: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Soul Trap",
                    "Mysticism",
                    "Duration: %bdr round(s)",
                    "Chance: %bch%",
                    "\"After death, target's soul may be trapped in any",
                    "appropriate receptacle of the caster indefinitely.",
                    "Target's body must die within %bdr round(s) after",
                    "after being ensorcelled.",
                    "The chance of successfully trapping a soul is %bch%.\""
                    );

                case 1305: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Comprehend Languages",
                    "Mysticism",
                    "Duration: %bdr round(s)",
                    "Chance: %bch%",
                    "\"Caster can comprehend any written or spoken tongue,",
                    "easing diplomacy with all sorts of creatures.",
                    "The spell lasts for %bdr round(s), and increases odds",
                    "of successful pacification by %bch% (additive).\""
                    );

                case 1502: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Paralyze",
                    "Alteration",
                    "Causes target to be paralyzed.",
                    "Duration: How many rounds paralysis lasts.",
                    "Chance: Chance of paralyzing target.",
                    "Magnitude: N/A"
                    );

                case 1504: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Continuous Damage -- Health",
                    "Destruction",
                    "Lowers target's Health each round.",
                    "Duration: How many rounds target takes damage.",
                    "Chance: Chance: N/A",
                    "Magnitude: How much damage target takes per round."
                    );

                case 1505: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Continuous Damage -- Fatigue",
                    "Destruction",
                    "Lowers target's Fatigue each round.",
                    "Duration: How many rounds target takes damage.",
                    "Chance: Chance: N/A",
                    "Magnitude: Amount of Fatigue loss to target per round."
                    );

                case 1506: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Continuous Damage -- Spell Points",
                    "Destruction",
                    "Lowers target's Spell Points each round.",
                    "Duration: How many rounds target takes damage.",
                    "Chance: Chance: N/A",
                    "Magnitude: Amount of Spell Points target loses per round."
                    );

                case 1507: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Create Item",
                    "Mysticism",
                    "Creates one useful item of the caster's choosing.",
                    "Duration: How long created item exists.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1509: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Cure -- Disease",
                    "Restoration",
                    "Cures target of disease.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of curing disease.",
                    "Magnitude: N/A"
                    );

                case 1510: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Cure -- Poison",
                    "Restoration",
                    "Cures target of poison.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of curing poison.",
                    "Magnitude: N/A"
                    );

                case 1511: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Cure -- Paralysis",
                    "Restoration",
                    "Cures target of paralysis.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of curing paralysis.",
                    "Magnitude: N/A"
                    );

                case 1512: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Damage -- Health",
                    "Destruction",
                    "Causes target's Health to be damaged.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of Health Points target loses."
                    );

                case 1513: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Damage -- Fatigue",
                    "Destruction",
                    "Causes target's Fatigue to be damaged.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of Fatigue Points target loses."
                    );

                case 1514: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Damage -- Spell Points",
                    "Destruction",
                    "Reduces target's Spell Points.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of Health Points target loses."
                    );

                case 1515: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Disintegrate",
                    "Destruction",
                    "Causes target to disintegrate.",
                    "Duration: Instantaneous.",
                    "Chance: Chance to disintegrate target.",
                    "Magnitude: N/A"
                    );

                case 1516: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Dispel -- Magic",
                    "Mysticism",
                    "Negates all magic effects on target.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of dispelling magic.",
                    "Magnitude: N/A"
                    );

                case 1517: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Dispel -- Undead",
                    "Mysticism",
                    "Causes undead to be dispelled.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of dispelling undead.",
                    "Magnitude: N/A"
                    );

                case 1518: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Dispel -- Daedra",
                    "Mysticism",
                    "Causes Daedra to be dispelled.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of dispelling Daedra.",
                    "Magnitude: N/A"
                    );

                case 1519: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Strength",
                    "Destruction",
                    "Reduces target's Strength points.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points drained."
                    );

                case 1520: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Intelligence",
                    "Destruction",
                    "Reduces target's Intelligence points.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points drained."
                    );

                case 1521: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Willpower",
                    "Destruction",
                    "Reduces target's Willpower points.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points drained."
                    );

                case 1522: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Agility",
                    "Destruction",
                    "Reduces target's Agility points.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points drained."
                    );

                case 1523: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Endurance",
                    "Destruction",
                    "Reduces target's Endurance points.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points drained."
                    );

                case 1524: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Personality",
                    "Destruction",
                    "Reduces target's Personality points.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points drained."
                    );

                case 1525: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Speed",
                    "Destruction",
                    "Reduces target's Speed points.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points drained."
                    );

                case 1526: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Drain -- Luck",
                    "Destruction",
                    "Reduces target's Luck points.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points drained."
                    );

                case 1527: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Elemental Resistance -- Fire",
                    "Target is more resistant to fire.",
                    "Duration: Rounds resistance lasts.",
                    "Chance: Chance of resisting a fire effect.",
                    "Magnitude: N/A"
                    );

                case 1528: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Elemental Resistance -- Frost",
                    "Target is more resistant to frost.",
                    "Duration: Rounds resistance lasts.",
                    "Chance: Chance of resisting a frost effect.",
                    "Magnitude: N/A"
                    );

                case 1529: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Elemental Resistance -- Poison",
                    "Target is more resistant to poison and disease.",
                    "Duration: Rounds resistance lasts.",
                    "Chance: Chance of resisting a poison or disease effect.",
                    "Magnitude: N/A"
                    );

                case 1530: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Elemental Resistance -- Shock",
                    "Target is more resistant to shock.",
                    "Duration: Rounds resistance lasts.",
                    "Chance: Chance of resisting a shock effect.",
                    "Magnitude: N/A"
                    );

                case 1531: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Elemental Resistance -- Magic",
                    "Target is more resistant to magic.",
                    "Duration: Rounds resistance lasts.",
                    "Chance: Chance of resisting a magic effect.",
                    "Magnitude: N/A"
                    );

                case 1532: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Strength",
                    "Restoration",
                    "Increases target's Strength.",
                    "Duration: Rounds attribute increase lasts.",
                    "Chance: N/A",
                    "Magnitude: Amount of attribute increase."
                    );

                case 1533: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Intelligence",
                    "Restoration",
                    "Increases target's Intelligence.",
                    "Duration: Rounds attribute increase lasts.",
                    "Chance: N/A",
                    "Magnitude: Amount of attribute increase."
                    );

                case 1534: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Willpower",
                    "Restoration",
                    "Increases target's Willpower.",
                    "Duration: Rounds attribute increase lasts.",
                    "Chance: N/A",
                    "Magnitude: Amount of attribute increase."
                    );

                case 1535: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Agility",
                    "Restoration",
                    "Increases target's Agility.",
                    "Duration: Rounds attribute increase lasts.",
                    "Chance: N/A",
                    "Magnitude: Amount of attribute increase."
                    );

                case 1536: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Endurance",
                    "Restoration",
                    "Increases target's Endurance.",
                    "Duration: Rounds attribute increase lasts.",
                    "Chance: N/A",
                    "Magnitude: Amount of attribute increase."
                    );

                case 1537: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Personality",
                    "Restoration",
                    "Increases target's Personality.",
                    "Duration: Rounds attribute increase lasts.",
                    "Chance: N/A",
                    "Magnitude: Amount of attribute increase."
                    );

                case 1538: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Speed",
                    "Restoration",
                    "Increases target's Speed.",
                    "Duration: Rounds attribute increase lasts.",
                    "Chance: N/A",
                    "Magnitude: Amount of attribute increase."
                    );

                case 1539: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Fortify Luck",
                    "Restoration",
                    "Increases target's Luck.",
                    "Duration: Rounds attribute increase lasts.",
                    "Chance: N/A",
                    "Magnitude: Amount of attribute increase."
                    );

                case 1540: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Strength",
                    "Restoration",
                    "Restores target's Strength, up to normal level.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points restored."
                    );

                case 1541: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Intelligence",
                    "Restoration",
                    "Restores target's Intelligence, up to normal level.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points restored."
                    );

                case 1542: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Willpower",
                    "Restoration",
                    "Restores target's Willpower, up to normal level.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points restored."
                    );

                case 1543: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Agility",
                    "Restoration",
                    "Restores target's Agility, up to normal level.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points restored."
                    );

                case 1544: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Endurance",
                    "Restoration",
                    "Restores target's Endurance, up to normal level.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points restored."
                    );

                case 1545: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Personality",
                    "Restoration",
                    "Restores target's Personality, up to normal level.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points restored."
                    );

                case 1546: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Speed",
                    "Restoration",
                    "Restores target's Speed, up to normal level.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points restored."
                    );

                case 1547: return CreateTokens(TextFile.Formatting.JustifyCenter,
                   "Heal Luck",
                    "Restoration",
                    "Restores target's Luck, up to normal level.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points restored."
                    );

                case 1548: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Health",
                    "Restoration",
                    "Restores target's Health, up to normal level.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points restored."
                    );

                case 1549: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Heal Fatigue",
                    "Restoration",
                    "Restores target's Fatigue, up to normal level.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Number of points restored."
                    );

                case 1550: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Strength",
                    "Destruction",
                    "Transfers target Strength points to caster.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Amount of points transferred."
                    );

                case 1551: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Intelligence",
                    "Destruction",
                    "Transfers target Intelligence points to caster.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Amount of points transferred."
                    );

                case 1552: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Willpower",
                    "Destruction",
                    "Transfers target Willpower points to caster.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Amount of points transferred."
                    );

                case 1553: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Agility",
                    "Destruction",
                    "Transfers target Agility points to caster.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Amount of points transferred."
                    );

                case 1554: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Endurance",
                    "Destruction",
                    "Transfers target Endurance points to caster.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Amount of points transferred."
                    );

                case 1555: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Personality",
                    "Destruction",
                    "Transfers target Personality points to caster.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Amount of points transferred."
                    );

                case 1556: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Speed",
                    "Destruction",
                    "Transfers target Speed points to caster.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Amount of points transferred."
                    );

                case 1557: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Luck",
                    "Destruction",
                    "Transfers target Luck points to caster.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Amount of points transferred."
                    );

                case 1558: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Health",
                    "Destruction",
                    "Transfers target Health points to caster.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Amount of points transferred."
                    );

                case 1559: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Transfer Fatigue",
                    "Destruction",
                    "Transfers target Fatigue points to caster.",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: Amount of points transferred."
                    );

                case 1560: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Invisibility (Normal)",
                    "Illusion",
                    "Target becomes invisible. Dispelled if target",
                    "attacks anything.",
                    "Duration: Rounds target remains invisible.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1561: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Invisibility (True)",
                    "Illusion",
                    "Target becomes invisible.",
                    "Duration: Rounds target remains invisible.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1562: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Levitate",
                    "Thaumaturgy",
                    "Target floats above the ground.",
                    "Duration: Rounds target levitates.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1563: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Light",
                    "Illusion",
                    "Creates a light source centered on target.",
                    "Duration: Rounds target remains illuminated.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1564: return UnleveledSpells.Instance.UnleveledOpenAndLock
                    ? CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Lock",
                    "Mysticism",
                    "Locks a door to a lock-level based on magnitude.",
                    "Duration: Until used.",
                    "Chance: N/A",
                    "Magnitude: Level of applied lock."
                    )
                    : CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Lock",
                    "Mysticism",
                    "Locks a door to lock-level of caster.",
                    "Duration: Until used.",
                    "Chance: Chance of success.",
                    "Magnitude: N/A"
                    );

                case 1565: return UnleveledSpells.Instance.UnleveledOpenAndLock
                    ? CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Open",
                    "Mysticism",
                    "Unlocks a door with lock-level up to magnitude.",
                    "Duration: Until used.",
                    "Chance: N/A",
                    "Magnitude: Maximum level of lock."
                    )
                    : CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Open",
                    "Mysticism",
                    "Unlocks a door to lock-level of caster.",
                    "Duration: Until used.",
                    "Chance: Chance of success.",
                    "Magnitude: N/A"
                    );

                case 1566: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Regenerate",
                    "Restoration",
                    "Target regenerates Health Points each round.",
                    "Duration: Rounds target regenerates.",
                    "Chance: N/A",
                    "Magnitude: Number of points regenerated each round."
                    );

                case 1567: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Silence",
                    "Mysticism",
                    "Target is silenced, unable to cast spells.",
                    "Duration: Rounds silence lasts.",
                    "Chance: Chance of success.",
                    "Magnitude: N/A"
                    );

                case 1568: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Spell Absorption",
                    "Restoration",
                    "Target absorbs incoming spell energy, adding spell",
                    "energy points to their own store.",
                    "Duration: Rounds target will absorb spells.",
                    "Chance: Chance of success.",
                    "Magnitude: N/A"
                    );

                case 1569: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Spell Reflection",
                    "Thaumaturgy",
                    "Target reflects incoming spells back at caster.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of success.",
                    "Magnitude: N/A"
                    );

                case 1570: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Spell Resistance",
                    "Thaumaturgy",
                    "Target resists incoming spells.",
                    "Duration: Rounds target will resist spells.",
                    "Chance: Chance of success.",
                    "Magnitude: N/A"
                    );

                case 1571: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Chameleon (Normal)",
                    "Illusion",
                    "Target becomes difficult to see. Spell broken if",
                    "chameleon attacks anything.",
                    "Duration: Rounds target remains obscured.",
                    "Chance: 8% of being spotted.",
                    "Magnitude: N/A"
                    );

                case 1572: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Chameleon (True)",
                    "Illusion",
                    "Target becomes difficult to see.",
                    "Duration: Rounds target remains obscured.",
                    "Chance: 8% of being spotted.",
                    "Magnitude: N/A"
                    );

                case 1573: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Shadow (Normal)",
                    "Illusion",
                    "Target is very difficult to see. Spell broken if",
                    "target attacks anything.",
                    "Duration: Rounds target remains obscured.",
                    "Chance: 4% of being spotted.",
                    "Magnitude: N/A"
                    );

                case 1574: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Shadow (True)",
                    "Illusion",
                    "Target is very difficult to see.",
                    "Duration: Rounds target remains obscured.",
                    "Chance: 4% of being spotted.",
                    "Magnitude: N/A"
                    );

                case 1575: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Slowfall",
                    "Alteration",
                    "Target falls at a safe, constant rate,",
                    "greatly reducing falling damage.",
                    "Duration: Rounds spell remains in effect.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1576: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Free Action",
                    "Restoration",
                    "Target is immune to paralysis.",
                    "Duration: Rounds immunity lasts.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1577: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Jumping",
                    "Alteration",
                    "Target can jump twice as well.",
                    "Duration: Rounds spell remains active.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1578: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Climbing",
                    "Alteration",
                    "Target can climb twice as well.",
                    "Duration: Rounds spell remains active.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1582: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Water Breathing",
                    "Alteration",
                    "Target is able to breathe normally under water.",
                    "Duration: Rounds target can breathe under water.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1583: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Water Walking",
                    "Thaumaturgy",
                    "Target is able navigate waters as naturally as walking.",
                    "Duration: Rounds target swims easier.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1585: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Pacify Animal",
                    "Thaumaturgy",
                    "Pacifies any beast of subhuman intelligence.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of pacification.",
                    "Magnitude: N/A"
                    );

                case 1586: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Pacify Undead",
                    "Thaumaturgy",
                    "Pacifies undead creatures.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of pacification.",
                    "Magnitude: N/A"
                    );

                case 1587: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Pacify Humanoid",
                    "Thaumaturgy",
                    "Pacifies humanoid creatures.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of pacification.",
                    "Magnitude: N/A"
                    );

                case 1588: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Pacify Daedra",
                    "Thaumaturgy",
                    "Pacifies Daedra.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of pacification.",
                    "Magnitude: N/A"
                    );

                case 1589: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Charm",
                    "Thaumaturgy",
                    "Pacifies human enemies.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of pacification.",
                    "Magnitude: N/A"
                    );

                case 1590: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Shield",
                    "Alteration",
                    "Target is surrounded by a magical shield.",
                    "Shield absorbs Health Point damage. Shield lasts",
                    "until its damage is overcome, or spell wears off.",
                    "Duration: Rounds shield can last.",
                    "Chance: N/A",
                    "Magnitude: Health Point damage Shield can absorb."
                    );

                case 1596: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Detect Magic",
                    "Thaumaturgy",
                    "Caster can detect all magic in front of them.",
                    "Duration: Rounds caster can detect magic.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1597: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Detect Enemy",
                    "Thaumaturgy",
                    "Caster can detect all enemies in front of them.",
                    "Duration: Rounds caster can detect enemies.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1598: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Detect Treasure",
                    "Thaumaturgy",
                    "Caster can detect all treasure in front of them.",
                    "Duration: Rounds caster can detect treasure.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1599: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Identify",
                    "Thaumaturgy",
                    "Caster can identify a target object.",
                    "Duration: Instantaneous.",
                    "Chance: Chance of correct identification.",
                    "Magnitude: N/A"
                    );

                case 1602: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Teleport",
                    "Mysticism",
                    "Caster chooses a location, then is able to teleport",
                    "to location instantly. Spell must be cast at least",
                    "twice to use (once to choose location).",
                    "Duration: Instantaneous.",
                    "Chance: N/A",
                    "Magnitude: N/A"
                    );

                case 1603: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Soul Trap",
                    "Mysticism",
                    "After death, target's soul will be deposited",
                    "into any available receptacle.",
                    "Duration: How long spell dooms living target.",
                    "Chance: Chance of imprisoning target.",
                    "Magnitude: N/A"
                    );

                case 1605: return CreateTokens(TextFile.Formatting.JustifyCenter,
                    "Comprehend Languages",
                    "Mysticism",
                    "Caster can comprehend any written or spoken tongue,",
                    "easing diplomacy with all sorts of creatures.",
                    "Duration: How long the caster comprehends languages.",
                    "Chance: Additive increase in pacification odds",
                    "Magnitude: N/A"
                    );
            }

            return base.GetRSCTokens(id);
        }
    }
}