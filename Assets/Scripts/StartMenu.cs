using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject startMenuPanel;

    private GameManager  gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)/*Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began*/)
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() != null)
                {
                    return;

                }
            }

            startMenuPanel.SetActive(false);
            gameManager.StartGame();
            this.enabled = false;
        }
    }
}
