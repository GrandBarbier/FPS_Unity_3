using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth;
    public float actualHealth;

    private Vector3 changeScaleUp;
    private Vector3 changeScaleDown;
    
    void Start()
    {
        actualHealth = maxHealth;
        changeScaleUp = healthBar.transform.localScale * 2;
        changeScaleDown = healthBar.transform.localScale;
    }
    
    void Update()
    {
        healthBar.value = actualHealth;

        if (actualHealth < 4)
        {
            //StartCoroutine(ScaleBarUp(2));
            //StartCoroutine(ScaleBarDown(1));
        }
        else if (actualHealth < 1)
        {
            //Game over
        }
    }

    public void TakeDamage(float damage)
    {
        actualHealth -= damage;
    }

    IEnumerator ScaleBarUp(float time)
    {
        healthBar.transform.localScale = Vector3.Slerp(healthBar.transform.localScale, changeScaleUp, time);
        yield return new WaitForSeconds(time);
    }
    IEnumerator ScaleBarDown(float time)
    {
        yield return new WaitForSeconds(time);
        healthBar.transform.localScale = Vector3.Slerp(healthBar.transform.localScale, changeScaleDown, time);
    }
}
