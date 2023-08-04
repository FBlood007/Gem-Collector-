using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    public Vector2 movementSpeed;
    public Rigidbody2D rb;
    Vector2 inputX;
    public Vector3Int cellWorld;
    public Direction direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void DestroyBlock(Tilemap map)
    {
        Vector3 pos;
        if (rb != null)
        {
            pos.y = (transform.position.y);
            pos.x = (transform.position.x);

            if (direction == Direction.down) // down
            {
                direction = Direction.down;
                pos.y -= 0.9f;
            }
            else if (direction == Direction.left) // left
            {
                pos.x = pos.x - 0.9f;
            }
            else if(direction == Direction.up) // up
            {
                pos.y = pos.y + 0.9f;
            }
            else if(direction == Direction.right) // right
            {
                pos.x = pos.x + 0.9f;
            }
            Vector3Int posInt = new Vector3Int(Mathf.FloorToInt(pos.x),Mathf.FloorToInt(pos.y), 0);
            //Vector3Int posInt1 = new Vector3Int(Mathf.RoundToInt(pos.x),Mathf.RoundToInt(pos.y), 0);
            //Vector3Int posInt2 = new Vector3Int((int)pos.x + (int)Mathf.Clamp01(pos.x/Mathf.Abs(pos.x)), (int)pos.y + (int)Mathf.Clamp01(pos.y / Mathf.Abs(pos.y)), 0);
            cellWorld = Vector3Int.FloorToInt(map.GetCellCenterWorld(posInt));
            map.SetTile(cellWorld, null);
            direction = Direction.none;
        }
    }
    void FixedUpdate()
    {
        inputX = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = Direction.none;
        if(inputX == Vector2.left)
        {
            direction = Direction.left;
        }
        else if(inputX == Vector2.right)
        {
            direction = Direction.right;
        }
        else if (inputX == Vector2.up)
        {
            direction = Direction.up;
        }
        else if (inputX == Vector2.down)
        {
            direction = Direction.down;
        }
        movementSpeed = 4f * inputX;
        rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TileMap")
        {
            Debug.Log("colllided with tilemap");
            Vector3 pos = collision.gameObject.transform.position;
            DestroyBlock(collision.gameObject.GetComponent<Tilemap>());
        }
    }
    
    public enum Direction
    {
        left,
        right,
        up,
        down,
        none
    }

}