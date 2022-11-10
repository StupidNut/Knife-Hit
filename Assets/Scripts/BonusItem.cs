using UnityEngine;

public class BonusItem : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        collisionObject.transform.parent = null;
        Debug.Log("+1");
        DestroyBonusItem();
    }

    private void DestroyBonusItem()
    {
       Destroy(transform.gameObject);
    }
  
}
