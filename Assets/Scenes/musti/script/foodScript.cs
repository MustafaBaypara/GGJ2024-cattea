using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodScript : MonoBehaviour
{

   void Update()
   {
      if (this.gameObject.name != "newfood")
         return;
      if (transform.position.y < 0)
      {
         Destroy(this.gameObject);
      }
   }
}
