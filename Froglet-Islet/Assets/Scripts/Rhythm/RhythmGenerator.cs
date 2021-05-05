using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RhythmPreset
{
    [Range(40, 250)]
    public int tempo = 120;
    public Subdivision subdivision;
    public LowestNote lowestNote;
    public string rhythm;
}

public class RhythmGenerator : MonoBehaviour
{
    public List<RhythmPreset> tutorialRhythms;
    public List<RhythmPreset> easyRhythms;
    public List<RhythmPreset> normalRhythms;
    public List<RhythmPreset> hardRhythms;
    public List<RhythmPreset> expertRhythms;

    public RhythmPreset Generate(RhythmDifficulty diff)
    {
        switch (diff)
        {
            default:
                return tutorialRhythms[Random.Range(0, tutorialRhythms.Count)];
            case RhythmDifficulty.Easy:
                return easyRhythms[Random.Range(0, easyRhythms.Count)];
            case RhythmDifficulty.Normal:
                return normalRhythms[Random.Range(0, normalRhythms.Count)];
            case RhythmDifficulty.Hard:
                return hardRhythms[Random.Range(0, hardRhythms.Count)];
            case RhythmDifficulty.Expert:
                return expertRhythms[Random.Range(0, expertRhythms.Count)];
        }
    }
}
