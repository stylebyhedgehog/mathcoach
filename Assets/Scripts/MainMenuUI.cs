using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button logInBtn;
    [SerializeField] private Button logOutBtn;

    [SerializeField] private Button blockListBtn;

    [SerializeField] private Button statBtn;

    [SerializeField] private Button adminBtn;

    [SerializeField] private GameObject AuthPanel;
    [SerializeField] private GameObject BlockListPanel;
    [SerializeField] private GameObject StatPanel;
    [SerializeField] private GameObject AdminPanel;
    void Start()
    {
        logOutBtn.gameObject.SetActive(false);
        blockListBtn.gameObject.SetActive(false);
        statBtn.gameObject.SetActive(false);
        adminBtn.gameObject.SetActive(false);
        Actions();
        SessionStorage.singedInAction += onLogInHandler;
        SessionStorage.logOutAction += onLogOutHandler;
    }

   
    private void Actions()
    {
        logInBtn.onClick.AddListener(()=>AuthPanel.SetActive(true));
        logOutBtn.onClick.AddListener(()=>SessionStorage.Instance.unsetUser());
        blockListBtn.onClick.AddListener(() => BlockListPanel.SetActive(true));
        statBtn.onClick.AddListener(()=> StatPanel.SetActive(true));
        adminBtn.onClick.AddListener(()=> AdminPanel.SetActive(true));

    }

    private void onLogInHandler()
    {
        logInBtn.gameObject.SetActive(false);
        logOutBtn.gameObject.SetActive(true);
        blockListBtn.gameObject.SetActive(true);
        statBtn.gameObject.SetActive(true);
        if (SessionStorage.Instance.isAdmin())
        {
            adminBtn.gameObject.SetActive(true);
        }
    }

    private void onLogOutHandler()
    {
        logInBtn.gameObject.SetActive(true);
        logOutBtn.gameObject.SetActive(false);
        blockListBtn.gameObject.SetActive(false);
        statBtn.gameObject.SetActive(false);
        adminBtn.gameObject.SetActive(false);
    }
}
