using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiceRoller : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        DiceValues = new int[1];
        theStateManager = GameObject.FindObjectOfType<StateManager>();
        ps = GameObject.FindObjectsOfType<PlayerStone>();
        //for(var i=0;i<ps.Length;i++)
        //{
        //    Debug.Log("Nombre de las fichas"+ps[i].name+ "indice es:"+i);
        //}
    }

    public StateManager theStateManager;
    private PlayerStone[] ps;

    public int[] DiceValues;


    public Sprite[] DiceImageZero;




    // Update is called once per frame
    void Update()
    {
        if (theStateManager.finalistas == theStateManager.NumberOfPlayers)
        {
            SceneManager.LoadScene("menu");
           
        }
    }

    public void RollTheDice()
    {
        for (var i = 0; i < ps.Length; i++)
        {
            Debug.Log("Nombre de las fichas" + ps[i].name + "indice es:" + i);
        }
        if (theStateManager.isFinish[theStateManager.CurrentPlayerId] == true)
        {
            theStateManager.NewTurn();
            return;
        }
        if (theStateManager.IsDoneRolling == true)
        {
            // We've already rolled this turn.
            return;
        }

        // In Ur, you roll four dice (classically Tetrahedron), which
        // have half their faces have a value of "1" and half have a value
        // of zero.

        // You COULD roll actual physics enabled dice.

        // We are going to use random number generation instead.
       // Debug.Log("longitud penal"+ theStateManager.penal.Length);
        theStateManager.DiceTotal = Random.Range(1, 6);
        
        this.transform.GetChild(0).GetComponent<Image>().sprite = DiceImageZero[theStateManager.DiceTotal-1];
        if (theStateManager.penal[theStateManager.CurrentPlayerId] > 0)
        {
            
            SceneManager.LoadScene("Game");

            theStateManager.IsDoneRolling = true;

            //theStateManager.penal[theStateManager.CurrentPlayerId]--;
            //theStateManager.NewTurn();
        }
        else
        {

        theStateManager.IsDoneRolling = true;
        } 
       // theStateManager.CheckLegalMoves();


        //Debug.Log("Rolled: " + DiceTotal);
    }
}
