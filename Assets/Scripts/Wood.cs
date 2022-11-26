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
        if (collisionObject.gameObject.layer == (collisionObject.gameObject.layer | ( 1 << mainTargetMask))) //LayerMask.NameToLayer("MainTarget") ) // 7 - KnifeMask layer ((layerMask.value & (1 << collider.transform.gameObject.layer)) > 0)
        {
            HitMainTarget?.Invoke(woodColaider);           
        }

    }

}
