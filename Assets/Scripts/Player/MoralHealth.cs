using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoralHealth : MonoBehaviour
{
    [SerializeField] private Slider moralSlider;
    [SerializeField] private float maxMoral;
    private float currentMoral;

    // Start is called before the first frame update
    private void Start()
    {
        moralSlider.maxValue = maxMoral;
        currentMoral = maxMoral;
        moralSlider.value = currentMoral;
    }

    public void SubtractMoral(float changeMoral)
    {
        currentMoral -= changeMoral;

        if (currentMoral <=0)
        {
            SceneManager.LoadScene(0);
        }

        moralSlider.value = currentMoral;
    }

    public void AddMoral(float changeMoral)
    {
        currentMoral += changeMoral;

        if (currentMoral >= maxMoral)
        {
            currentMoral = maxMoral;
        }

        moralSlider.value = currentMoral;
    }
    
}
