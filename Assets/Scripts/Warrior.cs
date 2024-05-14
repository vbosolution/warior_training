using UnityEngine;
using System.Collections.Generic;
using System.Threading;

public class Warrior : MonoBehaviour
{
    private GameManager gameManager;
    private List<Weapon> weaponsInAttackArea;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        weaponsInAttackArea = new List<Weapon>();
    }

    private void Update()
    {
        if (weaponsInAttackArea.Count > 0)
        {
            foreach (Weapon weapon in weaponsInAttackArea)
            {
                Debug.Log($"weapon with key '{weapon.key}' was entered!");
                if (Input.GetKeyDown(weapon.key))
                {
                    Debug.Log("Match Key!");
                    gameManager.HandleWeaponCollision(weapon);
                }
            }
        }
    }

    public void AddWeaponInAttackArea(Weapon weapon)
    {
        if (!weaponsInAttackArea.Contains(weapon))
        {
            Debug.Log("Added weapon");
            weaponsInAttackArea.Add(weapon);
        }
    }

    //public void RemoveWeaponFromAttackArea(Weapon weapon)
    //{
    //    if (weaponsInAttackArea.Contains(weapon))
    //    {
    //        weaponsInAttackArea.Remove(weapon);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            AddWeaponInAttackArea(other.GetComponent<Weapon>());
        }
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Weapon"))
    //    {
    //        RemoveWeaponFromAttackArea(other.GetComponent<Weapon>());
    //    }
    //}
}
