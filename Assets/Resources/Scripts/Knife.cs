using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    [SerializeField] private Rigidbody2D knifeRigidbody;
    private bool attachedToWood;

    private void Awake()
    {
        EventManager.KnifeHitTarget.AddListener(HitTarget); // �������� ����� Wood ��� ������������ �� ������� � �������� Wood  � ����� 
    }

    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.GetComponent<Knife>()?.attachedToWood == true)
        {
            EventManager.SendKnifeHitLooseZone();
            knifeRigidbody.velocity = Vector2.zero;           
            knifeRigidbody.gravityScale = 3;            
        }        
    }

    private void HitTarget(GameObject gameObject)
    {
        knifeRigidbody.velocity = Vector2.zero;
        this.knifeRigidbody.transform.parent = gameObject.transform; // ������ ������ knife �������� � ������� Wood
        attachedToWood = true;

    }

}
