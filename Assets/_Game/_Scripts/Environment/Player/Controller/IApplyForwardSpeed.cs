public interface IApplyForwardSpeed
{
    /// <summary>
    /// Forward speed of object.
    /// </summary>
    public float ForwardSpeed { get; }

    /// <summary>
    /// Check if object can keep going.
    /// </summary>
    public bool CanGoForward { get; set; }

    /// <summary>
    /// Apply forward movement to object.
    /// </summary>
    UnityEngine.Vector3 ForwardAmount();
}
