using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;
    [SerializeField] private RectTransform crossHair;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float targetDistance = 10f;
    bool isFiring = false;
    private void Start()
    {
        Cursor.visible = false; 
    }
    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        Aimlasers();
    }
    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
       
    }
    private void MoveCrosshair()
    {
        crossHair.position = Input.mousePosition;
    }
    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    private void Aimlasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 direction = targetPoint.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            laser.transform.rotation = rotation;
        }
    }
}

