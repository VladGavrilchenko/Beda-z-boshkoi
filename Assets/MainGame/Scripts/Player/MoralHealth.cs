using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Burst.CompilerServices;

public class MoralHealth : MonoBehaviour
{
    [SerializeField] private GameObject medicalUI;
    [SerializeField] private Slider moralSlider;
    [SerializeField] private float maxMoral;
    [SerializeField] private int countHeal;
    [SerializeField] private float fillSpeed = 1f;
    [SerializeField] TMP_Text countText;
    private float currentMoral;
    private Animator animator;

    private void OnEnable()
    {
        moralSlider.gameObject.SetActive(true);
        medicalUI.SetActive(true);
        StartCoroutine(FillMoralBar());
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        moralSlider.maxValue = maxMoral;
        currentMoral = 0;
        moralSlider.value = currentMoral;
        medicalUI.SetActive(false);
        moralSlider.gameObject.SetActive(false);
        enabled = false;
        UpdateUI();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H) && countHeal > 0 && currentMoral < maxMoral && animator.GetBool("CameraInHand") == false)
        {
            animator.SetTrigger("Heal");
        }
    }

    private IEnumerator FillMoralBar()
    {
        while (currentMoral < maxMoral)
        {
            currentMoral += fillSpeed * Time.deltaTime;
            currentMoral = Mathf.Min(currentMoral, maxMoral);
            moralSlider.value = currentMoral;
            yield return null;
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
        countHeal--;


        if (currentMoral >= maxMoral)
        {
            currentMoral = maxMoral;
        }

        moralSlider.value = currentMoral;
        UpdateUI();
    }

    public void AddCountHealth(int addCountHeal)
    {
        countHeal += countHeal;
        UpdateUI();
    }
    private void UpdateUI()
    {
        countText.text = countHeal.ToString();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wolf"))
        {
            WolfParameters wolfParameters = other.gameObject.GetComponent<WolfParameters>();
            SubtractMoral(wolfParameters.TakeDamageAndDead());
        }

        if (other.gameObject.CompareTag("Cat"))
        {

        }
    }
}
