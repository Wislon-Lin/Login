using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour
{
    //從資料庫撈東西
    public string[] items; //宣告字串容器

    public int[] Costs;  //宣告Cost 變數 Type是 int

    public string[] Names; 

    IEnumerator Start()
    {
        WWW itemsData = new WWW("http://localhost/Cool_YT_RPG/ItemsData.php");

        yield return itemsData;

        string itemsDataString = itemsData.text;  //宣告string容器裝入itemsData.text


        items = itemsDataString.Split(';');


        int.TryParse(GetDataValue(items[0], "Cost:"), out Costs[0]);
        int.TryParse(GetDataValue(items[1], "Cost:"), out Costs[1]);
        int.TryParse(GetDataValue(items[2], "Cost:"), out Costs[2]);

        print(Costs[0] + "Printf"); print(Costs[1] + "Printf"); print(Costs[2] + "Printf");

        

        GetDataValue(items[0], "Name:");

        GetDataValue(items[1], "Name:");

        GetDataValue(items[2], "Name:");

        CreateUserCost();

    }
    public int i;
    string GetDataValue(string data, string index)
    {
        string Name = data.Substring(data.IndexOf(index) + index.Length);

        
        if (Name.Contains("|"))
        {
            Names[i] = Name.Remove(Name.IndexOf("|"));     
        }


        return Name;

    }


    public Text NameText;
    public Text CostText;
    void Update()
    {
        Debug.Log(Database.Costsnumber+ "Database.Costsnumber");
        NameText.text = "使用者"+Database.user + "以登入" ;
        CostText.text = Costs[Database.Costsnumber].ToString();      
    }
    public int k ;
   
    void  CreateUserCost()
    {
        for (k=0; k < Names.Length; k++)
        {
          
            if (Database.user== "Zoyt")
            {
                Database.Costsnumber = 0;
              
                break;
            }
            else if(Database.user == "Thank")
            {
                Database.Costsnumber = 1;
                break;
            }
            else if(Database.user == "Oreo")
            {
                Database.Costsnumber = 2;
                break;
            }


        }
     

    }

}
    public static class Database
    {
        public static string user;
        public static int Cost;
        public static int Costsnumber;
    }


