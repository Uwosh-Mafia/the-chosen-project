using System;
using System.Collections.Generic;


/// <summary>
/// Author: Nasir and Ryan 
/// This class handles in application database 
/// Here is where you get the database model, create questions and do things like that 
/// </summary>
public class DBController
{
    private DBModel _database;
    public DBController(DBModel database)
    {
        this._database = database;
    }

    /// <summary>
    /// This all the sections
    /// </summary>
    /// <returns></returns>
    public List<Section> GetSections()
    {
        return _database.GetSections();
    }

    /// <summary>
    /// This method gets the section of a given id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Section GetSection(int id)
    {
        return _database.GetSection(id);
    }

    /// <summary>
    /// This method adds a new section
    /// </summary>
    /// <param name="name"></param>
    public void AddSection(Section section)
    {
        if (section != null)
            _database.AddSection(section);
    }
}

