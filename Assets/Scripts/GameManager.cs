using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ThingAbsorbing thingAbsorbing;
    private EndOfGame endOfGame;
    private PointsManager pointsManager;
    private HoleMovement holeMovement;
    [SerializeField] private GameObject gamePlayPanel;

    private void Start()
    {
        thingAbsorbing = FindObjectOfType<ThingAbsorbing>();
        thingAbsorbing.AbsorbBadThingEvent += FailGame;

        pointsManager = FindObjectOfType<PointsManager>();
        pointsManager.FinishGameEvent += WinGame;

        endOfGame = FindObjectOfType<EndOfGame>();

        holeMovement = FindObjectOfType<HoleMovement>();
        holeMovement.enabled = false;
    }

    public void StartGame()
    {
        gamePlayPanel.SetActive(true);
        holeMovement.enabled = true;
    }

    private void WinGame()
    {
        gamePlayPanel.SetActive(false);
        endOfGame.OpenFinalPanel(true);
        holeMovement.enabled=false;
    }

    private void FailGame()
    {
        gamePlayPanel.SetActive(false);
        endOfGame.OpenFinalPanel(false);
        holeMovement.enabled = false;

    }
}
