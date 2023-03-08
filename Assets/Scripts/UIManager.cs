using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PageName
{
    Home,
    Levels,
    Settings,
    Authors,
    Shop,
    Game,
    Pause,
    Results
}

public class UIManager : MonoBehaviour
{
    public List<GameObject> Pages = new List<GameObject>();
    private int currentPageNumber;

    public void HidePage(int pageNumber)
    {
        GameObject currentPage = Pages[pageNumber];
        Page currentPageScript = currentPage.GetComponent<Page>();
        currentPageScript.PanelFaseOut();
        //currentPage.gameObject.SetActive(false);
    }

    public void ShowPage(int PageNumber)
    {
        GameObject newPage = Pages[PageNumber];
        Page newPageScript = newPage.GetComponent<Page>();
        //newPage.gameObject.SetActive(true);
        newPageScript.PanelFadeIn();
        //currentPageNumber = newPageItem;
    }

    public void ExitToApp()
    {
        Application.Quit();
    }
}
