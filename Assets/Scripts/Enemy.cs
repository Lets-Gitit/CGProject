using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    private int PlayerDamage = 1;

    private GameObject player;
    private Rigidbody enemyRigidbody;

    const string PLAYER = "Player";
    const string PROJECTILE = "Projectile";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(PLAYER);
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
        transform.LookAt(player.transform);
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        enemyRigidbody.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag(PLAYER))
        {
            Player instance = other.GetComponent<Player>();
            // instance.HP -= PlayerDamage;
            Debug.Log($"�÷��̾� �浹, ���� ü�� : {instance.HP}");
        }

        if (other.gameObject.CompareTag(PROJECTILE))
        {
            Player instance = player.GetComponent<Player>();
            Debug.Log($"���� : {++instance.Score}");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
