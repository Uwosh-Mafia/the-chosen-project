
using System.Collections.Generic;

/// <summary>
/// Created by Ryan Schauer 
/// This class retrieves and adds the sections to a 
/// list of sections.
/// </summary>
public class DBModel
{
    private List<Section> _sections;

    public DBModel()
    {
        _sections = new();
    }

    /// <summary>
    /// Returns the list of sections
    /// </summary>
    /// <returns> list of sections </returns>
    public List<Section> GetSections()
    {
        return _sections;
    }

    /// <summary>
    /// Gets the id that correlates with the given id
    /// </summary>
    /// <param name="id"> section id to find </param>
    /// <returns> section with the given id </returns>
    public Section GetSection(int id)
    {
        return _sections.Find(section => section.Id == id);
    }

    /// <summary>
    /// Adds a section to the list of sections
    /// </summary>
    /// <param name="section"> section to add </param>
    public void AddSection(Section section)
    {
        _sections.Add(section);
    }

    /// <summary>
    /// Adds a given list of sections to the list of sections
    /// </summary>
    /// <param name="sections"> list of sections to add </param>
    public void AddSections(List<Section> sections)
    {
        foreach (Section section in sections)
            _sections.Add(section);
    }

    /// <summary>
    /// Returns the total number of sections
    /// </summary>
    /// <returns> number of sections </returns>
    public int GetSectionCount()
    {
        return _sections.Count;
    }
}
