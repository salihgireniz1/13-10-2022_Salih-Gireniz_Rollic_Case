using UnityEngine;

[RequireComponent(typeof(IHandleSwerve))]
[RequireComponent(typeof(IApplyForwardSpeed))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    IHandleSwerve swerveRespond;
    ILimitPosition clampRespond;
    IApplyForwardSpeed forwardMovementRespond;
    Rigidbody body;
    private void Awake()
    {
        swerveRespond = GetComponent<IHandleSwerve>();
        clampRespond = GetComponent<ILimitPosition>();
        forwardMovementRespond = GetComponent<IApplyForwardSpeed>();
        body = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        body.velocity = swerveRespond.SwerveAmount() + forwardMovementRespond.ForwardAmount();
    }
}
