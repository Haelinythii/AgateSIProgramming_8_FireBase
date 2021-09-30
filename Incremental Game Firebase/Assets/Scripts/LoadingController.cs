using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private Button localButton, cloudButton;

    private void Start()
    {
        //aksi yang dilakukan ketika localbutton di pencet
        localButton.onClick.AddListener(() =>
        {
            SetButtonInteractable(false); //disable button agar tidak spam
            UserDataManager.LoadFromLocal();
            SceneManager.LoadScene(1);
        });

        //aksi yang dilakukan ketika cloudbutton di pencet
        cloudButton.onClick.AddListener(() =>
        {
            SetButtonInteractable(false); //disable button agar tidak spam
            StartCoroutine(UserDataManager.LoadFromCloud(() => SceneManager.LoadScene(1)));
        });
    }

    private void SetButtonInteractable(bool interactable)
    {
        localButton.interactable = interactable;
        cloudButton.interactable = interactable;
    }
}
