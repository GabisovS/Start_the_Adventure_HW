using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.collider.GetComponent<Bullet>();

        if (bullet != null)
        { 
            bullet.DestroyEffect();
            Destroy(bullet.gameObject);
        }
    }
}
