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
    float forceMul = 0.15f;
    Vector2 initTouchPos;
    Vector2 DirNormalized;
    public bool canMove= true;
    private void Update()
    {


        /* if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
         {
             Vector3 initTouchPos =  Input.GetTouch(0).position;
             Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
             RaycastHit hit;
             Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
             if (Physics.Raycast(ray, out hit))
             {
                 Debug.Log(hit.transform.name);
                 if (hit.collider.tag == "sphere")
                 {

                     // GameObject touchedObject = hit.transform.gameObject;
                     EmptyObj.transform.position = hit.transform.gameObject.transform.position;
                     Debug.Log(EmptyObj.transform.position);


                     allowMove = true;
                     if(Input.GetTouch(0).phase == TouchPhase.Moved && allowMove== true)
                     {
                         Debug.Log("inside MOved");
                         if(Input.GetTouch(0).phase == TouchPhase.Ended)
                         {
                             Debug.Log("inside ended");
                             Vector3 finalPos = Input.GetTouch(0).position;
                             distance = CalculateDist(initTouchPos, finalPos);
                            Vector3 Dir =  CalculateDir(initTouchPos, finalPos);
                             Movement(Dir, distance);
                         }

                     }



                     Debug.Log("Touched " + EmptyObj.transform.name);
                 }
             }
         }*/

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

                            // GameObject touchedObject = hit.transform.gameObject;
                            Debug.Log("Sphere Touched");

                            // Debug.Log(EmptyObj.transform.position);


                            allowMove = true;

                        }
                    }
                    break;
                case TouchPhase.Moved:
                    if (allowMove)
                    {
                        Vector2 direction = (touch.position - initTouchPos);
                        DirNormalized = direction / direction.magnitude; //imp 1
                        
                    }
                    break;

                case TouchPhase.Ended:
                    
                    float Distance = Vector2.Distance(touch.position, initTouchPos);
                    Movement(DirNormalized, Distance);
                   
                    break;

            }
            
            checkVel();
        }
    }

   /* public float  CalculateDist(Vector2 a ,Vector2 b)
    {
       return  Vector2.Distance(a, b);
        
    }
    public Vector2 CalculateDir(Vector2 a , Vector2 b)

    {
        return ((b-a)/distance);
       
    }*/
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



