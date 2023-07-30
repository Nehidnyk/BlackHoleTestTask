using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;

public class PointsUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText, totalScoreText, currentScoreText;
    [SerializeField] private Vector3 startTextPosition;
    [SerializeField] private Vector3 finalTextPosition;
    [SerializeField] private float moveUpTime;
    [SerializeField] private float fadingTime;

    private UnityEngine.Color color;

    private void Start()
    {
        color = pointsText.color;
    }

    //public delegate void ResetScoreDelegate(int score1, int score2);

    //public ResetScoreDelegate resetTotalScoreDelegate, resetCurrentScoreDelegate;


    public void PointsAnimation(int pointsCount)//reset text position and change color alpha, because it is 0 after fading
    {
        LeanTween.cancel(pointsText.gameObject);
        pointsText.rectTransform.anchoredPosition = startTextPosition;
        pointsText.text = $"+{pointsCount}";

        color.a = 1;
        pointsText.color = color;

        AnimateText();
        TextFading();
    }

    public void ResetTotalScore(int totalScore, int scoreToFinish)
    {
        totalScoreText.text = $"{totalScore}/{scoreToFinish}";
    }

    public void ResetCurrentScore(int currentScore, int scoreToScale)
    {
        currentScoreText.text = $"{currentScore}/{scoreToScale}";
    }

    private void AnimateText()
    {
        LeanTween.move(pointsText.rectTransform, finalTextPosition, moveUpTime);
    }

    private void TextFading()
    {
        LeanTween.value(pointsText.gameObject, SetColor, 1, 0, fadingTime/2).setDelay(fadingTime/2);
    }

    private void SetColor(float alpha)
    {
        color.a = alpha;
        pointsText.color = color;
    }
}
