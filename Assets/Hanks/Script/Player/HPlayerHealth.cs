using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    public int startHealth = 100;
    int currentHealth;

    public Image damageImage;
    public float flashTime = 5f;
    public Color flashColor = new Color(1f,0f,0f,0.1f);
    bool isDamaged = false;

    AudioSource audioS;

	// Use this for initialization
	void Start ()
	{
	    currentHealth = startHealth;
	    audioS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (isDamaged)
	    {
	        damageImage.color = flashColor;
	    }
	    else
	    {
	        damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashTime * Time.deltaTime);
	    }
	    isDamaged = false;
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        healthSlider.value = currentHealth;
        audioS.Play();
        isDamaged = true;
    }
}
