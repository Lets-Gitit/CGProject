using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameObject projectilePrefab;

    private bool isWalking;

    private void Update()
    {
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            ThrowProjectile();
        }

    }

    private void Move()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
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
            Vector3 throwPosition = transform.position + transform.forward;
            throwPosition += transform.up * 1f;

            Vector3 throwDirection = (targetPoint - throwPosition).normalized;

            GameObject projectile = Instantiate(projectilePrefab, throwPosition, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = throwDirection * Projectile.projectileSpeed;
        }
    }


}
