// Roman Baranov 22.12.2021

using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DeathTrigger : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true; 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        int layer = LayerMask.NameToLayer("Characters");

        if (player && collider.gameObject.layer == layer)
        {
            player.GetDamage();
            return;
        }

        if (collider.gameObject.layer == layer)
        {
            Destroy(collider.transform.root.gameObject);
            return;
        }

        if(collider.GetComponent<Projectile>())
        {
            Destroy(collider.transform.root.gameObject);
            return;
        }
    }
}
