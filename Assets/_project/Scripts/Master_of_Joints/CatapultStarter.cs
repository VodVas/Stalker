using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ProjectileCreator))]
[RequireComponent(typeof(HingeJoint))]
public class CatapultStarter : MonoBehaviour
{
    private HingeJoint _hingeJoint;
    private ProjectileCreator _projectileCreator;
    private bool _isCoroutineRunning = false;

    private void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _projectileCreator = GetComponent<ProjectileCreator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isCoroutineRunning == false)
            {
                _isCoroutineRunning = true;

                StartCoroutine(DelayingStart());
            }
        }
    }

    private IEnumerator DelayingStart()
    {
        var wait = new WaitForSeconds(1f);

        _projectileCreator.Spawn();

        yield return wait;

        EnableLimits();

        yield return wait;

        DisableLimits();

        _isCoroutineRunning = false;
    }

    private void EnableLimits()
    {
        JointLimits limits = _hingeJoint.limits;
        limits.min = -30f;
        limits.max = -10f;
        _hingeJoint.limits = limits;
        _hingeJoint.useLimits = true;
    }

    private void DisableLimits()
    {
        _hingeJoint.useLimits = false;
    }
}