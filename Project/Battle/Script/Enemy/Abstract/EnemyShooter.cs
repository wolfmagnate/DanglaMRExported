using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyShooter
{
    /// <summary>
    /// ’eŠÛì¬‚ÌŠî–{“I‚Èî•ñ‚ğ“ü—Í‚·‚é
    /// </summary>
    /// <param name="position">’eŠÛ‚Ì¶¬ˆÊ’u</param>
    /// <param name="rotation">’eŠÛ‚Ì‰Šú‚Ì‰ñ“]</param>
    /// <param name="Attack">ˆĞ—Í</param>
    /// <param name="Speed">’e‘¬</param>
    /// <param name="Distance">”ò‹——£</param>
    public abstract void CreateShot(Vector3 position, Quaternion rotation, float Attack, float Speed, float Distance, GameObject Shot);

    public abstract void SetDirection(Vector3 direction);

    public abstract void Go();

}
