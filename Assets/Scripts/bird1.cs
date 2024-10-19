using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird1 : MonoBehaviour
{
    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;
    public float launchPower = 500f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();

        _rb.isKinematic = true;
        _circleCollider.enabled = false;
    }
    public void LaunchBird(Vector2 launchDirection)
    {
        _rb.isKinematic = false;
        _circleCollider.enabled = true;
        _rb.AddForce(launchDirection * launchPower);
        StartCoroutine(DestroyAfterTime(5f));

    }
    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
