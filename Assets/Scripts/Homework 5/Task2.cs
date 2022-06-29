using UnityEngine;
public class Task2 : MonoBehaviour
{   int count;
    [SerializeField] private  char _searchSymbol ;

    private string _sentence =
        "Programmer - is the work in the field of computers. They long sitting in the office, working without hands and mind.";

    private  void Start()
    {
        Search(_sentence,_searchSymbol);
     
    }

    private void Search(string sentence, char searchSymbol)
    {
       
        for (int i  = 0;  i < sentence.Length;  i++)
        {
            if (searchSymbol == sentence[i])
            {
                count++;
            }
        } 
        Debug.Log(count);
    }
}