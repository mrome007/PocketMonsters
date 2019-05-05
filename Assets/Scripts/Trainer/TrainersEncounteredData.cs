using System;

/// <summary>
/// Trainers encountered data. This class will be used to
/// determine which trainers have already been encountered
/// in the game. According to some reasearch online there's about 300+
/// trainer battles. I'm going to figure out which trainers have been
/// encountered through bit masks.
/// </summary>
[Serializable]
public class TrainersEncounteredData
{
    public int FirstTrainerGroup;
    public int SecondTrainerGroup;
    public int ThirdTrainerGroup;
    public int FourhtTrainerGroup;
    public int FifthTrainerGroup;
    public int SixthTrainerGroup;
    public int SeventhTrainerGroup;
    public int EigthTrainerGroup;
    public int NinthTrainerGroup;
    public int TenthTrainerGroup;
    public int EleventhTrainerGroup;
    public int TwelfthTrainerGroup;
    public int ThirteenthTrainerGroup;
    public int FourteenthTrainerGroup;
    public int FifteenthTrainerGroup;

    public void Reset()
    {
        FirstTrainerGroup = 0;
        SecondTrainerGroup = 0;
        ThirdTrainerGroup = 0;
        FourhtTrainerGroup = 0;
        FifthTrainerGroup = 0;
        SixthTrainerGroup = 0;
        SeventhTrainerGroup = 0;
        EigthTrainerGroup = 0;
        NinthTrainerGroup = 0;
        TenthTrainerGroup = 0;
        EleventhTrainerGroup = 0;
        TwelfthTrainerGroup = 0;
        ThirteenthTrainerGroup = 0;
        FourteenthTrainerGroup = 0;
        FifteenthTrainerGroup = 0;
    }
}
