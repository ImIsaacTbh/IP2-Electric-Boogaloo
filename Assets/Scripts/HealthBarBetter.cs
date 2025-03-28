using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBetter : MonoBehaviour
{
    public Image image;
    public Image imageMask;
    private Camera cam;

    private float target = 1f;

    public float drainTime;
    private Coroutine drainHealthBar;

    public Gradient gradient;
    private Color newColour;
    public GameObject entity;

    public TMP_Text healthTXT;


    public GlobalController controller;



    private void Start()
    {

        image.color = gradient.Evaluate(target);
        
    }

    private void Update()
    {
        UpdateHealthBar();
        healthTXT.text = "Health: " + controller._health.ToString();

        if (entity)
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        
    }
    public void UpdateHealthBar()
    {
        target = controller._health / 100;
        drainHealthBar = StartCoroutine(DrainHealthBar());
        CheckGradient();
    }

    private IEnumerator DrainHealthBar()
    {
        float fillAmount = image.fillAmount;
        float fillAmount2 = imageMask.fillAmount;
        Color currentColuor = image.color;
        float elapsedTime = 0f;
        while (elapsedTime < drainTime) {
            elapsedTime += Time.deltaTime;
            image.fillAmount = Mathf.Lerp(fillAmount, target, (elapsedTime / drainTime));
            imageMask.fillAmount = Mathf.Lerp(fillAmount2, target, (elapsedTime / drainTime));
            image.color = Color.Lerp(currentColuor, newColour, (elapsedTime / drainTime));
            yield return null;
        }
    }

    private void CheckGradient()
    {
        newColour = gradient.Evaluate(target);
    }

 
}
    

