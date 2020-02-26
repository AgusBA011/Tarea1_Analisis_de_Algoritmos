using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class QuickSort : MonoBehaviour
{
    // Start is called before the first frame update

    int arraysize = 0;

    int[] arr0 = new int[1000];
    int[] arr1 = new int[2000];
    int[] arr2 = new int[3000];
    int[] arr3 = new int[4000];
    int[] arr4 = new int[5000];
    int[] arr5 = new int[6000];
    int[] arr6 = new int[7000];
    int[] arr7 = new int[8000];
    int[] arr8 = new int[9000];
    int[] arr9 = new int[10000];


    int[][] MainArray = new int[10][];

    int k;
    float bolaX = -2.21f;
    Stopwatch sw = new Stopwatch();

    public GameObject punto;
    public GameObject tiempo;
    public TextMesh tm;

    // Start is called before the first frame update
    void Start()
    {

        MainArray[0] = arr0;
        MainArray[1] = arr1;
        MainArray[2] = arr2;
        MainArray[3] = arr3;
        MainArray[4] = arr4;
        MainArray[5] = arr5;
        MainArray[6] = arr6;
        MainArray[7] = arr7;
        MainArray[8] = arr8;
        MainArray[9] = arr9;
        System.Random rnd = new System.Random();

        for (int i = 0; i < 10; i++)
        {
            arraysize = arraysize + 1000;

            for (int j = 0; j < arraysize; j++)
            {
                k = rnd.Next(500);
                MainArray[i][j] = k;
            }
            
            int len = MainArray[i].Length;

            sw.Start();

            quickSort(MainArray[i], 0, len - 1);

            sw.Stop();

            UnityEngine.Debug.Log("(QuickSort)Time elapsed:" + ((double)(sw.Elapsed.TotalMilliseconds * 1000000) /
                1000000).ToString("0.00 ms"));

            float timeElapsed = sw.Elapsed.Milliseconds;

            UnityEngine.Debug.Log(timeElapsed);

            float bolaY = -3.1f + timeElapsed;
            
            float tiempoY = -3.1f + timeElapsed;

            Instantiate(punto);
            punto.transform.position = new Vector3(bolaX, 0.36f, bolaY);

            Instantiate(tiempo);

            tiempo.transform.position = new Vector3(-8.12f, 0.36f, tiempoY);
            tiempo.transform.eulerAngles = new Vector3(90, 0, 0);

            TextMesh tm = new TextMesh();
            tm = tiempo.GetComponent("TextMesh") as TextMesh;
            tm.text = ((double)(sw.Elapsed.TotalMilliseconds * 1000000) /
                1000000).ToString("0.00") + "---";

            bolaX = bolaX + 4f;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Algoritmo para QuickSort

    static int particionar(int[] arr, int imin, int imax)
    {
        int pivot = arr[imax];
        // index of smaller element 
        int i = (imin - 1);
        for (int j = imin; j < imax; j++)
        {
            // If current element is smaller  
            // than the pivot 
            if (arr[j] < pivot)
            {
                i++;

                // swap arr[i] and arr[j] 
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        // swap arr[i+1] and arr[high] (or pivot) 
        int temp1 = arr[i + 1];
        arr[i + 1] = arr[imax];
        arr[imax] = temp1;

        return i + 1;
    }

    static void quickSort(int[] arr, int imin, int imax)
    {

        if (imin >= imax) return;

        int k = particionar(arr, imin, imax);
        quickSort(arr, imin, k - 1);
        quickSort(arr, k + 1, imax);

    }
}
