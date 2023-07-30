using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public int CoinsCount { get; private set; }

    [SerializeField] private int minCoinsToAdd, maxCoinsToAdd;

    private ThingAbsorbing thingAbsorbing;
    private CoinsUIController coinsUIController; 

    System.Random random = new System.Random();

    private void Start()
    {
        thingAbsorbing = FindObjectOfType<ThingAbsorbing>();
        thingAbsorbing.AbsorbCoinsEvent += AddCoins;

        coinsUIController = FindObjectOfType<CoinsUIController>();

        GetCoins();
        coinsUIController.ResetCoinsText(CoinsCount);

    }

    private void AddCoins()
    {
        int coinsToAdd = random.Next(minCoinsToAdd, maxCoinsToAdd);
        CoinsCount += coinsToAdd;
        coinsUIController.PlayAnimation();
        coinsUIController.ResetCoinsText(CoinsCount);
        coinsUIController.AddCoinsTextAnimation(coinsToAdd);
        SaveCoins();
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", CoinsCount);
    }

    private void GetCoins()
    {
        CoinsCount = PlayerPrefs.GetInt("Coins", 0);
    }
}
