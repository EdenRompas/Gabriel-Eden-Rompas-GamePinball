using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private KeyCode _input;

    private HingeJoint _joint;
    private JointSpring _spring;

    private float _targetPressed;
    private float _targetReleased;

    // Start is called before the first frame update
    void Start()
    {
        _joint = GetComponent<HingeJoint>();

        _targetPressed = _joint.limits.max;
        _targetReleased = _joint.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        _spring = _joint.spring;

        if (Input.GetKey(_input))
        {
            _spring.targetPosition = _targetPressed;
        }
        else
        {
            _spring.targetPosition = _targetReleased;
        }

        _joint.spring = _spring;
    }
}
