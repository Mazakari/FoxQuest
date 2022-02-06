// Roman Baranov 30.01.2022
using UnityEngine;

public class B_Spikes : MonoBehaviour
{
    #region VARIABLES
    private float pushForce = 5f;
    #endregion

    #region UNITY Methods
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player)
        {
            Vector2 pushDirection = player.transform.position - gameObject.transform.position;

            player.GetComponent<Rigidbody2D>().AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            player.Invoke("GetDamage",0.2f);
        }
    }
    #endregion
}
