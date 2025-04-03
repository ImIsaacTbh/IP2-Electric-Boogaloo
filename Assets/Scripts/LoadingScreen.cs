using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen instance;

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
        StartCoroutine(LoadingSomeLevel());
    }

    void Update()
    {
        ShowLoadingScreen();
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
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string sceneName)
    {
        loading_Bar_Holder.SetActive(true);
        progress_Value = 0f;
        Time.timeScale = 0f;
        SceneManager.LoadScene(sceneName);
    }

    void ShowLoadingScreen()
    {
        if (progress_Value < 1f)
        {
            progress_Value += progress_Multiplier_1 * progress_Multiplier_2 * Time.unscaledDeltaTime;
            loading_Bar_Progress.fillAmount = progress_Value;

            if (progress_Value >= 1f)
            {
                progress_Value = 1.1f;
                loading_Bar_Progress.fillAmount = 0f;
                loading_Bar_Holder.SetActive(false);
            }
        }
    }

    IEnumerator LoadingSomeLevel()
    {
        yield return new WaitForSeconds(load_level_Time);
        LoadLevel("PresentScene");
    }
}
