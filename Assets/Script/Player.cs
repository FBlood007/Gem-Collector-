using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    public Vector2 movementSpeed;
    public Rigidbody2D rb;
    Vector2 inputX;
    public Vector3Int cellWorld;
    public Direction direction;
    public bool leftMovement;
    public bool rightMovement;
    public bool upMovement;
    public bool downMovement;
    public Animator animator;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

    private void Update()
    {
        
        direction = Direction.none;

      /*  if (Application.platform == RuntimePlatform.Android)
        {*/
            if (leftMovement)
            {
                inputX = new Vector2(-1, 0);
                direction = Direction.left;
                animator.SetTrigger("DigLeft");
            }
            if (rightMovement)
            {
                animator.SetTrigger("DigRight");
                inputX = new Vector2(1, 0);
                direction = Direction.right;
            }
            if (upMovement)
            {
                animator.SetTrigger("DigUp");
                inputX = new Vector2(0, 1);
                direction = Direction.up;
            }
            if (downMovement)
            {
                animator.SetTrigger("DigDown");
                inputX = new Vector2(0, -1);
                direction = Direction.down;
            }
      /*  }
       
         if(Application.platform == RuntimePlatform.WindowsEditor)
        {

            inputX = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (inputX == Vector2.left)
            {
                direction = Direction.left;
            }
            else if (inputX == Vector2.right)
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
        }*/
         


    }
    void FixedUpdate()
    {
        /*if (Application.platform == RuntimePlatform.Android)
        {*/
            if (leftMovement || rightMovement || upMovement || downMovement)
            {
                movementSpeed = 4f * inputX;
                rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime);
            }
       /* }
        else
        {
            movementSpeed = 4f * inputX;
            rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime);
        }*/
        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TileMap")
        {
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

    public void PointerDownLeft()
    {
        leftMovement = true;
    }
    public void PointerUpLeft()
    {
        leftMovement = false;
    }
    public void PointerDownRight()
    {
        rightMovement = true;
    }
    public void PointerUpRight()
    {
        rightMovement = false;
    }

    public void PointerDownUp()
    {
        upMovement = true;
    }
    public void PointerUpUp()
    {
        upMovement = false;
    }
    public void PointerDownDown()
    {
        downMovement = true;
    }
    public void PointerUpDown()
    {
        downMovement = false;
    }
}