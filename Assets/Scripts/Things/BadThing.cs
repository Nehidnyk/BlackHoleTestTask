using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadThing : Thing
{
    [SerializeField] private ParticleSystem explosion;

    public override void GetAbsorbed()
    {
        base.GetAbsorbed();
        explosion.Play();
    }
}
