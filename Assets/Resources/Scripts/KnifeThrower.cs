using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrower : MonoBehaviour
{

    [SerializeField] private float force;
    [SerializeField] private GameObject knifePrefab;
    private GameObject knife;

    void Start()
    {
        knife = Instantiate(knifePrefab, transform);
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            knife.transform.parent = null;
            knife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
            knife = Instantiate(knifePrefab, transform);
        }
    }
}
