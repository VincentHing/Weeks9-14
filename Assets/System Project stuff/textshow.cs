using UnityEngine;

public class textshow : MonoBehaviour
{
    //positions for being on screen and off screen, shown here for clarity
    Vector3 onScreen = new Vector3(0, 3.72f, 0);
    Vector3 offScreen = new Vector3(0, 7.72f, 0);
    public float clock = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //make time move
       clock += Time.deltaTime;
        //if it's outside the alloted time it's off screen, if not it's on
        if (clock > 0.5f)
        {
            transform.position = offScreen;
        }
        else
        {
            transform.position = onScreen;
        }
       
    }

    public void ShowUs()
    { //sets the timer so the text is on screen for about 2 seconds
        clock = 0;
    }

}

