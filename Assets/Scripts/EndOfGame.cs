using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfGame : MonoBehaviour
{
    [SerializeField] private GameObject failPanel, winPanel;

    private bool isEndOfGame;

    private void Update()
    {
        if (isEndOfGame && Input.GetMouseButtonDown(0)/*Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began*/)
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() != null)
                {
                    return;

                }
            }

            ReloadScene();
        }
    }

    public void OpenFinalPanel(bool isWin)
    {
        isEndOfGame = true;
        if(isWin)
        {
            winPanel.SetActive(true);
        }
        else
        {
            failPanel.SetActive(true);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
