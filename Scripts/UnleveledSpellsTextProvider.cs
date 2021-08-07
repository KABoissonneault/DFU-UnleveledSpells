using DaggerfallConnect.Arena2;
using DaggerfallWorkshop.Utility;

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
                "Paralysis",
                "Duration: %bdr",
                "Chance: %bch%",
                "\"Causes target to be paralyzed.",
                "Chance of success is %bch%.",
                "If successful, target will be paralyzed",
                "for %bdr round(s), unless target is cured.\""
                );

            case 1204: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Continuous Damage -- Health",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's health to be damaged.",
                "Target will lose %1bm to %2bm points of health",
                "every round, for %bdr rounds.\""
                );

            case 1205: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Continuous Damage -- Fatigue",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Fatigue to be damaged.",
                "Target will lose %1bm to %2bm points of Fatigue every round,",
                "for %bdr rounds.\""
                );

            case 1206: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Continuous Damage -- Spell Points",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Spell Points to be damaged.",
                "Target will lose %1bm to %2bm Spell Points",
                "every round, for %bdr rounds.\""
                );

            case 1207: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Create Item",
                "Duration: %bdr",
                "\"Creates one useful item of the caster's choosing.",
                "Item lasts for %bdr round(s).\""
                );

            case 1209: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Cure -- Disease",
                "Chance: %bch%",
                "\"Cures target of disease.",
                "Chance of success is %bch%.\""
                );

            case 1210: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Cure -- Poison",
                "Chance: %bch%",
                "\"Cures target of poison.",
                "Chance of success is %bch%.\""
                );

            case 1211: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Cure -- Paralysis",
                "Chance: %bch%",
                "\"Cures target of paralysis.",
                "Chance of success is %bch%.\""
                );

            case 1212: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Damage -- Health",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Health to be damaged.",
                "Target will lose %1bm to %2bm points of Health.\""
                );

            case 1213: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Damage -- Fatigue",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Fatigue to be damaged.",
                "Target will lose %1bm to %2bm points of Fatigue.\""
                );

            case 1214: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Damage -- Spell Points",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Spell Points to be damaged.",
                "Target will lose %1bm to %2bm Spell Points.\""
                );

            case 1215: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Disintegrate",
                "Chance: %bch%",
                "\"Causes target to disintegrate.",
                "Chance of success is %bch%.\""
                );

            case 1216: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Dispel -- Magic",
                "Chance: %bch%",
                "\"Causes magic to be dispelled, removing",
                "all active effects on the target.",
                "Chance of success is %bch%.\""
                );

            case 1217: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Dispel -- Undead",
                "Chance: %bch%",
                "\"Causes undead creatures to be dispelled.",
                "Chance of success is %bch%.\""
                );

            case 1218: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Dispel -- Daedra",
                "Chance: %bch%",
                "\"Causes Daedra to be dispelled.",
                "Chance of success is %bch%.\""
                );

            case 1219: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Drain -- Strength",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Strength to be drained.",
                "Target will lose %1bm to %2bm points of Strength,",
                "until healed.\""
                );

            case 1220: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Drain -- Intelligence",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Intelligence to be drained.",
                "Target will lose %1bm to %2bm points of Intelligence,",
                "until healed.\""
                );

            case 1221: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Drain -- Willpower",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Willpower to be drained.",
                "Target will lose %1bm to %2bm points of Willpower,",
                "until healed.\""
                );

            case 1222: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Drain -- Agility",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Agility to be drained.",
                "Target will lose %1bm to %2bm points of Agility,",
                "until healed.\""
                );

            case 1223: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Drain -- Endurance",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Endurance to be drained.",
                "Target will lose %1bm to %2bm points of Endurance,",
                "until healed.\""
                );

            case 1224: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Drain -- Speed",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Speed to be drained.",
                "Target will lose %1bm to %2bm points of Speed,",
                "until healed.\""
                );

            case 1225: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Drain -- Personality",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Personality to be drained.",
                "Target will lose %1bm to %2bm points of Personality,",
                "until healed.\""
                );

            case 1226: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Drain -- Luck",
                "Magnitude: %1bm - %2bm",
                "\"Causes target's Luck to be drained.",
                "Target will lose %1bm to %2bm points of Luck,",
                "until healed.\""
                );

            case 1227: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Elemental Resistance -- Fire",
                "Duration: %bdr",
                "Chance: %bch%",
                "\"Causes target to be more resistant to fire.",
                "Spell lasts %bdr round(s).",
                "Chance of resisting is %bch%.\""
                );

            case 1228: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Elemental Resistance -- Frost",
                "Duration: %bdr",
                "Chance: %bch%",
                "\"Causes target to be more resistant to cold.",
                "Spell lasts %bdr round(s).",
                "Chance of resisting is %bch%.\""
                );

            case 1229: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Elemental Resistance -- Poison",
                "Duration: %bdr",
                "Chance: %bch%",
                "\"Causes target to be more resistant to poison and disease.",
                "Spell lasts %bdr round(s).",
                "Chance of resisting is %bch%.\""
                );

            case 1230: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Elemental Resistance -- Shock",
                "Duration: %bdr",
                "Chance: %bch%",
                "\"Causes target to be more resistant to shock.",
                "Spell lasts %bdr round(s).",
                "Chance of resisting is %bch%.\""
                );

            case 1231: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Elemental Resistance -- Magic",
                "Duration: %bdr",
                "Chance: %bch%",
                "\"Causes target to be more resistant to magic.",
                "Spell lasts %bdr round(s).",
                "Chance of resisting is %bch%.\""
                );

            case 1232: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Fortify Strength",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Increases target's Strength.",
                "Target will gain %1bm to %2bm points of Strength.",
                "Increase lasts %bdr round(s).\""
                );

            case 1233: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Fortify Intelligence",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Increases target's Intelligence.",
                "Target will gain %1bm to %2bm points of Intelligence.",
                "Increase lasts %bdr round(s).\""
                );

            case 1234: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Fortify Willpower",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Increases target's Willpower.",
                "Target will gain %1bm to %2bm points of Willpower.",
                "Increase lasts %bdr round(s).\""
                );

            case 1235: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Fortify Agility",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Increases target's Agility.",
                "Target will gain %1bm to %2bm points of Agility.",
                "Increase lasts %bdr round(s).\""
                );

            case 1236: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Fortify Endurance",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Increases target's Endurance.",
                "Target will gain %1bm to %2bm points of Endurance.",
                "Increase lasts %bdr round(s).\""
                );

            case 1237: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Fortify Personality",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Increases target's Personality.",
                "Target will gain %1bm to %2bm points of Personality.",
                "Increase lasts %bdr round(s).\""
                );

            case 1238: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Fortify Speed",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Increases target's Speed.",
                "Target will gain %1bm to %2bm points of Speed.",
                "Increase lasts %bdr round(s).\""
                );

            case 1239: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Fortify Luck",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Increases target's Luck.",
                "Target will gain %1bm to %2bm points of Luck.",
                "Increase lasts %bdr round(s).\""
                );

            case 1240: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Heal Strength",
                "Magnitude: %1bm - %2bm",
                "\"Heals target's Strength.",
                "Target will heal %1bm to %2bm points of Strength,",
                "until target's Strength is at its normal level.\""
                );

            case 1241: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Heal Intelligence",
                "Magnitude: %1bm - %2bm",
                "\"Heals target's Intelligence.",
                "Target will heal %1bm to %2bm points of Intelligence,",
                "until target's Intelligence is at its normal level.\""
                );

            case 1242: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Heal Willpower",
                "Magnitude: %1bm - %2bm",
                "\"Heals target's Willpower.",
                "Target will heal %1bm to %2bm points of Willpower,",
                "until target's Willpower is at its normal level.\""
                );

            case 1243: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Heal Agility",
                "Magnitude: %1bm - %2bm",
                "\"Heals target's Agility.",
                "Target will heal %1bm to %2bm points of Agility,",
                "until target's Agility is at its normal level.\""
                );

            case 1244: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Heal Endurance",
                "Magnitude: %1bm - %2bm",
                "\"Heals target's Endurance.",
                "Target will heal %1bm to %2bm points of Endurance,",
                "until target's Endurance is at its normal level.\""
                );

            case 1245: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Heal Personality",
                "Magnitude: %1bm - %2bm",
                "\"Heals target's Personality.",
                "Target will heal %1bm to %2bm points of Personality,",
                "until target's Personality is at its normal level.\""
                );

            case 1246: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Heal Speed",
                "Magnitude: %1bm - %2bm",
                "\"Heals target's Speed.",
                "Target will heal %1bm to %2bm points of Speed,",
                "until target's Speed is at its normal level.\""
                );

            case 1247: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Heal Luck",
                "Magnitude: %1bm - %2bm",
                "\"Heals target's Luck.",
                "Target will heal %1bm to %2bm points of Luck,",
                "until target's Luck is at its normal level.\""
                );

            case 1248: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Heal Health",
                "Magnitude: %1bm - %2bm",
                "\"Heals target's Health.",
                "Target will heal %1bm to %2bm points of Health,",
                "until target's Health is at its normal level.\""
                );

            case 1249: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Heal Fatigue",
                "Magnitude: %1bm - %2bm",
                "\"Heals target's Fatigue.",
                "Target will heal %1bm to %2bm points of Fatigue,",
                "until target's Fatigue is at its normal level.\""
                );

            case 1250: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Transfer Strength",
                "Magnitude: %1bm - %2bm",
                "\"Transfers target's Strength to caster.",
                "Target will be drained of %1bm to %2bm points of Strength,",
                "while the caster is healed of the same amount.\""
                );

            case 1251: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Transfer Intelligence",
                "Magnitude: %1bm - %2bm",
                "\"Transfers target's Intelligence to caster.",
                "Target will be drained of %1bm to %2bm points of Intelligence,",
                "while the caster is healed for the same amount.\""
                );

            case 1252: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Transfer Willpower",
                "Magnitude: %1bm - %2bm",
                "\"Transfers target's Willpower to caster.",
                "Target will be drained of %1bm to %2bm points of Willpower,",
                "while the caster is healed for the same amount.\""
                );

            case 1253: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Transfer Agility",
                "Magnitude: %1bm - %2bm",
                "\"Transfers target's Agility to caster.",
                "Target will be drained of %1bm to %2bm points of Agility,",
                "while the caster is healed for the same amount.\""
                );

            case 1254: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Transfer Endurance",
                "Magnitude: %1bm - %2bm",
                "\"Transfers target's Endurance to caster.",
                "Target will be drained of %1bm to %2bm points of Endurance,",
                "while the caster is healed for the same amount.\""
                );

            case 1255: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Transfer Personality",
                "Magnitude: %1bm - %2bm",
                "\"Transfers target's Personality to caster.",
                "Target will be drained of %1bm to %2bm points of Personality,",
                "while the caster is healed for the same amount.\""
                );

            case 1256: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Transfer Speed",
                "Magnitude: %1bm - %2bm",
                "\"Transfers target's Speed to caster.",
                "Target will be drained of %1bm to %2bm points of Speed,",
                "while the caster is healed for the same amount.\""
                );

            case 1257: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Transfer Luck",
                "Magnitude: %1bm - %2bm",
                "\"Transfers target's Luck to caster.",
                "Target will be drained of %1bm to %2bm points of Luck,",
                "while the caster is healed for the same amount.\""
                );

            case 1258: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Transfer Health",
                "Magnitude: %1bm - %2bm",
                "\"Transfers target's Health to caster.",
                "Target will be drained of %1bm to %2bm points of Health,",
                "while the caster is healed for the same amount.\""
                );

            case 1259: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Transfer Fatigue",
                "Magnitude: %1bm - %2bm",
                "\"Transfers target's Fatigue to caster.",
                "Target will be drained of %1bm to %2bm points of Fatigue,",
                "while the caster is healed for the same amount.\""
                );

            case 1260: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Invisibility (Normal)",
                "Duration: %bdr",
                "\"Turns target invisible.",
                "Target will remain invisible for %bdr round(s).",
                "If target attacks something (weapon or spell), invisibility is dispelled.\""
                );

            case 1261: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Invisibility (True)",
                "Duration: %bdr",
                "\"Turns target invisible.",
                "Target will remain invisible for %bdr round(s).",
                "Even if target attacks something (weapon or spell),",
                "target will still remain invisible.\""
                );

            case 1262: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Levitate",
                "Duration: %bdr",
                "\"Target is able to float above the ground.",
                "Target will levitate for %bdr round(s).\""
                );

            case 1263: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Light",
                "Duration: %bdr",
                "\"Bright light source created around target.",
                "Light will remain for %bdr round(s).\""
                );

            case 1264: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Lock",
                "Chance: %bch%",
                "\"Locks door to a lock-level equal to the caster's level.",
                "Chance of success is %bch%.\""
                );

            case 1265: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Open",
                "Chance: %bch%",
                "\"Opens door with lock-level equal to or less than",
                "the caster's level. Chance of success is %bch%.\""
                );

            case 1266: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Regeneration",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Regenerates target's Health. Target will gain %1bm to %2bm",
                "points of Health. Increases continue for %bdr round(s).\""
                );

            case 1267: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Silence",
                "Duration: %bdr",
                "Chance: %bch%",
                "\"Silences target, making casting spells impossible.",
                "Chance of success is %bch%. Silence lasts %bdr round(s).\""
                );

            case 1268: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Spell Absorption",
                "Duration: %bdr",
                "Chance: %bch%",
                "\"Target is able to absorb incoming spells, adding their",
                "energy to their own store. Chance of success is %bch%.",
                "Absorption lasts %bdr round(s). If the store is too full,",
                "the effect always fails.\""
                );

            case 1269: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Spell Reflection",
                "Duration: %bdr",
                "Chance: %bch%",
                "\"Target is able to reflect incoming spells back at its caster.",
                "Chance of success is %bch%. Reflection lasts %bdr round(s).",
                "Spells can only be reflected once.\""
                );

            case 1270: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Spell Resistance",
                "Duration: %bdr",
                "Chance: %bch%",
                "\"Target is able to resist incoming spells.",
                "Chance of success is %bch%. Resistance lasts %bdr round(s).",
                "Will not resist spells cast on self.\""
                );

            case 1271: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Chameleon (Normal)",
                "Duration: %bdr",
                "\"Changes the color of the target and makes them difficult to see.",
                "Target will remain so for %bdr round(s). Target has 8% chance to be detected.",
                "If target attacks something (weapon or spell),",
                "the chameleon effect is aborted.\""
                );

            case 1272: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Chameleon (True)",
                "Duration: %bdr",
                "\"Changes the color of the target and makes them difficult to see.",
                "Target will remain so for %bdr round(s). Target has 8% chance to be detected.",
                "Even if target attacks something (weapon or spell),",
                "the chameleon effect will remain.\""
                );

            case 1273: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Shadow (Normal)",
                "Duration: %bdr",
                "\"Transforms the target into a shade and makes them very difficult to see. ",
                "Target will remain so for %bdr round(s). Target has 4% chance to be detected.",
                "If target attacks something (weapon or spell),",
                "the shadow effect is aborted.\""
                );

            case 1274: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Shadow (True)",
                "Duration: %bdr",
                "\"Transforms the target into a shade and makes them very difficult to see. ",
                "Target will remain so for %bdr round(s). Target has 4% chance to be detected.",
                "Even if target attacks something (weapon or spell),",
                "the shadow effect will remain.\""
                );

            case 1275: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Slowfall",
                "Duration: %bdr",
                "\"Causes target to fall at a safe, constant rate,",
                "greatly reducing falling damage. Spell will",
                "remain active for %bdr round(s)."
                );

            case 1276: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Free Action",
                "Duration: %bdr",
                "\"Renders the target immune to the effects of paralysis",
                "for %bdr round(s). Paralysis effects are not dispelled,",
                "and may resume after Free Action ends.\""
                );

            case 1277: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Jumping",
                "Duration: %bdr",
                "\"Causes target to jump higher than natural capacity, with more control.",
                "After being cast, spell remains active for %bdr round(s).\""
                );

            case 1278: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Climbing",
                "Duration: %bdr",
                "\"Causes target to climb at twice the natural rate.",
                "After being cast, spell remains active for %bdr round(s).\""
                );

            case 1282: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Water Breathing",
                "Duration: %bdr",
                "\"Causes target to be able to breathe normally under water.",
                "Water breathing lasts %bdr round(s).\""
                );

            case 1283: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Water Walking",
                "Duration: %bdr",
                "\"Allows the target to navigate waters as naturally as walking.",
                "After being cast, spell will remain active for %bdr round(s).",
                "Target will ignore encumbrance penalties while swimming.\""
                );

            case 1285: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Pacify Animal",
                "Chance: %bch%",
                "\"Pacifies any living beast of subhumanoid intelligence.",
                "Chance for success is %bch%.\""
                );

            case 1286: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Pacify Undead",
                "Chance: %bch%",
                "\"Pacifies undead creatures.",
                "Chance for success is %bch%.\""
                );

            case 1287: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Pacify Humanoid",
                "Chance: %bch%",
                "\"Pacifies humanoid creatures.",
                "Chance for success is %bch%.\""
                );

            case 1288: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Pacify Daedra",
                "Chance: %bch%",
                "\"Pacifies Daedra.",
                "Chance for success is %bch%.\""
                );

            case 1289: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Charm",
                "Chance: %bch%",
                "\"Pacifies human enemies.",
                "Chance for success is %bch%.\""
                );

            case 1290: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Shield",
                "Duration: %bdr",
                "Magnitude: %1bm - %2bm",
                "\"Creates shield around caster that absorbs the equivalent",
                "of %1bm - %2bm Health Points. When the shield",
                "has taken its maximum damage, or %bdr round(s) have elapsed,",
                "shield will be dispelled.\""
                );

            case 1296: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Detect Magic",
                "Duration: %bdr",
                "\"Caster is able to detect all magic around them,",
                "such as creatures with active magical effects.",
                "Spell will remain active for %bdr round(s).\""
                );

            case 1297: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Detect Enemy",
                "Duration: %bdr",
                "\"Caster is able to detect all enemies around them.",
                "Spell will remain active for %bdr round(s).\""
                );

            case 1298: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Detect Treasure",
                "Duration: %bdr",
                "\"Caster is able to detect all treasure around them.",
                "Spell will remain active for %bdr round(s).\""
                );

            case 1299: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Identify",
                "Chance: %bch%",
                "\"Identifies the target of the spell.",
                "Chance of success is %bch%.\""
                );

            case 1302: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Teleport",
                "\"Teleports caster to a marked location. The caster",
                "must cast the spell in the designated location initially,",
                "then will be able to teleport there later. Each casting",
                "will allow the caster to change the target location of",
                "the spell.\""
                );

            case 1303: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Soul Trap",
                "Duration: %bdr",
                "Chance: %bch%",
                "\"After death, target's soul may be trapped in any",
                "appropriate receptacle of the caster indefinitely.",
                "Target's body must die within %bdr round(s) after",
                "after being ensorcelled.",
                "The chance of successfully trapping a soul is %bch%.\""
                );

            case 1305: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Comprehend Languages",
                "Duration: %bdr",
                "\"Caster can comprehend any written or spoken tongue,",
                "easing diplomacy with all sorts of creatures.",
                "The spell lasts for %bdr round(s).\""
                );

            case 1502: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Paralyzation",
                "Causes target to be paralyzed.",
                "Duration: How many rounds paralysis lasts.",
                "Chance: Chance of paralyzing target.",
                "Magnitude: N/A"
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

            case 1564: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Lock",
                "Locks a door to lock-level of caster.",
                "Duration: Instantaneous.",
                "Chance: Chance of success.",
                "Magnitude: N/A"
                );

            case 1565: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Open",
                "Unlocks a door to lock-level of caster.",
                "Duration: Instantaneous.",
                "Chance: Chance of success.",
                "Magnitude: N/A"
                );

            case 1571: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Chameleon (Normal)",
                "Target becomes difficult to see. Spell broken if",
                "chameleon attacks anything.",
                "Duration: Rounds target remains obscured.",
                "Chance: 8% of being spotted.",
                "Magnitude: N/A"
                );

            case 1572: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Chameleon (True)",
                "Target becomes difficult to see.",
                "Duration: Rounds target remains obscured.",
                "Chance: 8% of being spotted.",
                "Magnitude: N/A"
                );

            case 1573: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Shadow (Normal)",
                "Target is very difficult to see. Spell broken if",
                "target attacks anything.",
                "Duration: Rounds target remains obscured.",
                "Chance: 4% of being spotted.",
                "Magnitude: N/A"
                );

            case 1574: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Shadow (True)",
                "Target is very difficult to see.",
                "Duration: Rounds target remains obscured.",
                "Chance: 4% of being spotted.",
                "Magnitude: N/A"
                );

            case 1575: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Slowfall",
                "Target falls at a safe, constant rate,",
                "greatly reducing falling damage.",
                "Duration: Rounds spell remains in effect.",
                "Chance: N/A",
                "Magnitude: N/A"
                );

            case 1582: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Water Breathing",
                "Target is able to breathe normally under water.",
                "Duration: Rounds target can breathe under water.",
                "Chance: N/A",
                "Magnitude: N/A"
                );

            case 1583: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Water Walking",
                "Target is able navigate waters as naturally as walking.",
                "Duration: Rounds target swims easier.",
                "Chance: N/A",
                "Magnitude: N/A"
                );

            case 1585: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Pacify Animal",
                "Pacifies any beast of subhuman intelligence.",
                "Duration: Instantaneous.",
                "Chance: Chance of pacification.",
                "Magnitude: N/A"
                );

            case 1586: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Pacify Undead",
                "Pacifies undead creatures.",
                "Duration: Instantaneous.",
                "Chance: Chance of pacification.",
                "Magnitude: N/A"
                );

            case 1587: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Pacify Humanoid",
                "Pacifies humanoid creatures.",
                "Duration: Instantaneous.",
                "Chance: Chance of pacification.",
                "Magnitude: N/A"
                );

            case 1588: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Pacify Daedra",
                "Pacifies Daedra.",
                "Duration: Instantaneous.",
                "Chance: Chance of pacification.",
                "Magnitude: N/A"
                );

            case 1589: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Charm",
                "Pacifies human enemies.",
                "Duration: Instantaneous.",
                "Chance: Chance of pacification.",
                "Magnitude: N/A"
                );

            case 1602: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Teleport",
                "Caster chooses a location, then is able to teleport",
                "to location instantly. Spell must be cast at least",
                "twice to use (once to choose location).",
                "Duration: Instantaneous.",
                "Chance: N/A",
                "Magnitude: N/A"
                );

            case 1605: return CreateTokens(TextFile.Formatting.JustifyCenter,
                "Comprehend Languages",
                "Caster can comprehend any written or spoken tongue,",
                "easing diplomacy with all sorts of creatures.",
                "Duration: How long the caster comprehends languages.",
                "Chance: N/A",
                "Magnitude: N/A"
                );
        }

        return base.GetRSCTokens(id);
    }
}
