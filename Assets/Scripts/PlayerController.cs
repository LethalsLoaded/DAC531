using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{
#region Variables
#region Public_Variables
    /* PUBLIC VARIABLES */
    [Tooltip("Used for game controls - which characters input will be retrieved.")]
    public uint playerId = 0;

    [Header("Movement Controls")]
    public float speed = 3;
    public float gravity = 30f;
    public float clampAngle = 80.0f;
    public float mouseSensitivity = 100.0f;

    [Header("Headbobbing")]
    public bool isHeadbobbingEnabled;
    public float bobbingSpeed;
    public float bobbingAmount;
    public float midPoint;
    /* END OF PUBLIC VARIABLES */
#endregion
    #region Private_Variables
    /* PRIVATE VARIABLES */
    private float _onwardsInput, _sidewaysInput, _mouseHorizontal, _mouseVertical, timer;
    private CharacterController _characterController;
    private Vector3 _moveDirection, _mouseDirection = Vector3.zero;
    private Player _player; // Rewired 'player', based off of their playerId.
    /* END OF PRIVATE VARIABLES */
#endregion
#endregion

    void Start()
    {
        _player = ReInput.players.GetPlayer((int)playerId);
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(PixelCrushers.DialogueSystem.DialogueManager.IsConversationActive)
            return;
        CheckRewired();
        ProcessInput();
        if(isHeadbobbingEnabled)
            Headbobbing();
    }

    /// <summary>
    /// Checks rewired addon to retrieve the movement data
    /// as well as for any button presses such as interaction.
    /// </summary>
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

    /// <summary>
    /// Calculates the movement for mouse, keyboard and joysticks.
    /// Also calculates the gravity values as CharacterController does not
    /// come with default gravity.
    /// </summary>
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

    /// <summary>
    /// Calculates and creates the values that are used
    /// to make headbobbing effect to make the camera not
    /// feel as 'floaty'
    /// </summary>
    private void Headbobbing()
    {
        var waveSlice = 0.0f;
        if (Mathf.Abs(_onwardsInput) == 0.0f)
            timer = 0.0f;
        else
        {
            waveSlice = Mathf.Sin(timer);
            timer += bobbingSpeed;
            if(timer > Mathf.PI * 2) timer -= Mathf.PI * 2;
        }

        if (waveSlice != 0)
        {
            var translateChange = waveSlice * bobbingAmount;
            var totalAxes = Mathf.Clamp(Mathf.Abs(_onwardsInput), 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            var trans = Camera.main.transform.localPosition;
            trans.y = midPoint + translateChange;
            Camera.main.transform.localPosition = trans;
        }
        else
        {
            var trans = Camera.main.transform.localPosition;
            trans.y = midPoint;
            Camera.main.transform.localPosition = trans;
        }
    }
}
