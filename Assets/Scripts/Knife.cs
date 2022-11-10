using UnityEngine;

public class Knife : MonoBehaviour
{

    [SerializeField] private Rigidbody2D knifeRigidbody;
    private bool attachedToWood;

    
    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.GetComponent<Knife>()?.attachedToWood == true)
        {
            knifeRigidbody.velocity = Vector2.down+Vector2.right;            
            knifeRigidbody.gravityScale = 2;
            transform.parent = null;
            attachedToWood = false;

            Debug.LogError("Вы проиграли"); // need to be transferred to scene loader after implementation
        }
        
        if (collisionObject.gameObject.layer == 6) // 6 - MainTarget layer
        {
            knifeRigidbody.velocity = Vector2.zero;
            transform.parent = collisionObject.transform;
            attachedToWood = true;            
        }
                
    }

}
