using UnityEngine;

public class textshow : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MonoBehaviour localParkor = GetComponent<MonoBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        localParkor.TextMiddleMan();
    }
}
