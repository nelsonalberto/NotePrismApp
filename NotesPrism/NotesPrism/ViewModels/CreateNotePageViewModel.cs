using NotesPrism.Helpers;
using NotesPrism.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotesPrism.ViewModels
{
    public class CreateNotePageViewModel : ViewModelBase
    {

        public CreateNotePageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            :base(navigationService, dialogService)
        {
            InitCommands();
        }

        #region Navigation
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Model = parameters.GetValue<FileModel>(Constants.ParamFileModel)?? new FileModel();
        }
        #endregion

        #region Properties
        private string _folderPath = Constants.FilePath;

        private FileModel _model;
        public FileModel Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }
        #endregion

        #region Events
        public ICommand Save { get; protected set; }
        public ICommand Cancel { get; protected set; }
        #endregion

        #region Methods
        void InitCommands()
        {
            Save = new Command(async() =>
            {
                if (!string.IsNullOrEmpty(Model.Text))
                {
                    if (!string.IsNullOrEmpty(Model.FilePath))
                    {
                        File.WriteAllText(Model.FilePath, Model.Text);
                    }
                    else
                    {
                        var _fileName = Path.Combine(_folderPath, $"{Guid.NewGuid()}_AppNotes.txt");
                        File.WriteAllText(_fileName, Model.Text);
                    }

                    await GoBackAsync();
                }
                else 
                {
                    await DialogService.DisplayAlertAsync("Advertencia", "Debe de ingresar texto a la nota", "Aceptar");
                }
            });

            Cancel = new Command(async () =>
            {
                await GoBackAsync();
            });
        }

        #endregion

    }
}
