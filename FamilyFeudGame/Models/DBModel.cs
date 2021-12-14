
using System.Collections.Generic;

/// <summary>
/// Authored by Ryan Schauer
/// The DBModel will manage all the sections and retrieve all the relevant info about them.
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
}
