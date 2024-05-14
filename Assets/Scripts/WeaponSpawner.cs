using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weaponPrefab; 
    public Transform[] spawnPoints; 

    private string[] registeredKeys; 

    private void Start()
    {
        LoadRegisteredKeys();
        InvokeRepeating("SpawnWeapon", 2f, 1f); 
    }

    private void LoadRegisteredKeys()
    {
        int keyCount = PlayerPrefs.GetInt("KeyCount");
        registeredKeys = new string[keyCount];
        for (int i = 0; i < keyCount; i++)
        {
            registeredKeys[i] = PlayerPrefs.GetString("Key" + i);
        }
    }

    private void SpawnWeapon()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        
        GameObject weapon = Instantiate(weaponPrefab, spawnPoint.position, spawnPoint.rotation);

        
        string randomKey = RandomKey();
        Weapon weaponScript = weapon.GetComponent<Weapon>();
        weaponScript.key = randomKey;
        weaponScript.UpdateKeyText(); 
    }

    private string RandomKey()
    {
        
        int index = Random.Range(0, registeredKeys.Length);
        return registeredKeys[index];
    }
}
