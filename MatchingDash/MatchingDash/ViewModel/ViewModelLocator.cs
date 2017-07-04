/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MatchingDash"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MatchingDash.Model;
using MatchingDash.Helpers;
using MatchingDash.Views;
using System;

namespace MatchingDash.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<IDataService, DesignDataService>();
                
            }
            else
            {
                // Create run time view services and models
                SimpleIoc.Default.Register<IDataService, DataService>();
          
            }
            SimpleIoc.Default.Register<INavigationDataService, NavigationDataService>();
            //SimpleIoc.Default.Register<IDialogService, DialogService>();
            //SimpleIoc.Default.Register<MainViewModel>();
            //SimpleIoc.Default.Register<MainMenuViewModel>();
           // SimpleIoc.Default.Register<MainMenu>();
            //string text = string.Empty;
         //   DateTime tim = DateTime.Now;
            var mydialogService = new DialogService();
            var mynavigationService = new NavigationDataService();
            var mydataService = new DataService();
            string path = String.Empty ;
            SimpleIoc.Default.Register<MainViewModel>(() => new MainViewModel(mydialogService, mynavigationService));
            SimpleIoc.Default.Register<RootViewModel>(() => new RootViewModel(mydialogService, mynavigationService));
            SimpleIoc.Default.Register<ImportMenuViewModel>(() => new ImportMenuViewModel(mydialogService, mynavigationService));
            SimpleIoc.Default.Register<MainMenuViewModel>(() => new MainMenuViewModel(mydataService,mydialogService, mynavigationService));
            SimpleIoc.Default.Register<ResultViewModel>(() => new ResultViewModel(mydataService, mydialogService, mynavigationService));
            SimpleIoc.Default.Register<MenuStep2ViewModel>(() => new MenuStep2ViewModel(mydataService, mydialogService, mynavigationService));
            SimpleIoc.Default.Register<ConvertCSV>(() => new ConvertCSV(mydataService, mydialogService,mynavigationService,path));
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public RootViewModel Root
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RootViewModel>();
            }
        }
        public ImportMenuViewModel ImportMenu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ImportMenuViewModel>();
            }
        }
        public MainMenuViewModel MainMenu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainMenuViewModel>();
            }
        }
        public MenuStep2ViewModel MenuStep2
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuStep2ViewModel>();
            }
        }
        public ResultViewModel Result
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ResultViewModel>();
            }
        }
        public ConvertCSV CSView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ConvertCSV>();
            }
        }
       
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}