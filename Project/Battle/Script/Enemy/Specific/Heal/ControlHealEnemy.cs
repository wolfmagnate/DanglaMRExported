using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHealEnemy : ControlEnemy
{
    public GameObject Shot;

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(6));
            var shooter = new HealEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 3f, Distance: 9, Shot: Shot);
            shooter.SetDirection(transform.forward);
            shooter.Go();
        }
    }

    protected override IEnumerator MoveCoroutine()
    {
        // ã‰ºˆÚ“®‚ğ‚µ‚È‚ª‚çA‰ñ“]ˆÚ“®‚ğ‚·‚é
        while (true)
        {
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(5));
        }
    }


}
