using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private int pointsToFinish;
    [SerializeField] private int pointsToScale;
    public int TotalPoints { get; private set; }
    public int CurrentPoints { get; private set; }

    public event System.Action ScaleHoleEvent;
    public event System.Action FinishGameEvent;


    private ThingAbsorbing thingAbsorbing;
    private PointsUIController pointsUIController;

    private void Start()
    {
        thingAbsorbing = FindObjectOfType<ThingAbsorbing>();
        thingAbsorbing.AbsorbGoodThingEvent += AddPoints;

        pointsUIController = FindObjectOfType<PointsUIController>();

        pointsUIController.ResetTotalScore(TotalPoints, pointsToFinish);
        pointsUIController.ResetCurrentScore(CurrentPoints, pointsToScale);
    }



    public void AddPoints(GoodThing thing)
    {
        int points = thing.pointsCount;
        TotalPoints += points;
        CurrentPoints += points;

        CheckPointsToScale();
        CheckPointsToFinish();

        pointsUIController.PointsAnimation(points);
        pointsUIController.ResetTotalScore(TotalPoints, pointsToFinish);
        pointsUIController.ResetCurrentScore(CurrentPoints, pointsToScale);

    }

    private bool CheckPointsToScale()
    {
        if(CurrentPoints>=pointsToScale)
        {
            ScaleHoleEvent?.Invoke();
            CurrentPoints -= pointsToScale;
            pointsToScale *= 2;
            return true;
        }
        return false;
    }

    private bool CheckPointsToFinish()
    {
        if (TotalPoints >= pointsToFinish)
        {
            FinishGameEvent?.Invoke();
            return true;
        }
        return false;
    }
}
