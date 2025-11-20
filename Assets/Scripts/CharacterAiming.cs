using UnityEngine;

public class CharacterAiming : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 20;
    private Camera _camera;
    
    void Start()
    {
        _camera = Camera.main;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float yCamera = _camera.transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yCamera, 0),
            _turnSpeed * Time.deltaTime);
    }
}
