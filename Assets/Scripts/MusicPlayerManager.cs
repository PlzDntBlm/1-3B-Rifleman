using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerManager : MonoBehaviour
{
    private static MusicPlayerManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
