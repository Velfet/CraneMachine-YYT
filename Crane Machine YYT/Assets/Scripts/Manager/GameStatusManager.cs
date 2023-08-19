using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameStatusManager : Singleton<GameStatusManager>
{
    [SerializeField] private int CurrentScore;
    [SerializeField] private ScoreText HighScoreText;
    [SerializeField] private ScoreText CurrentScoreText;
    [Space(20)]
    [SerializeField] private FoodItemPooler FoodItemPooler;
    
    private MasterPlayerData MasterPlayerData;

    private void Start()
    {
        GetReferences();
        UpdateHighScoreInstant();
        UpdateScoreInstant();
    }

    public void UpdateScore(int addedScore)
    {
        CurrentScore += addedScore;
        CurrentScoreText.BeginTransition(CurrentScore);
        
        //Update high score if current score is higher than previous high score
        if(CurrentScore > MasterPlayerData.GetPlayerHighScore())
        {
            MasterPlayerData.SetPlayerHighScore(CurrentScore);
            UpdateHighScore();
        }
    }

    private void UpdateScoreInstant()
    {
        CurrentScoreText.UpdateUIInstant(CurrentScore);
    }

    private void UpdateHighScore()
    {
        HighScoreText.BeginTransition(MasterPlayerData.GetPlayerHighScore());
    }
    private void UpdateHighScoreInstant()
    {
        HighScoreText.UpdateUIInstant(MasterPlayerData.GetPlayerHighScore());
    }

    public FoodItemPooler GetFoodItemPooler()
    {
        return FoodItemPooler;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void GetReferences()
    {
        if(MasterPlayerData == null)
        {
            MasterPlayerData = MasterPlayerData.masterPlayerData;
        }
    }
}
