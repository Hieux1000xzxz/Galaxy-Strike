using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement: MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Speed of the player movement
    [SerializeField] private float XClampRange = 10f; 
    [SerializeField] private float YClampRange = 10f;

    [SerializeField] private float controllRollFactor = 20f; // Reference to the input action for movement
    [SerializeField] private float controllPitchFactor = 20f;
    [SerializeField] private float rotationSpeed = 10f;   
    private Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -XClampRange, XClampRange);
        
        float yOffset = movement.y * speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -YClampRange, YClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    void ProcessRotation()
    {
        float pitch = movement.y * controllPitchFactor;
        float roll = movement.x * controllRollFactor;
        Quaternion targetRotation = Quaternion.Euler(-pitch, 0, - roll);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

