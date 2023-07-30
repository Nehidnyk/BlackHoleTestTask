using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingAbsorbing : MonoBehaviour
{
    private Collider myCollider;
    [SerializeField] private float force = 10;

    public delegate void AbsorbThingDelegate(GoodThing thing);
    public event AbsorbThingDelegate AbsorbGoodThingEvent;
    public event System.Action AbsorbBadThingEvent;
    public event System.Action AbsorbCoinsEvent;


    private void Start()
    {
        myCollider = GetComponent<Collider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (myCollider.bounds.Contains(other.bounds.min)
             && myCollider.bounds.Contains(other.bounds.max))
        {
            if(other.CompareTag("GoodThing"))
            {
                AbsorbThing(other);
                GoodThing thing = other.gameObject.GetComponent<GoodThing>();
                thing.GetAbsorbed();
                AbsorbGoodThingEvent?.Invoke(thing);
                other.gameObject.tag = "AbsorbedThing";

            }
            else if(other.CompareTag("BadThing"))
            {
                AbsorbThing(other);
                AbsorbBadThingEvent?.Invoke();
                BadThing thing = other.gameObject.GetComponent<BadThing>();
                thing.GetAbsorbed();
                other.gameObject.tag = "AbsorbedThing";

            }
            else if(other.CompareTag("Human"))
            {
                AbsorbThing(other);
                Character thing = other.GetComponent<Character>();
                thing.GetAbsorbed();
                AbsorbGoodThingEvent?.Invoke(thing);
                other.gameObject.tag = "AbsorbedThing";
            }
            else if (other.CompareTag("Coins"))
            {
                AbsorbThing(other);
                Thing thing = other.GetComponent<Thing>();
                thing.GetAbsorbed();
                AbsorbCoinsEvent?.Invoke();
                other.gameObject.tag = "AbsorbedThing";
            }
        }
    }

    private void AbsorbThing(Collider other)
    {
        other.isTrigger = true;
        other.gameObject.transform.parent = this.gameObject.transform;

        Vector3 direction = transform.position - other.transform.position;
        direction.y = -2;

        other.gameObject.GetComponent<Rigidbody>().AddForce(direction * force);


    }
}
