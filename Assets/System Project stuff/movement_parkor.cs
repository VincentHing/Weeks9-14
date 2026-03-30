using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System.Collections;

public class movement_parkor : MonoBehaviour
{
    public float speed=5;
    public Vector2 movementModif;
    public bool animPlaying=false;
    UnityEvent Parkors = new UnityEvent();

    //temporarily holds the transform so i can mess around with it easier
    public Vector3 position;

    //for getting the stuff from text show so we can call it's function
    public GameObject oob;
    public textshow scrpt;

    Coroutine currentCo;
   
    void Start()
    {
        //adding stuff to the unity event 
        Parkors.AddListener(ParkorAction);
        Parkors.AddListener(TextMiddleMan);
        //getting access to the other script
        scrpt = oob.GetComponent<textshow>();

        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
       
        //normal movement along x
       
        position.x += movementModif.x * speed * Time.deltaTime;

        //exiting coroutine if you get off the wall
        if (animPlaying = true && position.x < 1f && position.y > -1.6)
        {
            //stops animation and coroutine and moves to ground
            animPlaying = false;
           StopCoroutine(currentCo);
            position.y = -2.59f;
        }

        //making sure the player isn't  up top
        if (position.y<0)
        {
            if (position.x > 1.48)
            {
                //cap x if going through wall
                position.x = 1.48f;
            }
        }
        //makes sure the player isn't on the bottom
        if (position.y > 0)
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
            /* somthing about the way i coded the movement along with specifically
             using a keyboard for this makes you continuously move in one direction after you've pressed it
            i could fix this but that would take time and isn't what this project is about (press up/w to stop moving) */
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
       
        if (animPlaying==false)
        {
            animPlaying = true;
            //are you within walclimb range
            if(position.x <= 1.48f && position.x > 1f)
            {
                //warp to wall
                position.x = 1.48f;
                //start wallclimb animation
                currentCo = StartCoroutine(Wallclimb());
            }
            else
            {

                //call the backflip function
            }
        }
    }

    IEnumerator Wallclimb()
    {

        
        //horizontally move (after)
        while (position.x <= 2.5)
        {
            
            //vertically move untill finished
            while (position.y <= 0.88)
            {
                
                //move up then wait till next
                position.y += 0.2f;
                yield return null;

                
            }
            //move to the side and wait till next
            position.x += 0.2f;
            yield return null;
        }
        //turn off anim and leave
        animPlaying = false;
        yield return null;
    }
    public void TextMiddleMan()
    {
        scrpt.ShowUs();

    }
    
}
