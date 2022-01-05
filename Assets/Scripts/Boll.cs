using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boll : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject playerCamera;
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main.gameObject;
    }

    private void OnEnable()
    {
        StartCoroutine(BollSystem());
    }

    private IEnumerator BollSystem()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            FollowPlayer();
            yield return null;
        }

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        Shoot();

        GameManager.isReady = true;

        yield break;
    }

    private void FollowPlayer()
    {
        transform.position = playerCamera.transform.position + playerCamera.transform.forward;
        transform.rotation = playerCamera.transform.rotation;
    }

    private void Shoot()
    {
        Vector3 force = playerCamera.transform.forward * speed;
        rb.AddForce(force, ForceMode.Impulse);
        rb.useGravity = true;
    }
}
