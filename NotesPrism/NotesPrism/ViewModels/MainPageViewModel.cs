using ImTools;
using NotesPrism.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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
        #region Properties

        private string _Text;

        public string Text
        {
            get { return _Text; }
            set { SetProperty(ref _Text, value); }
        }

        #endregion

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            InitCommands();
        }

        #region Navigation
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            GetAllNotes();
        }
        #endregion

        #region Properties
        private string _folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        private ObservableCollection<FileModel> _files;
        public ObservableCollection<FileModel> Files
        {
            get { return _files; }
            set { SetProperty(ref _files, value); }
        }
        #endregion

        #region Events

        public ICommand Save { get; protected set; }

        public ICommand Cancel { get; protected set; }

        #endregion

        #region Methods
        void InitCommands() 
        {
            Save = new Command(() =>
            {
                var _fileName = Path.Combine(_folderPath, $"{Guid.NewGuid()}_AppNotes.txt");

                File.WriteAllText(_fileName, Text);

                Text = string.Empty;

                GetAllNotes();

            });

            Cancel = new Command(() =>
            {
                Text = string.Empty;
            });
        }

        void GetAllNotes() 
        {
            var files = Directory.GetFiles(_folderPath, "*_AppNotes.txt");

            Files = new ObservableCollection<FileModel>(files.Select((x,i) => 
            {
                i = i + 1;
                return new FileModel
                {
                    FileName = $"Nota {i}",
                    FilePath = x,
                    Text = File.ReadAllText(x)
                };

            }).ToList());
        }
        #endregion


    }
}
