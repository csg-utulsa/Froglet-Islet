//made by Sam Locicero

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RhythmDifficulty
{ Tutorial, Easy, Normal, Hard, Expert }

public enum Subdivision
{ Quarter, Eighth, Sixteenth, Triplet }


[System.Serializable]
public class LowestNote
{
    [Range(-11, 11)]
    public int noteOffset = 0;
    [Range(2,6)]
    public int octave = 4;
}


[System.Serializable]
public class Rhythm
{
    public RhythmDifficulty rhythmDifficulty;
    public bool hasBeenGenerated = false;

    [Range(40, 250)]
    [HideInInspector]
    public int tempo = 120;
    [HideInInspector]
    public Subdivision subdivision;
    [HideInInspector]
    public LowestNote lowestNote;
    [HideInInspector]
    public string rhythm;

    public Rhythm(RhythmPreset preset)
    {
        hasBeenGenerated = true;
        tempo = preset.tempo;
        subdivision = preset.subdivision;
        lowestNote = preset.lowestNote;
        rhythm = preset.rhythm;
    }
    
}
