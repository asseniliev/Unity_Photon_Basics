using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager eventManager;

    public delegate void damageHandler(string target, int damage);
    public event damageHandler makeDamage;

    private void Awake()
    {
        if(EventManager.eventManager == null)
        {
            EventManager.eventManager = this;
        }
        else
        {
            if(EventManager.eventManager != this)
            {
                Destroy(EventManager.eventManager.gameObject);
                EventManager.eventManager = this;
            }
        }
    }

    public void CallMakeDamageEvent(string target, int damage)
    {
        makeDamage?.Invoke(target, damage);
    }
}
