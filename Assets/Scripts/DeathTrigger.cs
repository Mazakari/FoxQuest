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

        if (player)
        {
            player.GetDamage();
        }
        else if(collider.GetComponent<Projectile>())
        {
            Destroy(collider.gameObject);
        }
    }
}
