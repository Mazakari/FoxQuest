// Roman Baranov 05.02.2022

using UnityEngine;

public class Grotto_Torch : MonoBehaviour
{
    private Animator _animator = null;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        float playSpeed = Random.Range(0.2f, 1.0f);
        _animator.speed = playSpeed;
    }
}
