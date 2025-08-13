using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int hitPoints = 3;
    [SerializeField] private int scoreValue = 5;
    [SerializeField] private Scoreboard scoreboard;
    private void Start()
    {
        if (scoreboard == null)
        {
            UnityEngine.Debug.LogError("Scoreboard not found in the scene.");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }
    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            scoreboard?.IncreaseScore(scoreValue);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
