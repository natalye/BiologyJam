using UnityEngine;
using System.Collections;


public class DontDestroyObject : MonoBehaviour {
    private static DontDestroyObject instance = null;
    public static DontDestroyObject Instance
    {
        get { return instance; }
    }
    void Awake() {
     if (instance != null && instance != this) {
         Destroy(this.gameObject);
         return;
     } else {
         instance = this;
     }
     DontDestroyOnLoad(this.gameObject);
 }
}
