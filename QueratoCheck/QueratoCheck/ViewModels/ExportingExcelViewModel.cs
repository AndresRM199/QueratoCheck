using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using QueratoCheck.Model;
using QueratoCheck.Service;
using Xamarin.Essentials;
using Xamarin.Forms;
using Information = QueratoCheck.Model.Information;

namespace QueratoCheck.ViewModels
{
    public class ExportingExcelViewModel
    {
        public ICommand ExportToExcelCommand { private set; get; }
        private ExcelServices excelService;
        public ObservableCollection<Information> information;


        public ExportingExcelViewModel()
        {
            information = new ObservableCollection<Information>();
            
            ExportToExcelCommand = new Command(async () => await ExportToExcel());
            excelService = new ExcelServices();
        }

       
        async Task ExportToExcel()
        {
            var fileName = $"QueratoconoCheck-{Guid.NewGuid()}.xlsx";
            string filepath = excelService.GenerateExcel(fileName);

            //var data = new ExcelStructure
            //{
            //    Headers = new List<string>() { "ID","Text", "Edad", "Sexo", "Enfermedad", "Fecha", "Resultado" }
            //};
            var header = new List<string>() { "ID", "Text", "Edad", "Sexo", "Enfermedad", "Fecha", "Resultado" };

            var data = new ExcelStructure();
            data.Headers = header;

            //foreach (var item in information)
            //{
            //    data.Values.Add(new List<string>() { item.ID.ToString(), item.Text, item.Edad, item.Sexo, item.Enfermedad, item.Fecha, item.resultado });
            //}

            foreach (var item in information)
            {
                var row = new List<string>()
                {
                    item.ID.ToString(),
                    item.Text, 
                    item.Edad,
                    item.Sexo,
                    item.Enfermedad, 
                    item.Fecha, 
                    item.resultado
                };

                data.Values.Add(row);
            }

            excelService.InsertDataIntoSheet(filepath, "information", data);

            await Launcher.OpenAsync(new OpenFileRequest()
            {
                File = new ReadOnlyFile(filepath)
            });
        }
    }

   
}
