// Roman Baranov 30.01.2022
using UnityEngine;

public class B_Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player)
        {
            player.GetDamage();
        }
    }
}
