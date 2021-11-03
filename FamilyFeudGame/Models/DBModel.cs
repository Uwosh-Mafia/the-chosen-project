
using System.Collections.Generic;

public class DBModel
{
    public List<Section> game = new();
    public int sectionsCount;

    public DBModel()
    {
        sectionsCount = 0;
    }

    /**
     * This will return the game.
     * A game is a list of sections.
     **/
    public List<Section> GetSections()
    {
        return game;
    }

    /**
     * This will iterate through the list. 
     * If it finds a valid section then it will add it. 
    **/
    public Section GetSection(int findId)
    {
        foreach (var currSection in game)
        {
            int currId = currSection.GetSectionID();
            if(currId == findId)
            {
                return currSection;
            }    
        }
        return null;
    }
    /**
     * This will add a Section to the DBModel.
     * This will change the sectionsCount to the current count. 
    **/
    public void AddSection(Section currSection)
    {
        game.Add(currSection);
        sectionsCount = game.Count;
    }

    /**
     * This will take a new section and an id.
     * This 
    **/
    public void UpdateSection(int id, Section newSection)
    {
        for (int i = 0; i < sectionsCount; i++)
        {
            int currSectionID = game[i].GetSectionID();
            if (id == currSectionID)
            {
                game.Insert(i, newSection);
                game.RemoveAt(i + 1);
                return;
            }
        }
    }
    /**
     * This will find the selected section and delete it from the game 
    **/
    public void DeleteSection(int deleteId)
    {
        for(int i = 0; i < sectionsCount; i++)
        {
            int currSectionID = game[i].GetSectionID();
            if(deleteId == currSectionID)
            {
                game.RemoveAt(i);
                return;
            } 
        }
    }
}
