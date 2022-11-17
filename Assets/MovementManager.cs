using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    [SerializeField] private Animator _animator;

    private bool _isTurning = false;
    private bool _isStopped = false;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.transform.position = Vector3.zero;
        _animator.SetFloat("Movement", 0);
        StartCoroutine("TurnRobot");
    }

    public void MoveRobot()
    {
        if (_isTurning || _isStopped) return;
        _rigidbody.velocity = _rigidbody.transform.forward * Time.deltaTime * _speed;
        _animator.SetFloat("Movement", 1);
    }

    public void StopRobot()
    {
        _rigidbody.velocity = Vector3.zero;
        _animator.SetFloat("Movement", 0);
    }


    private IEnumerator TurnRobot()
    {
        int random = Random.Range(3, 6);

        yield return new WaitForSeconds(random);
        _isTurning = true;
        //_animator.SetTrigger("Turn");

        _rigidbody.transform.Rotate(Vector3.up, 180);
        yield return new WaitForSeconds(.2f);
        _isTurning = false;
        StartCoroutine("TurnRobot");
    }
}
