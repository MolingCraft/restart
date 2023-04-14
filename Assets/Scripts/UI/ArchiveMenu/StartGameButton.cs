using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadArchiveMenu()
    {
        MenuManager.Instance.ArchiveMenuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        GameManager.Instance.ButtonExit();
    }
}
