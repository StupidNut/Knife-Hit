using UnityEngine;

public class Wood : MonoBehaviour
{

    [SerializeField] private float speed;    
        
    private void Update()
    {
        transform.Rotate(0, 0, speed);
    }

}
