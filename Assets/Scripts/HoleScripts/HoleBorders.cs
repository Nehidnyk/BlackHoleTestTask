using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBorders : MonoBehaviour
{
    [SerializeField] private float xMinBorder, xMaxBorder, yMinBorder, yMaxBorder;

    private void Update()
    {
        if(gameObject.transform.position.x + gameObject.transform.lossyScale.x > xMaxBorder)
        {
            gameObject.transform.position = new Vector3(xMaxBorder - gameObject.transform.lossyScale.x , transform.position.y, transform.position.z);
        }

        if (gameObject.transform.position.x - gameObject.transform.lossyScale.x < xMinBorder)
        {
            gameObject.transform.position = new Vector3(xMinBorder + gameObject.transform.lossyScale.x, transform.position.y, transform.position.z);
        }

        if (gameObject.transform.position.z + gameObject.transform.lossyScale.z > yMaxBorder)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, yMaxBorder- gameObject.transform.lossyScale.z);
        }

        if (gameObject.transform.position.z - gameObject.transform.lossyScale.z < yMinBorder)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, yMinBorder+ gameObject.transform.lossyScale.z);
        }
    }
}
