using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;

namespace excelgenyo
{
    public partial class MainWindow : Window
    {
        private DataTable excelDataTable = new DataTable();
        private string inputPath = string.Empty;
        private string outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.xlsx");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Excel fájlok (*.xlsx)|*.xlsx|Összes (*.*)|*.*",
                Title = "Válassz beolvasandó fájlt"
            };

            if (dialog.ShowDialog() == true)
            {
                inputPath = dialog.FileName;
                FilePathLabel.Text = $"Betöltött fájl: {Path.GetFileName(inputPath)}";
                StatusLabel.Text = "";
                LoadExcel();
            }
        }

        private void LoadExcel()
        {
            if (string.IsNullOrEmpty(inputPath) || !File.Exists(inputPath))
            {
                MessageBox.Show("Nincs érvényes fájl kiválasztva!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                XLWorkbook workbook = new XLWorkbook(inputPath);
                try
                {
                    var worksheet = workbook.Worksheet(1);

                    excelDataTable.Clear();
                    excelDataTable.Columns.Clear();

                    // Oszlopok hozzáadása (alapértelmezett, ha nincs fejléc)
                    int maxCols = 0;
                    foreach (var row in worksheet.RowsUsed().Take(1)) // Első sorból maxCols
                    {
                        maxCols = row.CellsUsed().Count();
                    }
                    for (int i = 0; i < maxCols; i++)
                    {
                        excelDataTable.Columns.Add($"Oszlop{i + 1}", typeof(string));
                    }

                    // Adatok betöltése
                    foreach (var row in worksheet.RowsUsed())
                    {
                        var dataRow = excelDataTable.NewRow();
                        int colIndex = 0;
                        foreach (var cell in row.CellsUsed())
                        {
                            var cellValue = cell.IsEmpty() ? "" : cell.Value.ToString();
                            dataRow[colIndex] = cellValue;
                            colIndex++;
                        }
                        excelDataTable.Rows.Add(dataRow);
                    }

                    DataPreview.ItemsSource = excelDataTable.DefaultView;

                    MessageBox.Show($"Sikeresen beolvasva {excelDataTable.Rows.Count} sor és {maxCols} oszlop!", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                finally
                {
                    workbook.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a beolvasás során: {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            if (excelDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Nincs adat az exportáláshoz! Előbb tölts be egy fájlt.", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                XLWorkbook newWorkbook = new XLWorkbook();
                try
                {
                    var newWorksheet = newWorkbook.Worksheets.Add("Kimenet");

                    // Fejléc hozzáadása
                    for (int c = 0; c < excelDataTable.Columns.Count; c++)
                    {
                        newWorksheet.Cell(1, c + 1).Value = excelDataTable.Columns[c].ColumnName;
                    }

                    // Adatok
                    for (int r = 0; r < excelDataTable.Rows.Count; r++)
                    {
                        for (int c = 0; c < excelDataTable.Columns.Count; c++)
                        {
                            var cell = newWorksheet.Cell(r + 2, c + 1);
                            var value = excelDataTable.Rows[r][c];
                            cell.Value = value == null ? "" : value.ToString();
                            if (double.TryParse(value?.ToString(), out double numValue))
                            {
                                cell.Style.NumberFormat.Format = "0.00";
                            }
                        }
                    }

                    newWorksheet.Columns().AdjustToContents();

                    newWorkbook.SaveAs(outputPath);
                    StatusLabel.Text = $"Sikeresen exportálva: {outputPath}";
                    MessageBox.Show($"Sikeresen exportálva: {outputPath}", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                finally
                {
                    newWorkbook.Dispose();
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Hiba az exportálás közben!";
                MessageBox.Show($"Hiba az exportálás során: {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}