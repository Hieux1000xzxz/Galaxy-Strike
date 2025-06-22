using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;
    [SerializeField] private RectTransform crossHair;

    bool isFiring = false;
    private void Update()
    {
        ProcessFiring();
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
}

