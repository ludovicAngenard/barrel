using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject resolutionMenu;
    [SerializeField] GameObject qualityMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Map Barrel Town");
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resolution()
    {
        optionsMenu.SetActive(false);
        resolutionMenu.SetActive(true);

    }

    public void Quality()
    {
        optionsMenu.SetActive(false);
        qualityMenu.SetActive(true);

    }

    public void BackOptions()
    {
        optionsMenu.SetActive(true);
        qualityMenu.SetActive(false);
        resolutionMenu.SetActive(false);

    }

    public void BackMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);

    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    List<int> widths = new List<int>() {1920,1366,1280};
    List<int> heights = new List<int>() {1080,768,720};

    public void SetScreenSize (int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void SetFullScreen(bool _fullscreen)
    {
        Screen.fullScreen  = _fullscreen;
    }
}
