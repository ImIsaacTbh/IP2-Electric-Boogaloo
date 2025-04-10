using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBetter : MonoBehaviour
{
    public Image image;
    public Image imageMask;
#pragma warning disable CS0649
    private Camera cam;
#pragma warning restore CS0649

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
        controller = GlobalController.instance;
        image.color = gradient.Evaluate(target); //sets the  image fill colour to the value on the gradient
        
    }

    private void Update()
    {
        UpdateHealthBar();  //updates the health bar
        healthTXT.text = "Health: " + controller._health.ToString();

        if (entity)
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position); //for putting health bars on enemy's if needed
        
    }
    public void UpdateHealthBar()
    {
        target = controller._health / controller._maxhealth;
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
    

