using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    public Vector2 movementSpeed;
    public Rigidbody2D rb;
    Vector2 inputX;
    Vector2 movement;
    Direction direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void DestroyBlock(Tilemap map)
    {
        Vector3 pos;
        if (rb != null)
        {
            pos.y = Mathf.Floor(rb.position.y);
            pos.x = Mathf.Floor(rb.position.x);

            if (inputX == new Vector2(0, -1)) // down
            {
                pos.y = pos.y - 1;
            }
            else if (inputX == new Vector2(-1, 0)) // left
            {
                pos.x = pos.x - 1;
            }
            else if(inputX == new Vector2(0,1)) // up
            {
                pos.y = pos.y + 1;
            }
            else if(inputX == new Vector2(1, 0)) // right
            {
                pos.x = pos.x + 1;
            }
            Vector3Int posInt = new Vector3Int((int)pos.x, (int)pos.y, 0);
            Vector3 cellWorld = map.GetCellCenterWorld(posInt);
            map.SetTile(posInt, null);

            Debug.Log("posx ,posy" + pos.x + " " + pos.y);
            Debug.Log(rb.position + " " + inputX);
        }
    }
    void FixedUpdate()
    {
        inputX = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementSpeed = 4f * inputX;
       
        rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TileMap")
        {
            Vector3 pos = collision.gameObject.transform.position;
            Debug.Log("pos" + pos);
            DestroyBlock(collision.gameObject.GetComponent<Tilemap>());
        }
    }

    enum Direction
    {
        left,
        right,
        up,
        down
    }

}