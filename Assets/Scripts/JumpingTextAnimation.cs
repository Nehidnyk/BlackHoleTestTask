using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpingTextAnimation : MonoBehaviour
{
    private RectTransform rectTransform;

    [SerializeField] private int highToMove;

    [SerializeField] private float timeToMoveUp, timeToMoveDown, timeBetweenAnimations;

    private System.Action EndOfAnimation;

    private Vector2 startPosition;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;

        EndOfAnimation += () => { if (rectTransform.gameObject.active) { StartCoroutine(JumpingAnimation()); } };

        StartCoroutine(JumpingAnimation());
    }

    private IEnumerator JumpingAnimation()
    {
        yield return new WaitForSeconds(timeBetweenAnimations);
        MoveUp();
    }

    private void MoveUp()
    {
        LeanTween.move(rectTransform, rectTransform.anchoredPosition + new Vector2(0, highToMove), timeToMoveUp).setOnComplete(MoveDown).setEase(LeanTweenType.easeInOutCubic);
    }

    private void MoveDown()
    {
        LeanTween.move(rectTransform, startPosition, timeToMoveDown).setEase(LeanTweenType.easeOutBounce).setOnComplete(() => { EndOfAnimation?.Invoke(); });

    }
}
