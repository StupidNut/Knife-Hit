using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{

    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        EventManager.SendKnifeHitTarget(this.gameObject); //Передаем Wood в качестве объекта
    }
}
