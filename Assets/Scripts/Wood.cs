using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wood : MonoBehaviour
{

    [SerializeField] private float speed;    

    private void Start()
    {
       
    }

    private void Update()
    {
        transform.Rotate(0, 0, speed);
    }

}
