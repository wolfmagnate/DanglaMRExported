using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyShooter
{
    /// <summary>
    /// �e�ۍ쐬�̊�{�I�ȏ�����͂���
    /// </summary>
    /// <param name="position">�e�ۂ̐����ʒu</param>
    /// <param name="rotation">�e�ۂ̏����̉�]</param>
    /// <param name="Attack">�З�</param>
    /// <param name="Speed">�e��</param>
    /// <param name="Distance">�򋗗�</param>
    public abstract void CreateShot(Vector3 position, Quaternion rotation, float Attack, float Speed, float Distance, GameObject Shot);

    public abstract void SetDirection(Vector3 direction);

    public abstract void Go();

}
