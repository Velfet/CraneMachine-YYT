using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterPlayerData : MonoBehaviour
{
    [SerializeField] private int PlayerHighScore;

    public static MasterPlayerData masterPlayerData;

    private AudioManager audioManager;

    private void Awake()
    {
        SavedPlayerData loadedData = SaveSystem.LoadData();
        if(loadedData != null)
        {
            PlayerHighScore = loadedData.PlayerHighScore;
        }
        else
        {
            //No save data found, setting value to default
            PlayerHighScore = 0;
        }

        if(masterPlayerData != null)
        {
            if(masterPlayerData != this)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            masterPlayerData = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        UpdateVolume(0.2f, 0.1f);
        //Play bgm
        audioManager.PlayBGM(MyEnum.Sound_BGM.BGM1);
    }

    public int GetPlayerHighScore()
    {
        return PlayerHighScore;
    }

    public void SetPlayerHighScore(int newScore)
    {
        //Updates high score if new score is higher than previous high score
        if(newScore > PlayerHighScore)
        {
            PlayerHighScore = newScore;
            SaveData();
        }
    }

    public void UpdateVolume(float newSfxVol, float newBgmVol)
    {
        if(audioManager == null)
        {
            audioManager = AudioManager.audioManager;
        }

        audioManager.UpdateSFXVolume(newSfxVol);
        audioManager.UpdaetBGMVolume(newBgmVol);
    }

    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }
}
