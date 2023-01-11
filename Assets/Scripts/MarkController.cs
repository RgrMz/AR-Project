using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkController : MonoBehaviour
{
    // Controla si una de las aristas se ha colocado donde debe respecto con otra pieza
    private string[] placedSides = { "", "", "", "" };
    // Start is called before the first frame update
    public string getIsSidePlaced(string side)
    {
        string sidePlaced = "";
        switch(side)
        {
            case "Up":
                sidePlaced = placedSides[0];
                break;
            case "Right":
                sidePlaced =  placedSides[1];
                break;
            case "Down":
                sidePlaced = placedSides[2];
                break;
            case "Left":
                sidePlaced = placedSides[3];
                break;
        }
        return sidePlaced;
    }

    public void setSidePlaced(string side)
    {
        switch (side)
        {
            case "Up":
                placedSides[0] = side;
                break;
            case "Right":
                placedSides[1] = side;
                break;
            case "Down":
                placedSides[2] = side;
                break;
            case "Left":
                placedSides[3] = side;
                break;
        }
    }

    public void resetSide(string side)
    {
        switch (side)
        {
            case "Up":
                placedSides[0] = "";
                break;
            case "Right":
                placedSides[1] = "";
                break;
            case "Down":
                placedSides[2] = "";
                break;
            case "Left":
                placedSides[3] = "";
                break;
        }
    }

    public bool isAnySidePlaced()
    {
        return !(placedSides[0].Equals("") && placedSides[2].Equals("") && placedSides[2].Equals("") && placedSides[3].Equals(""));
    }
}
