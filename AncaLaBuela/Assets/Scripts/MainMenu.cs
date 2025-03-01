using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // [SerializeField] AudioClip sBotones;

    [SerializeField] GameObject menu;
    
    [SerializeField] GameObject niveles;


    AudioSource audioSrc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoLevel1(){
        // audioSrc.PlayOneShot(sBotones);
        SceneManager.LoadScene("Level1");
    }

    public void GoLevel2(){
        // audioSrc.PlayOneShot(sBotones);
        SceneManager.LoadScene("Level2");
    }

     public void GoCreditos(){
        // audioSrc.PlayOneShot(sBotones);
        SceneManager.LoadScene("Credits");
    }
    public void GoToMainMenu(){
        // audioSrc.PlayOneShot(sBotones);
        SceneManager.LoadScene("Main Menu");
    }
    
    public void Play(){
        // audioSrc.PlayOneShot(sBotones);
        menu.SetActive(false);
        
        niveles.SetActive(true);
    }

    public void Volver(){
        // audioSrc.PlayOneShot(sBotones);
        menu.SetActive(true);
        
        niveles.SetActive(false);
    }
    
    public void Salir(){
        // audioSrc.PlayOneShot(sBotones);
        Application.Quit();
    }
}

