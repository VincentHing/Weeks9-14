using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class movement_parkor : MonoBehaviour
{
    public float speed=5;
    public Vector2 movementModif;
    public bool animPlaying=false;
    UnityEvent Parkors = new UnityEvent();

    //temporarily holds the transform so i can mess around with it easier
    public Vector3 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Parkors.AddListener(ParkorAction);
    }

    // Update is called once per frame
    void Update()
    {
        //so you can't walk up
        movementModif.y = 0;
        //normal movement
        position = transform.position;
        position += (Vector3)movementModif * speed * Time.deltaTime;
       
        //making sure the player isn't doing somthing or up top
        if (animPlaying==false&&position.y<0)
        {
            if (position.x > 1.48)
            {
                //cap x if going through wall
                position.x = 1.48f;
            }
        }
        //makes sure the player isn't doing somthing or on the bottom
        if (animPlaying == false && position.y > 0)
        {
            if (position.x < 1.48)
            {
                //fall if over edge
                position.y = -2.59f;
            }
        }

        //send back the final numba'
        transform.position = position;

    }
    
    //this and update were mostly copied from the input system follow along in class
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed==true)
        {
            movementModif = context.ReadValue<Vector2>();
        }
       
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed==true)
        {
            Parkors.Invoke();
        }

    }

    public void ParkorAction()
    {
        if (!animPlaying)
        {
            animPlaying = true;
            //are you within walclimb range
            if(position.x <= 1.48f || position.x > 1f)
            {
                //call a walclimb function
            }
            else
            {
                //call the backflip function
            }
        }
    }
}
