using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScaler : MonoBehaviour
{
    [SerializeField] private float scaleMultiplier;

    [SerializeField] private CinemachineVirtualCamera camera;
    private CinemachineTransposer transposer;

    private PointsManager pointsManager;

    private Vector3 startOffset;

    private void Start()
    {
        pointsManager = FindObjectOfType<PointsManager>();
        pointsManager.ScaleHoleEvent += ScaleHole;

        transposer = camera.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void ScaleHole()
    {
        LeanTween.scale(gameObject, gameObject.transform.localScale * scaleMultiplier, 0.3f);
        ChangeCameraOffset();
    }

    private void ChangeCameraOffset()
    {
        startOffset = transposer.m_FollowOffset;
        LeanTween.value(camera.gameObject, SetOffset, 1, scaleMultiplier, 1);
    }

    private void SetOffset(float offsetMultiplier)
    {
        transposer.m_FollowOffset = startOffset * offsetMultiplier;
    }
}
