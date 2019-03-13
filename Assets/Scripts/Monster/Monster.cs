using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Sprite MonsterFrontSprite;
    public Sprite MonsterBackSprite;
    public Monster Evolution;

    public ushort MonsterNumber;
    public string MonsterName;

    public MonsterType PrimaryType;
    public MonsterType SecondaryType;

    public ushort BaseStatTotal { get; private set; }

    public ushort BaseHP;
    public ushort BaseAttack;
    public ushort BaseDefense;
    public ushort BaseSpecial;
    public ushort BaseSpeed;

    public MonsterExpGroup ExperienceGroup;
    public BodyType BodyType;

    public List<LearnedMove> MovesByLevelUp;

    private void Awake()
    {
        InitializeBaseTotal();
    }

    private void InitializeBaseTotal()
    {
        BaseStatTotal = 0;
        BaseStatTotal += BaseHP;
        BaseStatTotal += BaseAttack;
        BaseStatTotal += BaseDefense;
        BaseStatTotal += BaseSpecial;
        BaseStatTotal += BaseSpeed;
    }
}

public enum MonsterType
{
    NONE,
    NORMAL,
    FIGHTING,
    FLYING,
    POISON,
    GROUND,
    ROCK,
    BUG,
    STEEL,
    FIRE,
    WATER,
    GRASS,
    ELECTRIC,
    PSYCHIC,
    ICE,
    DRAGON,
    DARK,
    FAIRY,
    GHOST
}

public enum MonsterExpGroup
{
    NONE,
    FAST,
    MEDIUMFAST,
    MEDIUMSLOW,
    SLOW
}

//This'll just be guess work since I couldn't find any rules online
//regarding this.
public enum BodyType
{
    BIPEDAL,
    FLYING,
    WATER,
    FAIRY,
    GRASS,
    BUG,
    DRAGON,
    QUADRUPED
}

[Serializable]
public class LearnedMove
{
    public short LevelLearned;
    public MonsterMove Move;

    public LearnedMove(MonsterMove mv, short lvl)
    {
        Move = mv;
        LevelLearned = lvl;
    }
}
