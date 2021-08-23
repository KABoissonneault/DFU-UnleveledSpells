# Kab's Unleveled Spells
Unleveled Spells mod for Daggerfall Unity. Removes level-scaling from spells, in addition to some other magic overhauls.

## Features

- No level-scaling on spells. Fireball does the same thing at level 1 and at level 20.
- Affects player spells, enemy spells (no more 20 rounds long paralyzis effects), and magic items - but not potions
- Spell effect costs overhauled. The classic values were too expensive to leave intact without the crazy level scaling to abuse
- Spell descriptions reworked to remove the "scaling" elements from the text, as well as other legacy mismatches between description and actual effect
- Spell icons have been redone to have more diversity, and to more easily identify the element of an offensive spell (red=fire, yellow=shock, etc...)
- Enemies have been given unique spells in order to keep the same power as classic, in most cases
- Compatible with your existing playthrough, if you're okay with wiping your entire spellbook and filling it up again

## Background
Balancing spell power and cost has been in my sights since I released Skilled Spells, but the scaling part of spells ended up being not very interesting in the way it's implemented in Daggerfall. The difference in cost between a "+1" or a "+1 per level" is always going to have a tipping point where one is more "value-cost efficient" for your level, so low-level characters will take the former and high-level characters the latter. There's no point in mixing them, like you'd expect from a AD&D spell.

So, this mod just removes the level scaling from spells, like the later Elder Scrolls games did. With this, I can just give the effect itself a cost: 50 damage is always worth 50 damage, 35% chance is always worth 35% chance. I couldn't just keep the classic values for spell effect costs - some spells would have just been completely unviable for what they do. So I redid lots of it to make expensive effects cheaper (I didn't make strong effects like Free Action more expensive yet, we'll see about that).

But redoing all the spells to have a fixed strength also affects enemies. When I first tested my mod, the level 2 imps in Privateer's Hold would consistently one-shot me with Toxic Cloud, which now has its level 8 strength at all times. So, I've had to give all spellcasting enemies custom spells too: they should have the same average strength as classic, with the same range and element, except with maybe a bit less variance (ie: min damage higher, max damage lower). Class enemies (ex: Mages, Healers, Sorcerers, ...) all use the same spells as the player gets from the spell vendor, no cheating there.

Since I was in the process of editing all the spells in the game, I also fixed icons and descriptions. They should be more useful than classic at least.

## Changes
0.1
- All classic spells have had their scaling removed, as well as DFU's Mage Light spell (too long to list here)
- For most spells, their strength is equivalent to its level 8 strength. For many spells with effects other than damage or healing, duration has been capped between 3 and 6 rounds. Destruction spells have been arbitrarily given a progression between level 1 and level 18.
- The spell Free Action was changed to cast Free Action instead of Cure Paralysis. A new Cure Paralysis spell was added
- Many spell effects have had their costs reduced, since they were only viable with level scaling before.
- A new formula was introduced for certain spells, based on the Oblivion formula: `cost = factor * duration * pow(chance/100, 1.28) * pow(magnitude, 1.1)`. It's now cheaper to make a long spell that does less than to make a short spell that does more. It's now cheaper to cast a 50% chance spell twice than cast a 100% chance spell once.
- New icons have been assigned. For Destruction spells, the icon color should match the element. Others are mostly arbitrary
- All effect descriptions have had the level scaling removed. Some erroneous classic descriptions have been corrected to reflect the actual effect.
- Spellmaker cannot add level scaling to spell effects
- Enemies have been assigned new spells so that their strength is not affected by the spell rebalance.
- Vampires now cast Vampiric Touch instead of Sleep (the spell ids are next to each other, that was probably a typo)
- Class enemies (ex: Mage, Healer, Sorcerer, ...) now have a spell progression going with their level, as opposed to taking random spells from another creature every 3 levels
- Class enemy spell progression is: Frostbite -> Shock -> Balyna's Balm -> Wizard's Fire -> Ice Bolt -> Toxic Cloud -> Lightning -> Free Action -> Fireball -> Ice Storm. They always have 3-5 of these spells, discarding the weaker ones for stronger ones as they level.
- Spell point cost reduction from magic skill changed from `gold cost * (110 - skill) / 400` to `gold cost * (60 - skill/2) / 400`. Before, at skill level 5, your spells were about 10 times as expensive as the level 100 value. Now it's 6 times. 

0.1.1
- Spell vendor now sells spells at the same cost as the equivalent spell created from the spellmaker. Before, it would do `gold cost = spell point cost * 4`, which means spells were cheaper the more skill you had. Spell vendor is still cheaper than the spellmaker since you can haggle for the price.
- If you use the Hotkey Bar mod, you must update to 0.6 to avoid conflicts.

0.2
- Added (optional) constant spell point regeneration. Every round, some spell points will be recovered, depending on Willpower.
- Holding SHIFT while changing Duration, Chance, or Magnitude in the Spellmaker will now increase/decrease the value by 10

0.2.1
- Added magic school in spell effect descriptions
- Fixed classic rest spell points recovery not being disabled while real-time magic regen is enabled

## Compatibility
- Mods that add new spells are not affected. I'd probably disable **Roleplay & Realism: Items**'s "Skill-based starting spells" so your spellbook is not filled with leveled spells (ew!).
- If you use **Hotkey Bar**, upgrade to 0.6 (or above)
- Mods that change spells will be overwritten.
- Can be used on an existing playthrough, but you must empty and refill your spellbook yourself
- **Basic Magic Regen** must not be used with the spell point regeneration setting of this mod. Pick one.

## Manual

### Spell Effect Costs ###
1. Download https://github.com/KABoissonneault/DFU-UnleveledSpells/blob/main/UnleveledSpells.ods
2. Open in LibreOffice Calc
3. Consult at leisure

### Spell Effect Editor ###
- Compared to vanilla, the "scaling" components have been removed from Duration, Chance, and Magnitude attributes. 
- While holding SHIFT, increasing or decreasing the base value of any spell effect attribute will add or remove 10 instead of 1.

### Spell point regeneration ###
- Optional opt-in setting. Can be enabled and disabled during gameplay (see Mod Settings button at the top-left of the ESC menu)
- Regenerate Willpower/12 spell points every round (ie: in-game minute)
- Casting a spell will add a delay before the regeneration restarts
- Unlike **BasicMagicRegen**, the rounding for "partial" spell point increases is deterministic, and does not depend on the Luck stat
- This is slightly lower than **BasicMagicRegen**'s default settings

### Enemy Spells ###
See https://github.com/KABoissonneault/DFU-UnleveledSpells/blob/main/Scripts/UnleveledEnemySpells.cs

## Conclusion
This is an early release, late-game balance hasn't even been tested (I'm working on it). All forms of feedback on all aspects of the mod are welcome. Please report any issue you see on the Nexus page, in the dfworkshop forums, or the Github.
