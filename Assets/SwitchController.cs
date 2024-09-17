using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    [SerializeField] private int _score;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Material _onMaterial;

    private bool _isOn;
    private SwitchState _state;
    private Material _offMaterial;
    private MeshRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _offMaterial = GetComponent<MeshRenderer>().material;

        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    }

    private void Set(bool active)
    {
        _isOn = active;

        if (_isOn == true)
        {
            _renderer.material = _onMaterial;

            _state = SwitchState.On;
            StopAllCoroutines();
        }
        else
        {
            _renderer.material = _offMaterial;

            _state = SwitchState.Off;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        if (_state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }

        _scoreManager.AddScore(_score);
    }


    private IEnumerator Blink(int times)
    {
        _state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            _renderer.material = _onMaterial;
            yield return new WaitForSeconds(0.5f);
            _renderer.material = _offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        _state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Toggle();
        }
    }
}
