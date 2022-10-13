using UnityEngine;

public class HandleForwardVelocity : MonoBehaviour, IApplyForwardSpeed
{
    #region Constructors
    public float ForwardSpeed => forwardSpeed;
    public bool CanGoForward
    {
        get => canGoForward;
        set => canGoForward = value;
    }
    #endregion

    #region Variables
    [SerializeField] float forwardSpeed;
    [SerializeField] bool canGoForward;
    Rigidbody body;
    #endregion
    #region Methods
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    public Vector3 ForwardAmount()
    {
        if (!canGoForward) return Vector3.zero;

        float zVelocity = forwardSpeed * Time.fixedDeltaTime;
        Vector3 velocity = new Vector3(0f, 0f, zVelocity);
        return velocity;
    }
    #endregion
}
