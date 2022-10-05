using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTest : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    
        
    

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime);        
    }
}
