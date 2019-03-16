using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csvData : MonoBehaviour
{
    public TextAsset testing;

    // Use this for initialization
    void Start()
    {
        Load(testing);

        Debug.Log(FindAll_ellos_ellas("3"));

    }

    
    public class Row
    {
        public string yo;
        public string tú;
        public string él_ella_usted;
        public string nosotros_nosotras;
        public string ustedes;
        public string ellos_ellas;
        public string I;
        public string you_informal;
        public string he_she_you_formal;
        public string we_masculine_we_feminine;
        public string you_all;
        public string they_masculine_they_feminine;

    }

    List<Row> rowList = new List<Row>();
    bool isLoaded = false;

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public List<Row> GetRowList()
    {
        return rowList;
    }

    public void Load(TextAsset csv)
    {
        rowList.Clear();
        string[][] grid = CsvParser2.Parse(csv.text);
        for (int i = 1; i < grid.Length; i++)
        {
            Row row = new Row();
            row.yo = grid[i][0];
            row.tú = grid[i][1];
            row.él_ella_usted = grid[i][2];
            row.nosotros_nosotras = grid[i][3];
            row.ustedes = grid[i][4];
            row.ellos_ellas = grid[i][5];
            row.I = grid[i][6];
            row.you_informal = grid[i][7];
            row.he_she_you_formal = grid[i][8];
            row.we_masculine_we_feminine = grid[i][9];
            row.you_all = grid[i][10];
            row.they_masculine_they_feminine = grid[i][11];

            rowList.Add(row);
        }
        isLoaded = true;
    }

    public int NumRows()
    {
        return rowList.Count;
    }

    public Row GetAt(int i)
    {
        if (rowList.Count <= i)
            return null;
        return rowList[i];
    }

    public Row Find_yo(string find)
    {
        return rowList.Find(x => x.yo == find);
    }
    public List<Row> FindAll_yo(string find)
    {
        return rowList.FindAll(x => x.yo == find);
    }
    public Row Find_tú(string find)
    {
        return rowList.Find(x => x.tú == find);
    }
    public List<Row> FindAll_tú(string find)
    {
        return rowList.FindAll(x => x.tú == find);
    }
    public Row Find_él_ella_usted(string find)
    {
        return rowList.Find(x => x.él_ella_usted == find);
    }
    public List<Row> FindAll_él_ella_usted(string find)
    {
        return rowList.FindAll(x => x.él_ella_usted == find);
    }
    public Row Find_nosotros_nosotras(string find)
    {
        return rowList.Find(x => x.nosotros_nosotras == find);
    }
    public List<Row> FindAll_nosotros_nosotras(string find)
    {
        return rowList.FindAll(x => x.nosotros_nosotras == find);
    }
    public Row Find_ustedes(string find)
    {
        return rowList.Find(x => x.ustedes == find);
    }
    public List<Row> FindAll_ustedes(string find)
    {
        return rowList.FindAll(x => x.ustedes == find);
    }
    public Row Find_ellos_ellas(string find)
    {
        return rowList.Find(x => x.ellos_ellas == find);
    }
    public List<Row> FindAll_ellos_ellas(string find)
    {
        return rowList.FindAll(x => x.ellos_ellas == find);
    }
    public Row Find_I(string find)
    {
        return rowList.Find(x => x.I == find);
    }
    public List<Row> FindAll_I(string find)
    {
        return rowList.FindAll(x => x.I == find);
    }
    public Row Find_you_informal(string find)
    {
        return rowList.Find(x => x.you_informal == find);
    }
    public List<Row> FindAll_you_informal(string find)
    {
        return rowList.FindAll(x => x.you_informal == find);
    }
    public Row Find_he_she_you_formal(string find)
    {
        return rowList.Find(x => x.he_she_you_formal == find);
    }
    public List<Row> FindAll_he_she_you_formal(string find)
    {
        return rowList.FindAll(x => x.he_she_you_formal == find);
    }
    public Row Find_we_masculine_we_feminine(string find)
    {
        return rowList.Find(x => x.we_masculine_we_feminine == find);
    }
    public List<Row> FindAll_we_masculine_we_feminine(string find)
    {
        return rowList.FindAll(x => x.we_masculine_we_feminine == find);
    }
    public Row Find_you_all(string find)
    {
        return rowList.Find(x => x.you_all == find);
    }
    public List<Row> FindAll_you_all(string find)
    {
        return rowList.FindAll(x => x.you_all == find);
    }
    public Row Find_they_masculine_they_feminine(string find)
    {
        return rowList.Find(x => x.they_masculine_they_feminine == find);
    }
    public List<Row> FindAll_they_masculine_they_feminine(string find)
    {
        return rowList.FindAll(x => x.they_masculine_they_feminine == find);
    }


}
	
