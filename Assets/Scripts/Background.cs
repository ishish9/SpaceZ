using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private Image backGround;
    [SerializeField] private Gradient gradient;
    [SerializeField] private float healthAmount = 100f;
    private float lerpSpeed;
    [SerializeField] private UnityEvent AfterDeathEvent1;
    [SerializeField] private UnityEvent InstantAfterDeathEvent;


    void OnEnable()
    {
        
    }

    void OnDisable()
    {
    
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        //healthBar.fillAmount = healthAmount / 100f;
        // healthBar.fillAmount = Mathf.Lerp (healthBar.fillAmount, healthAmount/100 , lerpSpeed );

        backGround.fillAmount = Mathf.Lerp(backGround.fillAmount, healthAmount/100f, lerpSpeed);

        backGround.color = gradient.Evaluate(healthAmount / 100f);

        if (healthAmount <= 0)
        {
            AfterDeathRest();
        }
    }

    public void Heal(float healAmount)
    {
        healthAmount += healAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        backGround.fillAmount = healthAmount / 100f;
        backGround.color = gradient.Evaluate(healthAmount / 100f);

    }

    void AfterDeathRest()
    {
        InstantAfterDeathEvent.Invoke();
        StartCoroutine(wait());
        IEnumerator wait()
        {
            yield return new WaitForSeconds(2.5f);
            AfterDeathEvent1.Invoke();
        }
    }

    public float GetCurrentHealth()
    {
        return healthAmount;
    }
}
