using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Joystick joystick;
    private Animator ani;
    private CharacterController controller;
    public Vector3 speedx;
    public Vector3 speedz;
    private Touch inittouch = new Touch();
    public Camera cam;
    private float rotx = 0f;
    private float roty = 0f;
    private Vector3 origin;
    public float rotationspeed = 0.5f;
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        origin = cam.transform.eulerAngles;
        rotx = origin.x;
        roty = origin.y;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal > 0.2f){
            controller.Move(joystick.Horizontal*speedx*Time.deltaTime);
            ani.Play("walk");
            

        }
        if (joystick.Horizontal <- 0.2f)
        {
            controller.Move(joystick.Horizontal * speedx * Time.deltaTime);
            ani.Play("walk");

        }
        if (joystick.Vertical > 0.2f)
        {
            controller.Move(joystick.Vertical * speedz * Time.deltaTime);
            ani.Play("walk");
        }
        if (joystick.Vertical < -0.2f)
        {
            controller.Move(joystick.Vertical * speedz * Time.deltaTime);
            ani.Play("walk");
        }
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && touch.position.x>Screen.width/2 )
            {
                inittouch = touch;

            }
            else if (touch.phase == TouchPhase.Moved && touch.position.x > Screen.width / 2)
            {
                float deltax = inittouch.position.x - touch.position.x;
                float deltay = inittouch.position.y - touch.position.y;
                rotx -= deltax*Time.deltaTime*rotationspeed;
                roty += deltay * Time.deltaTime*rotationspeed;
                Mathf.Clamp(roty, -90f, 90f);
                cam.transform.eulerAngles = new Vector3(rotx, roty, 0);




            } 
            else if (touch.phase == TouchPhase.Ended)
            {
                inittouch = new Touch();
            }
            
        
        }
       
        
    }

}
