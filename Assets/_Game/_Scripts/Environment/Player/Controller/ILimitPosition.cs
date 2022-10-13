using UnityEngine;

public interface ILimitPosition
{
    float BotBorder { get; }
    float TopBorder { get; }

    /// <summary>
    /// Limit the objects position.
    /// </summary>
    /// <returns>The limited position between certain borders.</returns>
    Vector3 LimitedPosition();
}
