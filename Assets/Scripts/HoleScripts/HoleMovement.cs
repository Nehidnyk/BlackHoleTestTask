using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private IHoleInput holeInput;

    private void Start()
    {
        holeInput = FindObjectsOfType<MonoBehaviour>().OfType<IHoleInput>().First();
    }

    void Update()
    {
        MoveHole();

    }

    private Vector3 GetMovementDirection()
    {
        Vector3 direction = new Vector3(holeInput.Horizontal, 0, holeInput.Vertical).normalized;
        return direction;
    }

    private void MoveHole()
    {
        transform.Translate(GetMovementDirection() * speed * Time.deltaTime);
    }

}
