using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    public virtual void GetAbsorbed()
    {
        StartCoroutine(WaitToDisableThing());
    }

    protected IEnumerator WaitToDisableThing()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
