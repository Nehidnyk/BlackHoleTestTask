using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Drawing;

public class CoinsUIController : MonoBehaviour
{
    [SerializeField] private List<Image> coinImages;

    [SerializeField] private Vector2 centralPosition;
    [SerializeField] private int width, height;

    [SerializeField] private float timeBetweenCoins, timeToMove, fadingTime;

    [SerializeField] private Image mainCoinImage;
    private Vector2 finalPosition;

    [SerializeField] private TextMeshProUGUI coinsText, addCoinsText;

    [SerializeField] private GameObject hole;

    System.Random random = new System.Random();

    private void Start()
    {
        finalPosition = mainCoinImage.rectTransform.position;
        centralPosition = Camera.main.WorldToScreenPoint(hole.transform.position);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            PlayAnimation();
        }
    }

    public void PlayAnimation()
    {
        SpawnCoins();
        StartCoroutine(MoveCoins());
    }

    public void ResetCoinsText(int coinsCount)
    {
        coinsText.text = coinsCount.ToString();
    }

    public void AddCoinsTextAnimation(int coinsToAdd)
    {
        addCoinsText.text = $"+{coinsToAdd}";
        FadeTextUp();
    }

    private void SpawnCoins()
    {
        centralPosition = Camera.main.WorldToScreenPoint(hole.transform.position);
        for (int i = 0; i<coinImages.Count; i++)
        {
            int x = random.Next((int)centralPosition.x - width, (int)centralPosition.x + width);
            int y = random.Next((int)centralPosition.y - height, (int)centralPosition.y + height);

            coinImages[i].rectTransform.position = new Vector2(x, y);
            coinImages[i].gameObject.SetActive(true);
        }
    }

    IEnumerator MoveCoins()
    {
        foreach(Image coinImage in coinImages)
        {
            yield return new WaitForSeconds(timeBetweenCoins);
            MoveCoin(coinImage);
        }
    }

    private void MoveCoin(Image coinImage)
    {
        LeanTween.move(coinImage.gameObject, finalPosition, timeToMove).setOnComplete(() => { coinImage.gameObject.SetActive(false); });
    }

    private void FadeTextUp()
    {
        LeanTween.value(addCoinsText.gameObject, SetColor, 0, 1, fadingTime).setOnComplete(FadeTextDown);

    }

    private void FadeTextDown()
    {
        LeanTween.value(addCoinsText.gameObject, SetColor, 1, 0, fadingTime);

    }

    private void SetColor(float alpha)
    {
        UnityEngine.Color color = addCoinsText.color;
        color.a = alpha;
        addCoinsText.color = color;
    }
}
