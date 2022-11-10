using UnityEngine;

public class KnifeThrower : MonoBehaviour
{

    [SerializeField] private float force;

    [SerializeField] private int knifeCount;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Knife knifePrefab;
    private Knife knife;

    private MonoPool<Knife> knifePool;

    private void Start()
    {
        this.knifePool = new MonoPool<Knife>(this.knifePrefab, this.knifeCount, this.transform);
        this.knifePool.autoExpand = this.autoExpand;
        CreateNewKnife();
    }

    private void CreateNewKnife()
    {
        knife = this.knifePool.GetFreeElement();
        knife.transform.position = transform.position;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            knife.transform.parent = transform;
            knife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);

            CreateNewKnife();
        }
    }
}
