using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MonoPool<T> where T : MonoBehaviour
{
    [SerializeField] private T objectPrefab { get; }
    public bool autoExpand { get; set; }
    [SerializeField] Transform objectContainer { get; }
    private List<T> objectPool;

    [SerializeField] private int maxObjectCount;
    
    void Start()
    {
        //CreateStartKnife();
    }

    public MonoPool(T Prefab, int count, Transform Container)
    {
        this.objectPrefab = Prefab;
        this.objectContainer = Container;

        this.CreateObjectPool(count);
    }

    private void CreateObjectPool(int count)
    {
        this.objectPool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = UnityEngine.Object.Instantiate(this.objectPrefab, objectContainer);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this.objectPool.Add(createdObject);
        return createdObject;
    }

    private bool HasFreeElement(out T element)
    {
        foreach (var item in objectPool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (this.HasFreeElement(out var element))
        {
            return element;
        }
        if (this.autoExpand)
        {
            return this.CreateObject(true);
        }
        throw new Exception($"There is no free element in pool of type {typeof(T)}");
    }
}
