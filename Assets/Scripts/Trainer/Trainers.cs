﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Trainers
{
    private static Dictionary<PartyTrainer, string> trainerNames = new Dictionary<PartyTrainer, string>() 
    { 
        { PartyTrainer.LORELEI, "Lorelei" },
        { PartyTrainer.BRUNO, "Bruno" },
        { PartyTrainer.AGATHA, "Agatha" },
        { PartyTrainer.LANCE, "Lance" },
        { PartyTrainer.BLUE, "Blue" },
        { PartyTrainer.OAK, "Oak" },
        { PartyTrainer.BROCK, "Brock" },
        { PartyTrainer.MISTY, "Misty" },
        { PartyTrainer.LTSURGE, "Lt. Surge" },
        { PartyTrainer.ERIKA, "Erika" },
        { PartyTrainer.KOGA, "Koga" },
        { PartyTrainer.SABRINA, "Sabrina" },
        { PartyTrainer.BLAINE, "Blaine" },
        { PartyTrainer.GIOVANNI, "Giovanni" },
        { PartyTrainer.RED, "Red" },
        { PartyTrainer.BEAUTY, "Beauty" },
        { PartyTrainer.BIKER, "Biker" },
        { PartyTrainer.BIRDKEEPER, "Bird Keeper" },
        { PartyTrainer.BLACKBELT, "Black Belt" },
        { PartyTrainer.BUGCATCHER, "Bug Catcher" },
        { PartyTrainer.BURGLAR, "Burglar" },
        { PartyTrainer.CHANNELER, "Channeler" },
        { PartyTrainer.COOLTRAINERM, "Cool Trainer M" },
        { PartyTrainer.COOLTRAINERF, "Cool Trainer F" },
        { PartyTrainer.ENGINEER, "Engineer" },
        { PartyTrainer.FISHERMAN, "Fisherman" },
        { PartyTrainer.GAMBLER, "Gambler" },
        { PartyTrainer.GENTLEMAN, "Gentleman" },
        { PartyTrainer.HIKER, "Hiker" },
        { PartyTrainer.JRTRAINERM, "Jr. Trainer M" },
        { PartyTrainer.JRTRAINERF, "Jr. Trainer F" },
        { PartyTrainer.LASS, "Lass" },
        { PartyTrainer.YOUNGSTER, "Youngster" },
        { PartyTrainer.POKEMANIAC, "Poké Maniac" },
        { PartyTrainer.PSYCHIC, "Psychic" },
        { PartyTrainer.ROCKER, "Rocker" },
        { PartyTrainer.SAILOR, "Sailor" },
        { PartyTrainer.CUEBALL, "Cue Ball" },
        { PartyTrainer.SCIENTIST, "Scientist" },
        { PartyTrainer.SUPERNERD, "Super Nerd" },
        { PartyTrainer.JUGGLER, "Juggler" },
        { PartyTrainer.SWIMMER, "Swimmer" },
        { PartyTrainer.TAMER, "Tamer" },
        { PartyTrainer.ROCKET, "Rocket" }
    };

    public static string GetTrainerName(PartyTrainer trainer)
    {
        if(!trainerNames.ContainsKey(trainer))
        {
            return "";
        }

        return trainerNames[trainer];
    }
}

public enum PartyTrainer
{
    NONE,
    LORELEI,
    BRUNO,
    AGATHA,
    LANCE,
    BLUE,
    OAK,
    BROCK,
    MISTY,
    LTSURGE,
    ERIKA,
    KOGA,
    SABRINA,
    GIOVANNI,
    BLAINE,
    RED,
    BEAUTY,
    BIKER,
    BIRDKEEPER,
    BLACKBELT,
    BUGCATCHER,
    BURGLAR,
    CHANNELER,
    COOLTRAINERM,
    COOLTRAINERF,
    ENGINEER,
    FISHERMAN,
    GAMBLER,
    GENTLEMAN,
    HIKER,
    JRTRAINERM,
    JRTRAINERF,
    LASS,
    YOUNGSTER,
    POKEMANIAC,
    PSYCHIC,
    ROCKER,
    SAILOR,
    CUEBALL,
    SCIENTIST,
    SUPERNERD,
    JUGGLER,
    SWIMMER,
    TAMER,
    ROCKET
}
