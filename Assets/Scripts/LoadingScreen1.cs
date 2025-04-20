using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen_1 : MonoBehaviour
{
    public static LoadingScreen_1 instance;

    [SerializeField]
    private GameObject loading_Bar_Holder;

    [SerializeField]
    private Image loading_Bar_Progress;

    private float progress_Value = 1.1f;
    private float progress_Multiplier_1 = 0.5f;
    private float progress_Multiplier_2 = 0.7f;

    public float load_level_Time = 3f;

    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        // StartCoroutine(LoadingSomeLevel());
    }

    void Update()
    {
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void LoadLevel(string sceneName)
    {
        progress_Value = 0f;
        loading_Bar_Holder.SetActive(true);
        StartCoroutine(loadingUI(sceneName));
    }

    IEnumerator loadingUI(string sceneName)
    {
        while (progress_Value < 1f)
        {
            progress_Value += Time.deltaTime * progress_Multiplier_1;
            loading_Bar_Progress.fillAmount = progress_Value;
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(sceneName);
        loading_Bar_Holder.SetActive(false);
    }
}