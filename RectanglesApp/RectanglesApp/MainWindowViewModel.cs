using RectanglesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RectanglesApp
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private RectangleCreationSettingsViewModel rectangleCreationSettingsViewModel;

        private MainRectangleSettingsViewModel mainRectangleSettingsViewModel;

        private RectanglePanelViewModel rectanglePanelViewModel;

        private LogInfoViewModel logInfoViewModel;


        public MainWindowViewModel(RectangleCreationSettingsViewModel rectangleCreationSettingsViewModel, 
                                   MainRectangleSettingsViewModel mainRectangleSettingsViewModel, 
                                   RectanglePanelViewModel rectanglePanelViewModel, 
                                   LogInfoViewModel logInfoViewModel)
        {
            this.rectangleCreationSettingsViewModel = rectangleCreationSettingsViewModel;
            this.mainRectangleSettingsViewModel = mainRectangleSettingsViewModel;
            this.rectanglePanelViewModel = rectanglePanelViewModel;
            this.logInfoViewModel = logInfoViewModel;
            this.rectanglePanelViewModel.LogInfo = logInfoViewModel;
            HookActions();
        }


        private void HookActions()
        {
            UnhookActions();
            rectangleCreationSettingsViewModel.ClearRectanglesAction += rectanglePanelViewModel.ClearRectangles;
            rectangleCreationSettingsViewModel.CreateRectangleAction += AddRectangle;
            mainRectangleSettingsViewModel.RefreshAction += RefreshMainRectangle;
            mainRectangleSettingsViewModel.CheckAction += CheckMainRectangle;
        }

        private void UnhookActions()
        {
            rectangleCreationSettingsViewModel.ClearRectanglesAction -= rectanglePanelViewModel.ClearRectangles;
            rectangleCreationSettingsViewModel.CreateRectangleAction -= AddRectangle;
            mainRectangleSettingsViewModel.RefreshAction -= RefreshMainRectangle;
            mainRectangleSettingsViewModel.CheckAction -= CheckMainRectangle;
        }

        private void AddRectangle()
        {
            rectanglePanelViewModel.AddRectangle(rectangleCreationSettingsViewModel.GetTop(),
                                                     rectangleCreationSettingsViewModel.GetLeft(),
                                                     rectangleCreationSettingsViewModel.GetRight(),
                                                     rectangleCreationSettingsViewModel.GetBottom(),
                                                     rectangleCreationSettingsViewModel.GetSelectedColor(),
                                                     Colors.Black);
        }

        private void RefreshMainRectangle() 
            => rectanglePanelViewModel.RefreshMainRectangle(mainRectangleSettingsViewModel.GetExcludedColors(), mainRectangleSettingsViewModel.GetMargin());

        private void CheckMainRectangle() 
            => rectanglePanelViewModel.CheckMainRectangle(mainRectangleSettingsViewModel.GetExcludedColors(), mainRectangleSettingsViewModel.GetMargin());

    }
}
