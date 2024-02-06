using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    [SerializeField] Text scoreGoldText;
    [SerializeField] Text scoreIronText;

    public int gameScoreGold = 0;
    public int gameScoreIron = 0;

    void Start()
    {
        scoreGoldText.text = gameScoreGold.ToString();
        scoreIronText.text = gameScoreIron.ToString();
    }

    public void AddToScoreGold(int pointsToAdd)
    {
        gameScoreGold += pointsToAdd;
        scoreGoldText.text = gameScoreGold.ToString();
    }

    public void AddToScoreIron(int pointsToAdd)
    {
        gameScoreIron += pointsToAdd;
        scoreIronText.text = gameScoreIron.ToString();
    }

    public int GetGold()
    {
        return gameScoreGold;
    }

    public int GetIron()
    {
        return gameScoreIron;
    }
}
