using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [SerializeField] private KeyCode _input;

    [SerializeField] private float _maxTimeHold;
    [SerializeField] private float _maxForce;

    private bool _isHold;

    private void Start()
    {
        _isHold = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ReadInput(collision.collider);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(_input) && !_isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        _isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(_input))
        {
            force = Mathf.Lerp(0, _maxForce, timeHold / _maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        _isHold = false;
    }
}
