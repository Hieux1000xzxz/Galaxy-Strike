using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] lasers;
    [SerializeField] private RectTransform crossHair;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float targetDistance = 10f;

    private Camera mainCam;
    private bool isFiring = false;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void ProcessFiring()
    {
        foreach (var laser in lasers)
        {
            var emission = laser.emission;
            emission.enabled = isFiring;
        }
    }

    private void MoveCrosshair()
    {
        crossHair.position = Input.mousePosition;
    }

    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = mainCam.ScreenToWorldPoint(targetPointPosition);
    }

    private void AimLasers()
    {
        Vector3 direction = targetPoint.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);

        foreach (var laser in lasers)
        {
            laser.transform.rotation = rotation;
        }
    }
}
