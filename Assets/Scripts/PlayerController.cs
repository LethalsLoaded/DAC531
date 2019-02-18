using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{
    public uint playerId = 0;
    public float speed = 3;
    public float gravity = 30f;
    public float clampAngle = 80.0f;
    public float mouseSensitivity = 100.0f;
    
    private float _onwardsInput, _sidewaysInput, _mouseHorizontal, _mouseVertical;
    private CharacterController _characterController;
    private Vector3 _moveDirection, _mouseDirection = Vector3.zero;

    Player _player;

    void Start()
    {
        _player = ReInput.players.GetPlayer((int)playerId);
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckRewired();
        ProcessInput();
    }

    private void CheckRewired()
    {
        // KEYBOARD VALUES
        _onwardsInput = _player.GetAxis("Move_Onwards");
        _sidewaysInput = _player.GetAxis("Move_Sideways");

        // MOUSE VALUES
        _mouseVertical = _player.GetAxis("Mouse Horizontal");
        _mouseHorizontal = _player.GetAxis("Mouse Vertical");
        Debug.Log(_mouseVertical);
    }

    private void ProcessInput()
    {
        if(_characterController.isGrounded)
        {
            _moveDirection = new Vector3(_sidewaysInput, 0.0f, _onwardsInput);
            _moveDirection = transform.TransformDirection(_moveDirection);

            _moveDirection *= speed;
        }

        _moveDirection.y -= gravity * Time.deltaTime;

        
        _characterController.Move(_moveDirection * Time.deltaTime);

        // MOUSE ROTATION
        _mouseDirection.x += _mouseHorizontal * mouseSensitivity * Time.deltaTime;
        _mouseDirection.y += _mouseVertical * mouseSensitivity * Time.deltaTime;
        _mouseDirection.x = Mathf.Clamp(_mouseDirection.x, -clampAngle, clampAngle);
        Debug.Log(_mouseDirection);
        var localRotation = Quaternion.Euler(_mouseDirection.x, _mouseDirection.y, 0.0f);
        Camera.main.transform.rotation = localRotation;
        transform.rotation = Quaternion.Euler(0.0f, _mouseDirection.y, 0.0f);

    }
}
