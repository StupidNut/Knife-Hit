using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventManager.KnifeHitBonusZone.AddListener(GetBonus);
    }

    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        EventManager.SendKnifeHitBonusZone();
    }

    private void GetBonus()
    {
        Debug.Log("+1");
        Destroy(gameObject);
    }
}
