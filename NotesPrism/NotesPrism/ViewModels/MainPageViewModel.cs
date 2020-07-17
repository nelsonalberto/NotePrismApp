using ImTools;
using NotesPrism.Helpers;
using NotesPrism.Models;
using NotesPrism.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotesPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            InitCommands();
        }

        #region Navigation
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            GetAllNotes();
        }

        #endregion

        #region Properties
        private string _folderPath = Constants.FilePath;

        private ObservableCollection<FileModel> _files;
        public ObservableCollection<FileModel> Files
        {
            get { return _files; }
            set { SetProperty(ref _files, value); }
        }
        #endregion

        #region Commands
        public ICommand SelectCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        #endregion

        #region Methods
        void InitCommands() 
        {
            SelectCommand = new Command<FileModel>(async (item) =>
            {
                await PushPageAsync(nameof(CreateNotePage),(Constants.ParamFileModel,item));
            });

            CreateCommand = new Command(async () =>
            {
                await PushPageAsync(nameof(CreateNotePage));
            });

            DeleteCommand = new Command<FileModel>(async (item) =>
            {
                if (await DialogService.DisplayAlertAsync("Eliminar nota", "¿Desea eliminar esta nota?", "Sí", "No"))
                {
                    File.Delete(item.FilePath);
                    GetAllNotes();
                }
            });
        }
        void GetAllNotes() 
        {
            var files = Directory.GetFiles(_folderPath, "*_AppNotes.txt");

            Files = new ObservableCollection<FileModel>(files.Select((x,i) => 
            {
                i = i + 1;

                var textPreview = File.ReadAllLines(x)[0];

                return new FileModel
                {
                    FileName = $"File{i}",
                    FilePath = x,
                    TextPreview = (textPreview.Length > 25)? $"{textPreview.Substring(0,25)}...": textPreview,
                    Text = File.ReadAllText(x),
                    Date = File.GetCreationTime(x).ToString("dd/MM/yyyy")
                };

            }).ToList());
        }
        #endregion


    }
}
