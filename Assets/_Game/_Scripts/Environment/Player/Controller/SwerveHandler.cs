using Unity.VisualScripting;
using UnityEngine;

public class SwerveHandler : MonoBehaviour, IHandleSwerve
{
    public bool CanSwerve
    {
        get => canSwerve;
        set => canSwerve = value;
    }
    public float SwerveSpeed
    {
        get => swerveSpeed;
        set => swerveSpeed = value;
    }

    [SerializeField] bool canSwerve; //Can we swerve the player?
    [SerializeField] float swerveSpeed; //Swerve swerveSpeed.
    Rigidbody body; //Rigidbody.
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        canSwerve = true;
    }

    /// <summary>
    /// Handle swerving processes of object.
    /// </summary>
    /// <returns>Swerve amount on X-Axis.</returns>
    public Vector3 SwerveAmount()
    {
        if (!CanSwerve) return Vector3.zero;

        if (Input.GetMouseButton(0))
        {
            float xVelocity = Input.GetAxis("Mouse X") * swerveSpeed * Time.fixedDeltaTime;
            return new Vector3(xVelocity, body.velocity.y, 0f);
        }
        else
        {
            // Prevent slippery movement.
            return Vector3.zero;
        }
    }
}
