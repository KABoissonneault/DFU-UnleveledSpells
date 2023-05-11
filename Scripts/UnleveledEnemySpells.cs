using DaggerfallWorkshop;
using DaggerfallWorkshop.Game.Entity;
using System;
using UnityEngine;


namespace UnleveledSpellsMod
{
    public static class UnleveledEnemySpells
    {
        // Classic
        /* 
       static byte[] ImpSpells = // Level 2
       {
           0x07, // Wizard's Fire (1-15+2d4=3-23=8-20=13)
           0x0A, // Free Action 
           0x1D, // Toxic Cloud (1-25+2d5=3-35=7-31=19)
           0x2C // Chameleon
       };
       */

        static byte[] ImpSpells = // Level 2
        {
            102, // Imp's Fire (8-18 / 13)
            10, // Free Action 
            101, // Stinking Cloud (12-24 / 18)
            44, // Chameleon
        };

        // Classic
        /*
        static byte[] GhostSpells = // Level 11
        {
            0x22 // Wizard Rend (12-25) | (65% for 12 rounds)
        };
        */

        static byte[] GhostSpells = // Level 11
        {
            0x22 // Wizard Rend (12-24) | (35% for 3 rounds)
        };

        // Classic
        /*
        static byte[] OrcShamanSpells = // Level 13
        {
            0x06, // Invisibility 
            0x07, // Wizard's Fire (1-15+13d4=14-67=33-47=40.5)
            0x16, // Spell Shield (76% for 14 rounds)
            0x19, // Fire Storm (1-20+13d5=14-85=40-59)
            0x1F // Lightning (1-25+13d5=40-64)
        };
        */

        static byte[] OrcShamanSpells = // Level 13
        {
            0x06, // Invisibility 
            7, // Wizard's Fire (33-47 / 40)
            0x16, // Spell Shield (50% for 3 rounds)
            104, // Greater Firestorm (46-64 / 55)
            31 // Lightning (34-58 / 46)
        };

        // Classic
        /*
        static byte[] WraithSpells = // Level 15
        {
            0x1C, // Far Silence (65% for 16 rounds)
            0x1F // Lightning (1-25+15d5=16-100=46-70=58)
        };
        */

        static byte[] WraithSpells = // Level 15
        {
            0x1C, // Far Silence (50% for 3 rounds)
            106 // Cold Scream (46-70 / 58) (Cold)
        };

        // Classic
        /*
        static byte[] FrostDaedraSpells = // Level 17
        {
            0x10, // Ice Bolt (18-120=1-35+17d5=52-86)
            0x14 // Ice Storm (18-115=1-30+17d5=52-81)
        };
        */

        static byte[] FrostDaedraSpells = // Level 17
        {
            107, // Greater Frostbolt (52-86 / 69)
            20 // Ice Storm (52-81 / 66)
        };

        // Classic
        /*
        static byte[] FireDaedraSpells = // Level 17
        {
            0x0E, // Fireball (1+17d7=52-85=68)
            0x19 // Fire Storm (1-20+17d5=18-105=52-71)
        };
        */

        static byte[] FireDaedraSpells = // Level 17
        {
            0x0E, // Fireball (52-85 / 68)
            110 // Major Firestorm (63-87 / 75)
        };

        // Classic
        /*
        static byte[] DaedrothSpells = // Level 18
        {
            0x16, // Spell Shield (86% for 19 rounds)
            0x17, // Silence (71% for 19 rounds)
            0x1F // Lightning (1-25+18d5=55-79)
        };
        */

        static byte[] DaedrothSpells = // Level 18
        {
            0x16, // Spell Shield (50% for 3 rounds)
            0x17, // Silence (75% for 3 rounds)
            111 // Greater Lightning (55-79 / 67)
        };

        // Classic
        /*
        static byte[] VampireSpells = // Level 19
        {
            0x33 // Sleep (20-110 for 43 rounds)
                // Probably meant to be 0x34, Vampiric Touch
        };
        */

        static byte[] VampireSpells = // Level 19
        {
            0x34 // Vampiric Touch (15-30)
        };

        // Classic
        /*
        static byte[] SeducerSpells = // Level 19
        {
            0x34, // Vampiric Touch (20-110)
            0x43 // Energy Leech (96-105)
        };
        */


        static byte[] SeducerSpells = // Level 19
        {
            0x34, // Vampiric Touch (15-30)
            0x43 // Energy Leech (40-50)
        };

        // Classic
        /*
        static byte[] VampireAncientSpells = // Level 20
        {
            0x08, // Shock (21-100=51-70)
            0x32 // Paralysis (65% for 23 rounds)
        };
        */

        static byte[] VampireAncientSpells = // Level 20
        {
            112, // Ancient Vampiric Touch (31-50)
            115 // Stormhand (55-79 / 67 | 65% for 3 rounds)
        };

        // Classic
        /*
        static byte[] DaedraLordSpells = // Level 20
        {
            0x08, // Shock (21-100)
            0x0A, // Free Action
            0x0E, // Fireball (21-141)
            0x3C, // Balyna's Antidote (100%)
            0x43 // Energy Leech (101-110)
        };
        */

        static byte[] DaedraLordSpells = // Level 20
        {
            111, // Greater Lightning (55-79 / 67)
            0x0A, // Free Action
            14, // Fireball (52-85 / 68)
            0x43 // Energy Leech (40-50)
        };

        // Classic
        /*
        static byte[] LichSpells = // Level 20
        {
            0x08, // Shock (21-100)
            0x0A, // Free Action
            0x0E, // Fireball (21-141)
            0x22, // Wizard Rend (21-35) | (100% for 21 rounds)
            0x3C // Balyna's Antidote (100%)
        };
        */

        static byte[] LichSpells = // Level 20
        {
            118, // Greater Frostbite (55-79 / 67)
            0x0A, // Free Action
            110, // Frostball (52-85 / 68)
            0x22, // Wizard Rend (12-24) | (35% for 3 rounds)
        };

        // Classic
        /*
        static byte[] AncientLichSpells = // Level 21
        {
            0x08, // Shock (22-104)
            0x0A, // Free Action
            0x0E, // Fireball (22-148)
            0x1D, // Toxic Cloud (1-25+21d5=22-130=64-88)
            0x1F, // Lightning (22-130)
            0x22, // Wizard Rend (12-24) | (35% for 3 rounds)
        };
        */

        static byte[] AncientLichSpells = // Level 21
        {
            118, // Greater Frostbite (55-79)
            0x0A, // Free Action
            110, // Frostball (52-85)
            113, // Acid Cloud (64-88 / 76)
        };

        static byte[] EnemyClass1_2 =
        {
            0x03, // Frostbite (8-14 / 11)
            102, // Apprentice's Fire (8-18 / 13)
            0x61, // Balyna's Balm (5-15)
        };

        static byte[] EnemyClass3_5 =
        {
            0x03, // Frostbite (8-14 / 11)
            102, // Apprentice's Fire (8-18 / 13)
            0x08, // Shock (11-25 / 18)
            0x61, // Balyna's Balm (5-15)
        };

        static byte[] EnemyClass6_8 =
        {
            0x61, // Balyna's Balm (5-15)
            33, // Wildfire (10*5 / 50)
            16, // Ice Bolt (25-59 / 42)
            29, // Toxic Cloud (25-49 / 37)
        };

        static byte[] EnemyClass9_11 =
        {
            103, // Balyna's Salve (20-30)
            7, // Wizard's Fire (33-47 / 40)
            16, // Ice Bolt (25-59 / 42)
            29, // Toxic Cloud (25-49 / 37)
            31, // Lightning (35-58 / 46)
        };

        static byte[] EnemyClass12_14 =
        {
            103, // Balyna's Salve (20-30)
            7, // Wizard's Fire (33-47 / 40)
            16, // Ice Bolt (25-59 / 42)
            29, // Toxic Cloud (25-49 / 37)
            31, // Lightning (35-58 / 46)
            10, // Free Action
        };

        static byte[] EnemyClass15_17 =
        {
            103, // Balyna's Salve (20-30)
            16, // Ice Bolt (25-59 / 42)
            29, // Toxic Cloud (25-49 / 37)
            31, // Lightning (35-58 / 46)
            10, // Free Action
            14, // Fireball (52-85 / 68)
        };

        static byte[] EnemyClass18 =
        {
            113, // Acid Cloud (64-88 / 76)
            111, // Greater Lightning (55-79 / 67)
            0x0A, // Free Action
            14, // Fireball (52-85 / 68)
            20 // Ice Storm (52-81 / 66)
        };

        static byte[][] EnemyClassSpells =
        {
            EnemyClass1_2, // 1-2
            EnemyClass3_5, // 3-5
            EnemyClass6_8, // 6-8
            EnemyClass9_11, // 9-11
            EnemyClass12_14, // 12-14
            EnemyClass15_17, // 15-17
            EnemyClass18 // 18+
        };

        // Spider (Level 4)
        // Before: Spider Touch (65% for 5 rounds)
        // After: Spider Touch (35% for 3 rounds)

        // Scorpion (Level 12)
        // Before: Spider Touch (100% for 13 rounds)
        // After: Spider Touch (35% for 3 rounds)

        static bool HasCustomSpells(EnemyEntity e)
        {
            // Only support baseline enemies for now
            if (!Enum.IsDefined(typeof(MobileTypes), e.MobileEnemy.ID))
                return false;

            return true;
        }

        public static void OnEnemySpawned(object sender, EnemyLootSpawnedEventArgs args)
        {
            var enemyEntity = sender as EnemyEntity;
            if (enemyEntity == null)
                return;

            if (!HasCustomSpells(enemyEntity))
                return;

            // Reset spells
            while (enemyEntity.SpellbookCount() > 0)
                enemyEntity.DeleteSpell(enemyEntity.SpellbookCount() - 1);

            // Assign new
            if (enemyEntity.EntityType == EntityTypes.EnemyClass)
            {
                if (enemyEntity.MobileEnemy.CastsMagic)
                {
                    int spellListLevel = enemyEntity.Level / 3;
                    if (spellListLevel > 6)
                        spellListLevel = 6;
                    enemyEntity.SetEnemySpells(EnemyClassSpells[spellListLevel]);
                }
            }
            else
            {
                if (enemyEntity.CareerIndex == (int)MonsterCareers.Imp)
                    enemyEntity.SetEnemySpells(ImpSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.Ghost)
                    enemyEntity.SetEnemySpells(GhostSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.OrcShaman)
                    enemyEntity.SetEnemySpells(OrcShamanSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.Wraith)
                    enemyEntity.SetEnemySpells(WraithSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.FrostDaedra)
                    enemyEntity.SetEnemySpells(FrostDaedraSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.FireDaedra)
                    enemyEntity.SetEnemySpells(FireDaedraSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.Daedroth)
                    enemyEntity.SetEnemySpells(DaedrothSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.Vampire)
                    enemyEntity.SetEnemySpells(VampireSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.DaedraSeducer)
                    enemyEntity.SetEnemySpells(SeducerSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.VampireAncient)
                    enemyEntity.SetEnemySpells(VampireAncientSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.DaedraLord)
                    enemyEntity.SetEnemySpells(DaedraLordSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.Lich)
                    enemyEntity.SetEnemySpells(LichSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.AncientLich)
                    enemyEntity.SetEnemySpells(AncientLichSpells);
            }
        }
    }
}
