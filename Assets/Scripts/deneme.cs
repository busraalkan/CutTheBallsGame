using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{ int n = 0;
 int a;
    int[] Sayi;
    // Start is called before the first frame update
    void Start()
    {
        Sayi[0] = 0;
        Sayi[1] = 1;
        a = Convert.ToInt16(Console.ReadLine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    int fibo(int i)
    {
        for (n = 0; n < a; n++)
        {
            Sayi[n + 2] = Sayi[n] + Sayi[n + 1];
            Sayi[n] = Sayi[n + 1];
            Sayi[n + 1] = Sayi[n + 2];
                            }
        return Sayi[n];
    }
}
