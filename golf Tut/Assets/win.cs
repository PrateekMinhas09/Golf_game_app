using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject text;
    public FingerMove fm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="sphere")
        {
            Debug.Log("WIIIIIN");
            text.SetActive(true);
            fm.sphrb.velocity = Vector3.zero;
        }
    }
}
