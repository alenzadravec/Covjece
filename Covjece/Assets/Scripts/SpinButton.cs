//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class SpinButton : MonoBehaviour
//{

//    [SerializeField]
//    private Row[] rows;

//    [SerializeField]
//    private int prizeValue;
//    private bool resultsChecked = false;

   
//    public void Update()
//    {
//        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
//        {
//            prizeValue = 0;
//            resultsChecked = false;
//        }
//        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
//        {
//            CheckResults();
//        }
//    }
//    public void CheckResults()
//    {
//        if (rows[0].stoppedSlot == "Diamond"
//            && rows[1].stoppedSlot == "Diamond"
//            && rows[2].stoppedSlot == "Diamond")

//        { prizeValue = 200; }

//        else if (rows[0].stoppedSlot == "Crown"
//            && rows[1].stoppedSlot == "Crown"
//            && rows[2].stoppedSlot == "Crown")

//        { prizeValue = 400; }

//        else if (rows[0].stoppedSlot == "Melon"
//            && rows[1].stoppedSlot == "Melon"
//            && rows[2].stoppedSlot == "Melon")

//        { prizeValue = 600; }

//        else if (rows[0].stoppedSlot == "Bar"
//            && rows[1].stoppedSlot == "Bar"
//            && rows[2].stoppedSlot == "Bar")

//        { prizeValue = 800; }

//        else if (rows[0].stoppedSlot == "Seven"
//            && rows[1].stoppedSlot == "Seven"
//            && rows[2].stoppedSlot == "Seven")

//        { prizeValue = 1500; }

//        else if (rows[0].stoppedSlot == "Cherry"
//            && rows[1].stoppedSlot == "Cherry"
//            && rows[2].stoppedSlot == "Cherry")

//        { prizeValue = 3000; }

//        else if (rows[0].stoppedSlot == "Lemon"
//            && rows[1].stoppedSlot == "Lemon"
//            && rows[2].stoppedSlot == "Lemon")

//        { prizeValue = 5000; }

//        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Diamond")
//                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Diamond")
//                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Diamond"))
//        {
//            prizeValue = 100;
//        }

//        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Crown")
//                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Crown")
//                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Crown"))
//        {
//            prizeValue = 300;
//        }

//        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Melon")
//                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Melon")
//                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Melon"))
//        {
//            prizeValue = 500;
//        }

//        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Bar")
//                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Bar")
//                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Bar"))
//        {
//            prizeValue = 700;
//        }

//        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Seven")
//                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Seven")
//                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Seven"))
//        {
//            prizeValue = 1000;
//        }

//        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Cherry")
//                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Cherry")
//                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Cherry"))
//        {
//            prizeValue = 2000;
//        }

//        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Lemon")
//                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Lemon")
//                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Lemon"))
//        {
//            prizeValue = 4000;
//        }

//        resultsChecked = true;
//    }
//}
