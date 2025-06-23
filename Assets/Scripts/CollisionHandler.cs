using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Debug.Log("Hit " + other.name);
    }
}
