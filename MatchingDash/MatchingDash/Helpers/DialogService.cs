using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using MatchingDash.Shared;
using MatchingDash.Views;
using MatchingDash.ViewModel;

namespace MatchingDash.Helpers
{
    public class DialogService:IDialogService
    {
       
        public DialogService(string text, DateTime timestamp)
        {
            Text = text;
            Timestamp = timestamp;
        }

        public DialogService()
        {
            // TODO: Complete member initialization
        }
        public string Text
        {
            get;
            set;
        }
        public DateTime Timestamp { get; set; }
        public void Setvalues(string text, DateTime timespan)
        {
            Text = text;
            Timestamp = timespan;
        }
        public string getText()
        {
            return Text;
        }
        public async void ShowProgressDialog()
        {
             RootView progress=new RootView();
            var controller = await progress.ShowProgressAsync("Please wait...", "We are baking some cupcakes!");

            await Task.Delay(50);

          //  controller.SetCancelable(true);

            double i = 0.0;
            while (i < 6.0)
            {
                double val = (i / 100.0) * 20.0;
                controller.SetProgress(val);
                controller.SetMessage("Baking cupcake: " + i + "...");

                if (controller.IsCanceled)
                    break; //canceled progressdialog auto closes.

                i += 1.0;

                await Task.Delay(20);

            }

            await controller.CloseAsync();

            if (controller.IsCanceled)
            {
                await progress.ShowMessageAsync("No cupcakes!", "You stopped baking!");
            }
            else
            {
                await progress.ShowMessageAsync("Cupcakes!", "Your cupcakes are finished! Enjoy!");
            }
        }
      public   ProgressDialogController controller;
      //  RootView progress;
        public async void ProgressDialog(DockManager progress, string word)
        {
             //progress = new RootView();
             controller = await progress.ShowProgressAsync("Please wait...", word);

             Task.Delay(500);

            //  controller.SetCancelable(true);

            double i = 0.0;
            while (i < 6.0)
            {
                double val = (i / 100.0) * 20.0;
                controller.SetProgress(val);
                controller.SetMessage(word+"  in progress: " + i + "...");

                if (controller.IsCanceled)
                    break; //canceled progressdialog auto closes.

                i += 1.0;

                 Task.Delay(200);

            }
             controller.CloseAsync();
           // return progress;
        }
        public async void progressTerminated(DockManager progress, string word){
           // controller = await progress.ShowProgressAsync("Please wait...","...a little moment");
           
           
            //if (controller.IsCanceled)
            //{
            //    await progress.ShowMessageAsync("No cupcakes!", "You stopped baking!");
            //}
            //else
            //{
                await progress.ShowMessageAsync("Done!", word);
           // }
        }
        public async void ResultBarProgress(ResultView res, ResultViewModel vm)
        {
            int totalcount=0;
            
            if(vm.BarValue=="CI"){
                totalcount=vm.Studentci.Count();
            }else if(vm.BarValue=="TeachStep2"){
                 totalcount=vm.Studentstep2.Count();
            }else if(vm.BarValue=="TeachStep1"){
                 totalcount=vm.Studentstep1.Count();
            }
            controller = await res.ShowProgressAsync("Please wait...", vm.NoConditionResult.Count + " counts");
            while (!vm.Done)
            {
                if(totalcount!=0)
                controller.SetProgress((vm.NoConditionResult.Count / totalcount)*100.0);
                controller.SetMessage("Computing Result in progress: " + vm.NoConditionResult.Count + " counts...");
                await Task.Delay(200);
            }
             controller.CloseAsync();
            vm.CanShow = true;         
        }
        public async void ResultBarTerminated(ResultView res, string word)
        {
            await res.ShowMessageAsync("Done!",word);
            await Task.Delay(200);
        }
    }
}
