using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchScript : MonoBehaviour
{
    public List<GameObject> ContentHolders; // List of ContentHolder objects
    public List<GameObject> Elements;       // List to store all the child elements
    public GameObject SearchBar;
    public int totalElements;

    // Start is called before the first frame update
    void Start()
    {
        Elements = new List<GameObject>();

        // Loop through all ContentHolders
        foreach (GameObject contentHolder in ContentHolders)
        {
            totalElements = contentHolder.transform.childCount;
            // Add each child element to the Elements list
            for (int i = 0; i < totalElements; i++)
            {
                Elements.Add(contentHolder.transform.GetChild(i).gameObject);
            }
        }
    }
    public void Search()
    {
        string SearchText = SearchBar.GetComponent<InputField>().text;
        int searchLength = SearchText.Length;
        int searchedElement = 0;

        foreach(GameObject ele in Elements)
        {
            searchedElement += 1;

            if(ele.transform.GetChild(0).GetComponent<Text>().text.Length > searchLength)
            {
                if(SearchText.ToLower() == ele.transform.GetChild(0).GetComponent<Text>().text.Substring(0, searchLength).ToLower())
                {
                    ele.SetActive(true);
                }
                else
                {
                    ele.SetActive(false);
                }
            }
        }
        
    }
}
