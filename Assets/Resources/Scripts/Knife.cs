using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    [SerializeField] private Rigidbody2D knifeRigidbody;
    private bool attachedToWood;

    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.tag == "Wood")
        {
            knifeRigidbody.velocity = Vector2.zero;
            transform.parent = collisionObject.transform;
            attachedToWood = true;
        }

        if (collisionObject.tag == "Knife")
        {
            if (collisionObject.GetComponent<Knife>().attachedToWood == true)
            {
                knifeRigidbody.velocity = Vector2.zero;
                knifeRigidbody.gravityScale = 1;
                
                Debug.LogError("Вы проиграли");
            }
            
        }

        if (collisionObject.tag == "BonusItem")
        {
            Destroy(collisionObject.gameObject);
        }
    }
    
}
