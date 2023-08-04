using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            ICollectables collectable = collision.GetComponent<ICollectables>();

            if (collectable != null)
            {
                collectable.Collect();
            }
        }
    }
}
