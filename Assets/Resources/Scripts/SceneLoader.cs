using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    
    void Awake()
    {
        EventManager.KnifeHitLooseZone.AddListener(EndGame);
    }
        
    void EndGame()
    {
        Debug.LogError("Вы проиграли");
    }
}
