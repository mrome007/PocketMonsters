using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MonsterBattleMatchup
{
    //Will use short values since the damage multipliers will either be 0, 1/2x, or 2x
    //This will either result in clear(AND with 0), 1/2x(shift right by 1), 2x(shift left by 1).
    //0 represents clear, 1 represents 1, -1 represents 1/2, 2 represents 2
    //Only using short for now since its easier to read at the start of this game. will eventually
    //hopefully move on to using byte since that's the real data type pokemon uses.
    private static short[][] monsterMatchup = new short[][] 
    { 
        new short[]{ 1, 2, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        new short[]{ 1, 1, 2, 1, 1, -1, -1, 1, 1, 1, 1, 1, 1, 2, 1, 1, -1, 2 },
        new short[]{ 1, -1, 1, 1, 0, 2, -1, 1, 1, 1, 1, -1, 2, 1, 2, 1, 1, 1 },
        new short[]{ 1, -1, 1, -1, 2, 1, -1, 1, 1, 1, 1, -1, 1, 2, 1, 1, 1, -1 },
        new short[]{ 1, 1, 1, -1, 1, -1, 1, 1, 1, 1, 2, 2, 0, 1, 2, 1, 1, 1 },
        new short[]{ -1, 2, -1, -1, 2, 1, 1, 1, 2, -1, 2, 2, 1, 1, 1, 1, 1, 1 },
        new short[]{ 1, -1, 2, 1, -1, 2, 1, 1, 1, 2, 1, -1, 1, 1, 1, 1, 1, 1 },
        new short[]{ 0, 0, 1, -1, 1, 1, -1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1 },
        new short[]{ -1, 2, -1, 0, 2, -1, -1, 1, -1, 2, 1, -1, 1, -1, -1, -1, 1, -1 },
        new short[]{ 1, 1, 1, 1, 2, 2, -1, 1, -1, -1, 2, -1, 1, 1, -1, 1, 1, -1 },
        new short[]{ 1, 1, 1, 1, 1, 1, 1, 1, -1, -1, -1, 2, 2, 1, -1, 1, 1, 1 },
        new short[]{ 1, 1, 2, 2, -1, 1, 2, 1, 1, 2, -1, -1, -1, 1, 2, 1, 1, 1 },
        new short[]{ 1, 1, -1, 1, 2, 1, 1, 1, -1, 1, 1, 1, -1, 1, 1, 1, 1, 1 },
        new short[]{ 1, -1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, -1, 1, 1, 2, 1 },
        new short[]{ 1, 2, 1, 1, 1, 2, 1, 1, 2, 2, 1, 1, 1, 1, -1, 1, 1, 1 },
        new short[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, -1, -1, -1, 1, 2, 2, 1, 2 },
        new short[]{ 1, 2, 1, 1, 1, 1, 2, -1, 1, 1, 1, 1, 1, 0, 1, 1, -1, 2 },
        new short[]{ 1, -1, 1, 2, 1, 1, -1, 1, 2, 1, 1, 1, 1, 1, 1, 0, -1, 1 },
    };
}
