using DaggerfallWorkshop.Game.Utility.ModSupport;
using Wenzil.Console;
using System.IO;
using DaggerfallWorkshop;
using FullSerializer;
using System.Collections.Generic;
using DaggerfallWorkshop.Game.MagicAndEffects;
using DaggerfallWorkshop.Game;
using DaggerfallConnect;
using DaggerfallWorkshop.Game.Formulas;
using System;
using DaggerfallConnect.Save;
using System.Linq;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Utility;
using System.Text;

namespace UnleveledSpellsMod
{
    public static class UnleveledSpellsCommands
    {
        public static void RegisterCommands()
        {
#if UNITY_EDITOR
            ConsoleCommandsDatabase.RegisterCommand("us_dump", UnleveledSpellsCommands.Dump, "Dumps Unleveled Spells info to files");
#endif
        }

        static string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

#if UNITY_EDITOR
        static string Dump(params string[] args)
        {
            List<fsData> listRecords = null;
            var dfModFile = UnleveledSpells.Mod.ModInfo.Files.Find(filepath => Path.GetFileName(filepath).EndsWith("dfmod.json"));
            if (!string.IsNullOrEmpty(dfModFile))
            {
                var spellRecordsFullPath = Path.Combine(ModManager.EditorModsDirectory,
                    dfModFile.Replace("Assets/Game/Mods/", "").Replace(Path.GetFileName(dfModFile), ""),
                    "SpellRecords.json");
                if (File.Exists(spellRecordsFullPath))
                {
                    listRecords = fsJsonParser.Parse(File.ReadAllText(spellRecordsFullPath)).AsList;
                }
            }

            if (listRecords != null)
            {
                string outputPath = Path.Combine(DaggerfallUnity.Settings.PersistentDataPath, "us_spell_records.csv");
                using (StreamWriter outputFile = new StreamWriter(outputPath))
                {
                    outputFile.WriteLine("Index;Name;Element;Range;E1;E1 Dur;E1 %;E1 Mag Min;E1 Mag Max;E2;E2 Dur;E2 %;E2 Mag Min;E2 Mag Max;E3;E3 Dur;E3 %; E3 Mag Min; E3 Mag Max;Cost 5;Cost 50; Cost 100");

                    foreach (fsData record in listRecords)
                    {
                        var fields = record.AsDictionary;
                        ElementTypes elementType = (ElementTypes)(1 << (int)fields["element"].AsInt64);
                        TargetTypes targetType = (TargetTypes)(1 << (int)fields["rangeType"].AsInt64);

                        string spellHeader = string.Join(";", fields["index"], fields["spellName"], elementType.ToString(), targetType.ToString());

                        var effects = fields["effects"].AsList;

                        string ToEffectStr(Dictionary<string, fsData> effectData)
                        {
                            var effectType = effectData["type"].AsInt64;
                            var effectSubtype = effectData["subType"].AsInt64;
                            effectSubtype = (effectSubtype < 0) ? 255 : effectSubtype; // Entity effect keys use 255 instead of -1 for subtype

                            int classicKey = BaseEntityEffect.MakeClassicKey((byte)effectType, (byte)effectSubtype);
                            IEntityEffect effectTemplate = GameManager.Instance.EntityEffectBroker.GetEffectTemplate(classicKey);

                            var duration = effectData.TryGetValue("durationBase", out fsData durationValue) ? durationValue.AsInt64.ToString() : "";
                            var chance = effectData.TryGetValue("chanceBase", out fsData chanceValue) ? chanceValue.AsInt64.ToString() : "";
                            var magnitudeLow = effectData.TryGetValue("magnitudeBaseLow", out fsData magnitudeBaseLowValue) ? magnitudeBaseLowValue.AsInt64.ToString() : "";
                            var magnitudeHigh = effectData.TryGetValue("magnitudeBaseHigh", out fsData magnitudeBaseHighValue) ? magnitudeBaseHighValue.AsInt64.ToString() : "";

                            return string.Join(";", effectTemplate.DisplayName, duration, chance, magnitudeLow, magnitudeHigh);
                        }

                        string effect1Str = ToEffectStr(effects[0].AsDictionary);
                        string effect2Str = effects.Count > 1 ? ToEffectStr(effects[1].AsDictionary) : ";;;;";
                        string effect3Str = effects.Count > 2 ? ToEffectStr(effects[2].AsDictionary) : ";;;;";

                        int cost5Total = 0;
                        int cost50Total = 0;
                        int cost100Total = 0;
                        foreach (var effect in effects)
                        {
                            var effectData = effect.AsDictionary;
                            var effectType = effectData["type"].AsInt64;
                            var effectSubtype = effectData["subType"].AsInt64;
                            effectSubtype = (effectSubtype < 0) ? 255 : effectSubtype; // Entity effect keys use 255 instead of -1 for subtype

                            int classicKey = BaseEntityEffect.MakeClassicKey((byte)effectType, (byte)effectSubtype);
                            IEntityEffect effectTemplate = GameManager.Instance.EntityEffectBroker.GetEffectTemplate(classicKey);

                            short permanentValue = GameManager.Instance.PlayerEntity.Skills.GetPermanentSkillValue((DFCareer.Skills)effectTemplate.Properties.MagicSkill);

                            int[] mods = new int[(int)DFCareer.Skills.Count];

                            // Spell cost 1
                            mods[(int)effectTemplate.Properties.MagicSkill] = 5 - permanentValue;
                            GameManager.Instance.PlayerEntity.Skills.AssignMods(mods);

                            EffectEntry effectEntry = new EffectEntry();
                            effectEntry.Key = effectTemplate.Key;
                            if (effectTemplate.Properties.SupportDuration)
                            {
                                effectEntry.Settings.DurationBase = (int)effectData["durationBase"].AsInt64;
                                effectEntry.Settings.DurationPerLevel = 1;
                            }
                            if (effectTemplate.Properties.SupportChance)
                            {
                                effectEntry.Settings.ChanceBase = (int)effectData["chanceBase"].AsInt64;
                                effectEntry.Settings.ChancePerLevel = 1;
                            }
                            if (effectTemplate.Properties.SupportMagnitude)
                            {
                                effectEntry.Settings.MagnitudeBaseMin = (int)effectData["magnitudeBaseLow"].AsInt64;
                                effectEntry.Settings.MagnitudeBaseMax = (int)effectData["magnitudeBaseHigh"].AsInt64;
                                effectEntry.Settings.MagnitudePerLevel = 1;
                            }
                            (int _, int spellPointCost1) = FormulaHelper.CalculateEffectCosts(effectEntry);
                            cost5Total += spellPointCost1;

                            // Spell cost 2
                            mods[(int)effectTemplate.Properties.MagicSkill] = 50 - permanentValue;
                            GameManager.Instance.PlayerEntity.Skills.AssignMods(mods);

                            (int _, int spellPointCost2) = FormulaHelper.CalculateEffectCosts(effectEntry);
                            cost50Total += spellPointCost2;

                            // Spell cost 3
                            mods[(int)effectTemplate.Properties.MagicSkill] = 100 - permanentValue;
                            GameManager.Instance.PlayerEntity.Skills.AssignMods(mods);

                            (int _, int spellPointCost3) = FormulaHelper.CalculateEffectCosts(effectEntry);
                            cost100Total += spellPointCost3;
                        }

                        string line = string.Join(";", spellHeader, effect1Str, effect2Str, effect3Str, cost5Total.ToString(), cost50Total.ToString(), cost100Total.ToString());
                        outputFile.WriteLine(line);
                    }
                }

                outputPath = Path.Combine(DaggerfallUnity.Settings.PersistentDataPath, "us_spell_uesp.txt");
                using (StreamWriter outputFile = new StreamWriter(outputPath))
                {
                    var effectBroker = GameManager.Instance.EntityEffectBroker;

                    IEnumerable<SpellRecord.SpellRecordData> standardSpells = effectBroker.StandardSpells;
                    var spellsDB = standardSpells.Where(spell => spell.spellName != "Holy Touch").ToDictionary(spell => spell.index);

                    void WriteSpell(int spellId, bool anchor)
                    {
                        var spell = spellsDB[spellId];
                        
                        outputFile.WriteLine("|-");

                        var spellName = spell.spellName.Replace("!", "");

                        if (anchor)
                        {
                            outputFile.Write("|{{Anchor|");
                            outputFile.Write(spell.spellName);
                            outputFile.Write("}}||");
                        }
                        else
                        {
                            outputFile.Write($"|{spell.spellName}||");
                        }

                        outputFile.Write(effectBroker.ClassicElementIndexToElementType(spell.element).ToString());
                        outputFile.Write("||");

                        outputFile.Write(AddSpacesToSentence(effectBroker.ClassicTargetIndexToTargetType(spell.rangeType).ToString()));
                        outputFile.Write("||");

                        var effects = spell.effects;
                        var effectTemplates = effects.Select(effect =>
                        {
                            var effectType = effect.type;
                            var effectSubtype = effect.subType;
                            effectSubtype = (effectSubtype < 0) ? 255 : effectSubtype; // Entity effect keys use 255 instead of -1 for subtype

                            int classicKey = BaseEntityEffect.MakeClassicKey((byte)effectType, (byte)effectSubtype);
                            return GameManager.Instance.EntityEffectBroker.GetEffectTemplate(classicKey);
                        }).ToArray();

                        int effectCount = effects.Length;
                        string durations = string.Join("<br>", effects.Select((effect, index) =>
                        {
                            var template = effectTemplates[index];
                            if (template.Properties.SupportDuration)
                            {
                                return effect.durationBase.ToString();
                            }
                            else
                            {
                                return "-";
                            }
                        }));

                        string chances = string.Join("<br>", effects.Select((effect, index) =>
                        {
                            var template = effectTemplates[index];
                            if (template.Properties.SupportChance)
                            {
                                return effect.chanceBase.ToString();
                            }
                            else
                            {
                                return "-";
                            }
                        }));

                        string magnitudes = string.Join("<br>", effects.Select((effect, index) =>
                        {
                            var template = effectTemplates[index];
                            if (template.Properties.SupportMagnitude)
                            {
                                return effect.magnitudeBaseLow.ToString() + "-" + effect.magnitudeBaseHigh.ToString();
                            }
                            else
                            {
                                return "-";
                            }
                        }));

                        string names = string.Join("<br>", effects.Select((effect, index) =>
                        {
                            var template = effectTemplates[index];
                            return template.DisplayName;
                        }));

                        outputFile.Write(string.Join("||", durations, chances, magnitudes, names));
                        outputFile.WriteLine();
                    }

                    // Write standard spells
                    foreach (fsData record in listRecords)
                    {
                        var fields = record.AsDictionary;
                        string spellName = fields["spellName"].AsString;
                        if (spellName.StartsWith("!"))
                            continue;

                        int index = (int)fields["index"].AsInt64;
                        WriteSpell(index, anchor: true);
                    }
                    
                    // Write enemies spells
                    
                    Mod daggerfallEnemyExpansion = ModManager.Instance.GetModFromGUID("76557441-7025-402e-a145-e3e1a28a093d"); // Daggerfall Enemy Expansion

                    foreach(var enemy in EnemyBasics.Enemies)
                    {
                        if (DaggerfallEntity.IsClassEnemyId(enemy.ID))
                            continue;

                        var spells = UnleveledEnemySpells.GetEnemySpells(enemy.ID, enemy.Level);
                        if (spells != null)
                        {
                            outputFile.WriteLine();
                            string enemyName = TextManager.Instance.GetLocalizedEnemyName(enemy.ID);
                            outputFile.WriteLine($"{enemyName}:");
                            foreach (byte spell in spells)
                            {                                
                                WriteSpell(spell, anchor: false);
                            }
                        }
                        else if(daggerfallEnemyExpansion != null)
                        {
                            ModManager.Instance.SendModMessage(daggerfallEnemyExpansion.Title, "getEnemySpells", Tuple.Create(enemy.ID, enemy.Level), (_, result) =>
                            {
                                var customSpells = (int[])result;
                                if(customSpells != null)
                                {
                                    outputFile.WriteLine();
                                    string enemyName = TextManager.Instance.GetLocalizedEnemyName(enemy.ID);
                                    outputFile.WriteLine($"{enemyName}:");
                                    foreach (int spell in customSpells)
                                    {
                                        WriteSpell(spell, anchor: false);
                                    }
                                }
                            });
                        }
                    }

                    // Class enemies
                    for(int i = 0; i < 7; ++i)
                    {
                        int level = Math.Max(i * 3, 1);
                        var spells = UnleveledEnemySpells.GetEnemySpells((int)MobileTypes.Mage, level);
                        outputFile.WriteLine();
                        outputFile.WriteLine($"Class {level}:");
                        foreach (byte spell in spells)
                        {
                            WriteSpell(spell, anchor: false);
                        }
                    }
                }
            }

            {
                string outputPath = Path.Combine(DaggerfallUnity.Settings.PersistentDataPath, "us_enemy_spells.txt");
                using (StreamWriter outputFile = new StreamWriter(outputPath))
                {
                    var effectBroker = GameManager.Instance.EntityEffectBroker;

                    IEnumerable<SpellRecord.SpellRecordData> standardSpells = effectBroker.StandardSpells;
                    var spellsDB = standardSpells.Where(spell => spell.spellName != "Holy Touch").ToDictionary(spell => spell.index);

                    var mobiles = Enum.GetValues(typeof(MobileTypes));

                    void WriteSpells(byte[] spells)
                    {
                        bool needsJoin = false;
                        foreach (byte spell in spells)
                        {
                            if (!needsJoin)
                            {
                                needsJoin = true;
                            }
                            else
                            {
                                outputFile.Write(", ");
                            }

                            var spellRecord = spellsDB[spell];
                            outputFile.Write(spellRecord.spellName);

                            if (spellRecord.effects != null && spellRecord.effects.Length > 0)
                            {
                                var primaryEffect = spellRecord.effects[0];
                                var effectKey = BaseEntityEffect.MakeClassicKey((byte)primaryEffect.type, (byte)primaryEffect.subType);
                                var effectTemplate = effectBroker.GetEffectTemplate(effectKey);
                                if (effectTemplate.Properties.SupportMagnitude)
                                {
                                    var averageMagnitude = (primaryEffect.magnitudeBaseLow + primaryEffect.magnitudeBaseHigh) / 2;
                                    outputFile.Write($" ({primaryEffect.magnitudeBaseLow}-{primaryEffect.magnitudeBaseHigh} [{averageMagnitude}])");
                                }
                            }
                        }
                    }

                    foreach(MobileTypes mobileType in mobiles)
                    {
                        if (DaggerfallEntity.IsClassEnemyId((int)mobileType))
                            continue;

                        byte[] spells = UnleveledEnemySpells.GetEnemySpells((int)mobileType);
                        if (spells == null)
                            continue;

                        MobileEnemy mobile = EnemyBasics.Enemies.First(e => e.ID == (int)mobileType);

                        outputFile.Write($"{mobileType} ({mobile.Level}): ");
                        WriteSpells(spells);
                        outputFile.WriteLine();
                    }

                    outputFile.WriteLine();

                    void WriteClass(int levelMin, int levelMax)
                    {
                        byte[] spells = UnleveledEnemySpells.GetEnemySpells((int)MobileTypes.Mage, levelMin);
                        if (spells == null)
                            return;

                        outputFile.Write($"Class ({levelMin}-{levelMax}): ");
                        WriteSpells(spells);
                        outputFile.WriteLine();
                    }

                    WriteClass(1, 2);
                    WriteClass(3, 5);
                    WriteClass(6, 8);
                    WriteClass(9, 11);
                    WriteClass(12, 14);
                    WriteClass(15, 18);
                    WriteClass(19, 40);
                }
            }

            return "Success";
        }
#endif
    }
}
