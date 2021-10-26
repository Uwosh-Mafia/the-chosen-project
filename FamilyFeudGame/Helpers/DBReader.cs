using System;

public class DBReader
{
	public String dbFileConnectionPath;
	public DBController dbController;

	public DBReader(String dbFileConnectionPath, DBController dbController)
	{
		this.dbFileConnectionPath = dbFileConnectionPath;
		this.dbController = dbController;
	}
}
