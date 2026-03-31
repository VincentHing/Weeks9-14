
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Vector2 ratPosition;
    public Vector2 ratPosition1;
    public bool clicked;
    public Vector3 temp1;
    public Vector3 temp2;
    public float timer;
    public float animationState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        // do not use for future refrence this does not work
    }

    // Update is called once per frame
    void Update()
    {
        
        if (clicked == true && transform.position.x != ratPosition1.x && transform.position.y != ratPosition1.y)
        {
            temp2 = Vector3.Lerp(temp1, ratPosition1, timer);
        }
        timer += Time.deltaTime/2;
        transform.position = temp2;
        if (transform.position.x == ratPosition1.x && transform.position.y == ratPosition1.y)
        {
            clicked = false;
        }
        //if (clicked != true)
        //{
        //    animationState = 0;
        //}
        //else if (transform.position.x > ratPosition1.x)
        //{

        //}
    }
    public void onPoint (InputAction.CallbackContext context)
    {
        ratPosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
    public void onClick (InputAction.CallbackContext context)
    {
        //get a shmove on
        clicked = true;
        temp1 = transform.position;
        timer = 0;
        ratPosition1 = ratPosition;
    }

}
