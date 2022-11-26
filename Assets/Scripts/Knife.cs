using UnityEngine;

public class Knife : MonoBehaviour
{

    [SerializeField] public Rigidbody2D knifeRigidbody;
    [SerializeField] public LayerMask knifeMask;
    private Collider2D knifeColaider;
    public bool attachedToWood;


    private void Start()
    {      
        knifeColaider = GetComponent<Collider2D>();
        Wood.HitMainTarget += HittingTarget;
    }


    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.GetComponent<Knife>()?.attachedToWood == true)
        {
            knifeColaider.isTrigger = false;
            attachedToWood = false;

            knifeRigidbody.velocity = Vector2.down+Vector2.right;            
            knifeRigidbody.gravityScale = 2;
            transform.parent = null;

            Debug.Log("Вы проиграли"); // need to be transferred to scene loader after implementation
        }       
    }

    private void HittingTarget(Collider2D target)
    {
        //knifeRigidbody.velocity = Vector2.zero;
        //transform.parent = target.transform;
        attachedToWood = true;        
    }

}
