
using System.Collections;
using System.Collections.Generic;

public enum Alignment
{
    LAWFUL_GOOD,
    LAWFUL_NEUTRAL,
    LAWFUL_EVIL,
    NEUTRAL_GOOD,
    TRUE_NEUTRAL,
    NEUTRAL_EVIL,
    CHAOTIC_GOOD,
    CHAOTIC_NEUTRAL,
    CHAOTIC_EVIL
}

public enum CharacterClass
{
    CLERIC,
    DRUID,
    FIGHTER,
    PALADIN,
    RANGER,
    MAGICUSER,
    THIEF,
    MONK,
    CLERIC_FIGHTER,
    CLERIC_FIGHTER_MAGICUSER,
    CLERIC_RANGER,
    CLERIC_MAGICUSER,
    CLERIC_THIEF,
    FIGHTER_MAGICUSER,
    FIGHTER_THIEF,
    FIGHTER_MAGICUSER_THIEF,
    MONSTER
 
}

public enum Race
{
    INVALID,
    DWARF,
    ELF,
    GNOME,
    HALF_ELF,
    HALFING,
    HALF_ORC,
    HUMAN
}

public enum Gender
{
    MALE,
    FEMALE
}

public class CharacterModel
{
    private string name;
    private int age;
    private int maxHitPoints;
    private int currentHitPoints;

    private Gender gender;
    private Alignment alignment;
    private CharacterClass characterClass;
    private Race race;

    private int strength, intelligence, wisdom, dexterity, constitution, charisma;
    private int jewelry, gems, platinum, gold, electrum, silver, copper;
    private int experience;

    private List<KeyValuePair<CharacterClass, int>> levels;

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public Alignment Alignment { get => alignment; set => alignment = value; }
    public CharacterClass CharacterClass { get => characterClass; set => characterClass = value; }
    public Race Race { get => race; set => race = value; }
    public Gender Gender { get => gender; set => gender = value; }
    public int Strength { get => strength; set => strength = value; }
    public int Intelligence { get => intelligence; set => intelligence = value; }
    public int Wisdom { get => wisdom; set => wisdom = value; }
    public int Dexterity { get => dexterity; set => dexterity = value; }
    public int Constitution { get => constitution; set => constitution = value; }
    public int Charisma { get => charisma; set => charisma = value; }
    public List<KeyValuePair<CharacterClass, int>> Levels { get => levels; set => levels = value; }
    public int Experience { get => experience; set => experience = value; }
    public int Jewelry { get => jewelry; set => jewelry = value; }
    public int Gems { get => gems; set => gems = value; }
    public int Platinum { get => platinum; set => platinum = value; }
    public int Gold { get => gold; set => gold = value; }
    public int Electrum { get => electrum; set => electrum = value; }
    public int Silver { get => silver; set => silver = value; }
    public int Copper { get => copper; set => copper = value; }
    public int CurrentHitPoints { get => currentHitPoints; set => currentHitPoints = value; }
    public int MaxHitPoints { get => maxHitPoints; set => maxHitPoints = value; }
}
