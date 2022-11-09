using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventManager : MonoBehaviour
{
    public static UnityEvent KnifeHitLooseZone = new UnityEvent();
    public static UnityEvent<GameObject> KnifeHitTarget = new UnityEvent<GameObject>();
    public static UnityEvent KnifeHitBonusZone = new UnityEvent();

    public static void SendKnifeHitLooseZone()
    {
        KnifeHitLooseZone?.Invoke();        
    }

    public static void SendKnifeHitBonusZone()
    {
        KnifeHitBonusZone?.Invoke();
    }

    public static void SendKnifeHitTarget(GameObject target) // получает Wood  в качестве объекта
    {
        KnifeHitTarget?.Invoke(target);
    }
}
