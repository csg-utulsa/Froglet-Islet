﻿//made by Sam Locicero

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LowestNote
{
    [Range(-11, 11)]
    public int noteOffset = 0;
    [Range(2,6)]
    public int octave = 4;
}
public enum Subdivision { Quarter, Eighth, Sixteenth, Triplet }

[System.Serializable]
public class Rhythm
{
    [Range(40, 250)]
    public int tempo = 120;
    public Subdivision subdivision;
    public LowestNote lowestNote;
    public string rhythm;
}
