using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedPlayerData
{
    public int PlayerHighScore;

    public SavedPlayerData(MasterPlayerData mPD)
    {
        PlayerHighScore = mPD.GetPlayerHighScore();
    }
}
