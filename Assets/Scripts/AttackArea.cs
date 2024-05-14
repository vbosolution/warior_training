using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private Warrior warrior;

    private void Start()
    {
        warrior = GetComponentInParent<Warrior>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Weapon weapon = other.GetComponent<Weapon>();
            if (weapon != null)
            {
                weapon.ChangeColor(true); 
                warrior.AddWeaponInAttackArea(weapon);
            }
        }
    }
}
