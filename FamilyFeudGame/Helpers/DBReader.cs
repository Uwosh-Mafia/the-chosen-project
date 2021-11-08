using OfficeOpenXml;
using System;

public class DBReader
{
    public string dbFileConnectionPath;
    public DBController dbController;

    public DBReader(string dbFileConnectionPath, DBController dbController)
    {
        this.dbFileConnectionPath = dbFileConnectionPath;
        this.dbController = dbController;
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }
}
