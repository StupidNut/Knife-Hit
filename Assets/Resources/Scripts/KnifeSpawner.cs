using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{

    [SerializeField] private int maxKnifeCount;
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject knifeSpawn;
    private int currentKnife = 0;
    private GameObject knife;
    private List<GameObject> knifeList = new List<GameObject>();
    

    private void Awake()
    {
        //EventManager.KnifeTransport.AddListener(GiveKnife);
    }

    void Start()
    {
        while (knifeList.Count > 0)
        {
            Destroy(knifeList[0]);
            knifeList.RemoveAt(0);
        }
        for (int i = 0; i < maxKnifeCount; i++)
        {
            CreateNewKnife();
        }
        
        GiveKnife(knifeList[currentKnife]);
    }

    private void CreateNewKnife()
    {
        GameObject createKnife = Instantiate(knifePrefab, knifeSpawn.transform.position, Quaternion.identity);
        createKnife.transform.SetParent(transform);

        knifeList.Add(createKnife);
    }

    private void GiveKnife(GameObject givingItem)
    {
        //EventManager.SendKnifeTransport(givingItem);
        currentKnife++;
    }

    
}
