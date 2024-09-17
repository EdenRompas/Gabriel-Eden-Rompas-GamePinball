using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _returnTime;
    [SerializeField] private float _length;
    [SerializeField] private float _followSpeed;

    private Vector3 _defaultPosition;
    public bool HasTarget { get { return _target != null; } }

    private void Start()
    {
        _defaultPosition = transform.position;
        _target = null;
    }

    private void Update()
    {
        if (HasTarget)
        {
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = _target.position + (targetToCameraDirection * _length);

            transform.position = Vector3.Lerp(transform.position, targetPosition, _followSpeed * Time.deltaTime);
        }
    }

    public void FollowTarget(Transform targetTransform, float targetLength)
    {
        StopAllCoroutines();

        _target = targetTransform;
        _length = targetLength;
    }

    public void GoBackToDefault()
    {
        StopAllCoroutines();

        _target = null;

        StartCoroutine(MovePosition(_defaultPosition, _returnTime));
    }

    private IEnumerator MovePosition(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer / time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}
