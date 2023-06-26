using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    public  Vector2 movementSpeed;    
    public Rigidbody2D rb;
    Vector2 inputX;
    Vector2 movement;
   // public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
      
     
        Debug.Log(rb.position + " " + inputX);

     
    }
    void FixedUpdate()
    {
        inputX = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementSpeed = 4f * inputX;
        rb.MovePosition(rb.position +  movementSpeed * Time.fixedDeltaTime);
    }
}
