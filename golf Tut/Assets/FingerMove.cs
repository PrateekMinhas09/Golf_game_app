using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 


public class FingerMove : MonoBehaviour
{
    public bool allowMove = false;
    public LayerMask spherelayer;
    public GameObject EmptyObj;
    public float distance;
    public Rigidbody sphrb;
   public float forceMul = 0.0275f;
    Vector2 initTouchPos;
    public  Vector2 DirNormalized;
    public float Distance;
    public bool canMove= true;
    public GameObject Arrow;
    public float ScaleMulArrow = 0.1f;
    public float angle;
    private void Update()
    {


       

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                     initTouchPos = touch.position;
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit hit;
                    Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
                    if (Physics.Raycast(ray, out hit,spherelayer))
                    {
                        Debug.Log(hit.transform.name);
                        if (hit.collider.tag == "sphere")
                        {

                            
                            Debug.Log("Sphere Touched");

                           


                            allowMove = true;

                        }
                    }
                    break;
                case TouchPhase.Moved:
                    if (allowMove)
                    {
                        Vector2 direction = (touch.position - initTouchPos);
                        
                        

                        DirNormalized = direction / direction.magnitude;
                        
                 }
                    break;

                case TouchPhase.Ended:
                    
                     Distance = Vector2.Distance(touch.position, initTouchPos);
                    Movement(DirNormalized, Distance);
                   
                    break;

            }
            
            checkVel();
        }
    }

  
    public void Movement(Vector2 dir ,float dis )
    {
        if (canMove && Input.GetTouch(0).phase == TouchPhase.Ended&& allowMove== true)
        {
            Vector3 scapeGoat;
            scapeGoat.x = dir.x;
            scapeGoat.y = 0;
            scapeGoat.z = dir.y;

            sphrb.velocity = -scapeGoat * dis * forceMul;
            canMove = false;
            allowMove = false;
            
        }
        
        
    }
    void checkVel()
    {
       
        if(sphrb.velocity == Vector3.zero)
        {
            canMove = true;
            
        }
    }
   
}



