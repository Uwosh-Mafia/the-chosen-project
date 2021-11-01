
using System.Collections.Generic;

public class DBModel
{
    public List<Section> game = new List<Section>();
    public int sectionsCount;

    public DBModel()
    {
        sectionsCount = 0;
    }

    public List<Section> GetSections()
    {
        return game;
    }

    public Section GetSection(int id)
    {
        return null;
    }

    public void AddSection(Section currSection)
    {

    }

    public void UpdateSection(int id, Section newSection)
    {

    }

    public void DeleteSection(int id)
    {

    }
}
