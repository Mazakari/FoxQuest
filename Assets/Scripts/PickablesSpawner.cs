//Roman Baranov 24.10.2021

using UnityEngine;

public class PickablesSpawner : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private GameObject _picablePrefab = null;
    [SerializeField] private int _spawnCount = 1;
    [SerializeField] private float _popupForce = 2f;
    [SerializeField] private Transform _spawnPoint;

    private bool _isSpawned = false;
    #endregion

    #region PUBLIC Methods
    /// <summary>
    /// Spawn specified amount of pickables in a random angle from the spawn point
    /// </summary>
    public void SpawnPickables()
    {
        if (_picablePrefab != null && !_isSpawned)
        {
            GameObject pickable;

            for (int i = 0; i < _spawnCount; i++)
            {
                pickable = Instantiate(_picablePrefab, _spawnPoint.position, Quaternion.identity);

                float randomAngle = Random.Range(-2f, 2f); //generates random angle in radians
                Vector2 randomVector = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
                pickable.GetComponent<Rigidbody2D>().AddForce(randomVector * _popupForce, ForceMode2D.Impulse);
            }

            _isSpawned = !_isSpawned;
        }
    }
    #endregion

}
