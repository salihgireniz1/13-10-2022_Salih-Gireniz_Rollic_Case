using UnityEngine;

public class LimitPosition : MonoBehaviour, ILimitPosition
{
    #region Constructors
    public float BotBorder => xBorder_Min;
    public float TopBorder => xBorder_Max;
    #endregion

    #region Variables
    [SerializeField] float xBorder_Min; //Left movement limit.
    [SerializeField] float xBorder_Max; //Right movement limit.
    #endregion

    #region Methods
    public Vector3 LimitedPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, xBorder_Min, xBorder_Max);
        Vector3 clampedPosition = new Vector3(
            clampedX,
            transform.position.y,
            transform.position.z
        );
        return clampedPosition;
    }
    #endregion
}
