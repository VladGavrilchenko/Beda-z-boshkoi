using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoralHealth : MonoBehaviour
{
    [SerializeField] private GameObject medicalUI;
    [SerializeField] private Slider moralSlider;
    [SerializeField] private float maxMoral;
    [SerializeField] private int countHeal;
    [SerializeField] private float fillSpeed = 1f; // швидкість заповнення шкали
    private float currentMoral;

    private void OnEnable()
    {
        moralSlider.gameObject.SetActive(true);
        medicalUI.SetActive(true);
        StartCoroutine(FillMoralBar()); // Запускаємо корутину для поступового заповнення
    }

    private void Awake()
    {
        moralSlider.maxValue = maxMoral;
        currentMoral = 0; // Початкове значення 0 для візуального ефекту
        moralSlider.value = currentMoral;
        medicalUI.SetActive(false);
        moralSlider.gameObject.SetActive(false);
        enabled = false;
    }

    private IEnumerator FillMoralBar()
    {
        while (currentMoral < maxMoral)
        {
            currentMoral += fillSpeed * Time.deltaTime; // Плавне збільшення значення
            currentMoral = Mathf.Min(currentMoral, maxMoral); // Щоб не перевищувати maxMoral
            moralSlider.value = currentMoral;
            yield return null; // Чекаємо один кадр перед наступним оновленням
        }
    }

    public void SubtractMoral(float changeMoral)
    {
        currentMoral -= changeMoral;

        if (currentMoral <= 0)
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
