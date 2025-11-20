using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private Vector2 _input;

    void Awake()
    {
        // _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _input.x = Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Vertical");
        
        _animator.SetFloat("InputX" , _input.x);
        _animator.SetFloat("InputY" , _input.y);
    }
}
