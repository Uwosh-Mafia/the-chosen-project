using OfficeOpenXml;
using System;
using System.IO;
using System.Threading.Tasks;

/// <summary>
/// Author: NASIR 
/// This class is responsible for data from the database 
/// It creates models for all the database we need things like, creating sections, creating questions etc. 
/// </summary>
public class DBReader
{
    private DBController dbController;
    private FileInfo file;
    public DBReader(FileInfo file, DBController dbController)
    {
        this.dbController = dbController;
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        // Check if the file exists 
        if (!file.Exists)
            throw new NotImplementedException("File doesn't exists");
        this.file = file;
    }

    /// <summary>
    /// This public method reads the excel sheet
    /// </summary>
    /// <returns></returns>
    public async Task loadExcelFile()
    {
        using var package = new ExcelPackage(file);
        await package.LoadAsync(file);

        for (int i = 0; i < package.Workbook.Worksheets.Count; i++)
        {
            Section section = await loadSectionFromExcel(package, i);
            dbController.AddSection(section);
        }
    }

    /// <summary>
    /// This will load the selected section.
    /// </summary>
    /// <param name="package"></param>
    /// <param name="sectionID"></param>
    /// <returns></returns>
    private async Task<Section> loadSectionFromExcel(ExcelPackage package, int sectionID = 0)
    {
        ExcelWorksheet ws = package.Workbook.Worksheets[PositionID: sectionID];
        Section section = new(sectionID + 1, ws.Name); // section starts 0; we want 1

        // Column number will keep track of questions, since our questions are columns 
        int column = 1;

        // While we still have questions in that column of the first row, keep reading
        while (string.IsNullOrWhiteSpace(ws.Cells[1, column].Value?.ToString()) == false)
        {
            Question question = readQuestionFromExcel(ws, column);
            if (question == null)
            {
                // If there is an error and we can't read any cell 
                // remove everythig have already read and return null 
                section.clear();
                section = null;
                break;
            }

            section.AddQuestion(question);
            // The question cell spans two colums, that is why we need to go right 2 colums each
            column += 2;
        }
        return section;
    }


    /// <summary>
    /// This private reads every question and returns the question
    /// </summary>
    /// <param name="ws"></param>
    /// <param name="column"></param>
    /// <returns></returns>
    private Question readQuestionFromExcel(ExcelWorksheet ws, int column)
    {
        try
        {
            int row = 1;
            Question question = new(column);

            // While we still have more rows (answers) in this column, keep reading 
            while (string.IsNullOrWhiteSpace(ws.Cells[row, column].Value?.ToString()) == false)
            {
                if (row == 1)
                {
                    question.Text = ws.Cells[row, column].Value.ToString();
                    row++;
                }
                else
                {
                    String text = ws.Cells[row, column].Value.ToString();
                    int points;
                    // If there is no points or points can not be int, assume the points are 0
                    bool success = int.TryParse(ws.Cells[row, column + 1].Value?.ToString(), out points);

                    if (row < 10) {
                        Answer answer = new(row - 1, text, success ? points : 0);
                        question.AddAnswer(answer);
                    }
                    row++;
                }
            }
            return question;
        }
        catch (Exception err)
        {
            return null;
        }
    }
}
