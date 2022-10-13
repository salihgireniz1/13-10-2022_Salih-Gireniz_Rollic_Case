using UnityEngine;

public interface ILimitPosition
{
    public float BotBorder { get; }
    public float TopBorder { get; }

    /// <summary>
    /// Limit the objects position.
    /// </summary>
    /// <returns>The limited position between certain borders.</returns>
    Vector3 LimitedPosition();
}
