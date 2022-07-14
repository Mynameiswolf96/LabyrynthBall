using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Task3 : MonoBehaviour
{
   [SerializeField] private int _numberSearch = 5;
   int count;
   List<int> numbers = new List<int>() { 2, 4, -2, 19, 11, -4, 0, 21, 31, -4, 0,5,5,10};

   private void Start()
   {
      Debug.Log(_SearchNumb(_numberSearch, numbers));
      var posNumb = from element
            in numbers
         where element == _numberSearch
         select count++;
      Debug.Log(count);
      var result = numbers.Where(i => i == _numberSearch);
      Debug.Log(result.Count());
   }

   public int _SearchNumb(int numberSearch, List <int> numbs)
   {
      for (int i = 0; i < numbs.Count; i++)
      {
         if (numbs[i]==numberSearch)
         {
            count++;
         }
      }
      return count;
   }
   
}
