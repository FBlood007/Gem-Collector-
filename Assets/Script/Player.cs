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

    public void DestroyBlock(Tilemap map, Vector3 pos)
    {
        pos.y = Mathf.Floor(pos.y);
        pos.x = Mathf.Floor(pos.x);

        map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);


        Debug.Log(rb.position + " " + inputX);
    }
    void FixedUpdate()
    {
        inputX = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementSpeed = 4f * inputX;
        rb.MovePosition(rb.position +  movementSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TileMap")
        {
            Vector3 pos = collision.gameObject.transform.position;
            DestroyBlock(collision.gameObject.GetComponent<Tilemap>(), pos);
        }
    }
}