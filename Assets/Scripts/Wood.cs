using UnityEngine;
using System;

public class Wood : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] public LayerMask mainTargetMask;
    private Collider2D woodColaider;

    public static Action<Collider2D> HitMainTarget;

    private void Start()
    {
        woodColaider = GetComponent<Collider2D>();        
    }

    private void Update()
    {
        transform.Rotate(0, 0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.layer == (collisionObject.gameObject.layer | ( 1 << mainTargetMask))) 
        {
            collisionObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collisionObject.transform.parent = transform;
            HitMainTarget?.Invoke(woodColaider);
        }

    }

}
