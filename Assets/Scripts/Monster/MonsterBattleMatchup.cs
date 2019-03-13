using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MonsterBattleMatchup
{
    //Will use ushort values since the damage multipliers will either be 0, 1/2x, or 2x
    //This will either result in clear(AND with 0), 1/2x(shift right by 1), 2x(shift left by 1).
    //0 represents clear, 1 represents 1, -1 represents 1/2, 2 represents 2
    //Only using ushort for now since its easier to read at the start of this game. will eventually
    //hopefully move on to using byte since that's the real data type pokemon uses.
    private static sbyte[][] monsterMatchup = new sbyte[][] 
    { 
        new sbyte[]{ 1, 2, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, //NORMAL
        new sbyte[]{ 1, 1, 2, 1, 1, -1, -1, 1, 1, 1, 1, 1, 1, 2, 1, 1, -1, 2 }, //FIGHT
        new sbyte[]{ 1, -1, 1, 1, 0, 2, -1, 1, 1, 1, 1, -1, 2, 1, 2, 1, 1, 1 }, //FLYING
        new sbyte[]{ 1, -1, 1, -1, 2, 1, -1, 1, 1, 1, 1, -1, 1, 2, 1, 1, 1, -1 }, //POISON
        new sbyte[]{ 1, 1, 1, -1, 1, -1, 1, 1, 1, 1, 2, 2, 0, 1, 2, 1, 1, 1 }, //GROUND
        new sbyte[]{ -1, 2, -1, -1, 2, 1, 1, 1, 2, -1, 2, 2, 1, 1, 1, 1, 1, 1 }, //ROCK
        new sbyte[]{ 1, -1, 2, 1, -1, 2, 1, 1, 1, 2, 1, -1, 1, 1, 1, 1, 1, 1 }, //BUG
        new sbyte[]{ -1, 2, -1, 0, 2, -1, -1, 1, -1, 2, 1, -1, 1, -1, -1, -1, 1, -1 }, //STEEL
        new sbyte[]{ 1, 1, 1, 1, 2, 2, -1, 1, -1, -1, 2, -1, 1, 1, -1, 1, 1, -1 }, //FIRE
        new sbyte[]{ 1, 1, 1, 1, 1, 1, 1, 1, -1, -1, -1, 2, 2, 1, -1, 1, 1, 1 }, //WATER
        new sbyte[]{ 1, 1, 2, 2, -1, 1, 2, 1, 1, 2, -1, -1, -1, 1, 2, 1, 1, 1 }, //GRASS
        new sbyte[]{ 1, 1, -1, 1, 2, 1, 1, 1, -1, 1, 1, 1, -1, 1, 1, 1, 1, 1 }, //ELECTRIC
        new sbyte[]{ 1, -1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, -1, 1, 1, 2, 1 }, //PSYCHIC
        new sbyte[]{ 1, 2, 1, 1, 1, 2, 1, 1, 2, 2, 1, 1, 1, 1, -1, 1, 1, 1 }, //ICE
        new sbyte[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, -1, -1, -1, 1, 2, 2, 1, 2 }, //DRAGON
        new sbyte[]{ 1, 2, 1, 1, 1, 1, 2, -1, 1, 1, 1, 1, 1, 0, 1, 1, -1, 2 }, //DARK
        new sbyte[]{ 1, -1, 1, 2, 1, 1, -1, 1, 2, 1, 1, 1, 1, 1, 1, 0, -1, 1 }, //FAIRY
        new sbyte[]{ 0, 0, 1, -1, 1, 1, -1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1 }, //GHOST
    };

    public static ushort GetTypeMatchupDamage(ushort damage, MonsterType attackType, MonsterType primaryTargetType, 
        MonsterType secondaryTargetType = MonsterType.NONE)
    {
        var firstMultiplier = monsterMatchup[(int)primaryTargetType][(int)attackType];
        damage = ModifyDamage(damage, firstMultiplier);
        if(secondaryTargetType != MonsterType.NONE)
        {
            var secondMultiplier = monsterMatchup[(int)secondaryTargetType][(int)attackType];
            damage = ModifyDamage(damage, secondMultiplier);
        }
        return damage;
    }

    private static ushort ModifyDamage(ushort damage, sbyte multiplier)
    {
        ushort one = 1;
        switch(multiplier)
        {
            case -1:
                damage = (ushort)(damage >> one);
                break;
            case 0:
                damage = 0;
                break;
            case 2:
                damage = (ushort)(damage << one);
                break;
            default:
                break;
        }

        return damage;
    }
}
