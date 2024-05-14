using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public string key; 
    public float speed = 5f;
    public Text keyText;
    private SpriteRenderer spriteRenderer;

    private Vector3 targetPosition; 
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetPosition = GameObject.FindWithTag("Warrior").transform.position;
        UpdateKeyText();

        //if (string.IsNullOrEmpty(key))
        //{
        //    Debug.LogError("Key is not assigned to the Weapon!");
        //}

        //Debug.Log("Weapon created with key: " + key);
    }

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check 
        if (transform.position == targetPosition)
        {
            Destroy(gameObject); 
        }
    }
    public void UpdateKeyText()
    {
        if (keyText != null)
        {
            keyText.text = key; 
        }
    }
    public void ChangeColor(bool inAttackArea)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = inAttackArea ? Color.red : new Color(0.37f, 1f, 0f);
        }
    }
}
