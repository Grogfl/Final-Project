using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pointsManager : MonoBehaviour
{
    public Text pointsText;
    private int points;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        UpdatePointsText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsText();
    }
    public void UpdatePointsText()
    {
        pointsText.text = "Points: " + points;
    }
    public bool SpendPoints(int amount)
    {
        if (points >= amount)
        {
            points -= amount;
            return true;
        }
        return false;
    }
}
