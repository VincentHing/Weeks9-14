using UnityEngine;

public class textshow : MonoBehaviour
{
    //positions for being on screen and off screen, shown here for clarity
    Vector3 onScreen = new Vector3(0, 3.72f, 0);
    Vector3 offScreen = new Vector3(0, 7.72f, 0);
    float clock = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       clock += Time.deltaTime;
        if (clock > 3)
        {
            transform.position = offScreen;
        }
        else
        {
            transform.position = onScreen;
        }

    }

    public void ShowUs()
    { 
        clock = 0;
    }

}

