using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton fromat that is applied to other scripts
public abstract class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    public static T instance;

    protected virtual void Awake()
    {
        // create the instance
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
