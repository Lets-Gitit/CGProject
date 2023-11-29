using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Animator animator;
    public int HP { get; set; }

    private bool isWalking;

    public Player()
    {
        HP = 100;
    }

    private void Update()
    {
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            ThrowProjectile();
        }

        if(HP <= 0)
        {
            gameObject.SetActive(false); 
        }

    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 pos = new Vector3(h, 0, v);

        isWalking = pos.magnitude > 0;
        
        if(isWalking)
        {
            animator.transform.forward = pos;
        }

        transform.Translate(pos * moveSpeed * Time.deltaTime);

    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void ThrowProjectile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPoint = hit.point;
            targetPoint += transform.up * 1f;

            // 플레이어의 전방 벡터를 기준으로 위치 계산 (z축으로 2f만큼 떨어진 위치)
            Vector3 throwPosition = transform.position;
            throwPosition += transform.up * 1f;

            Vector3 throwDirection = (targetPoint - throwPosition).normalized;

            GameObject projectile = Instantiate(projectilePrefab, throwPosition, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = throwDirection * Projectile.projectileSpeed;
        }
    }

}