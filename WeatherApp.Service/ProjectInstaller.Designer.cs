
using System.ServiceProcess;

namespace WeatherApp.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.weatherAppServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.weatherAppServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // weatherAppServiceProcessInstaller
            //
            this.weatherAppServiceProcessInstaller.Account = ServiceAccount.LocalSystem;
            this.weatherAppServiceProcessInstaller.Password = null;
            this.weatherAppServiceProcessInstaller.Username = null;
            // 
            // weatherAppServiceInstaller
            // 
            this.weatherAppServiceInstaller.ServiceName = "WeatherAppService";
            this.weatherAppServiceInstaller.DisplayName = "Weather Application: Service";
            this.weatherAppServiceInstaller.Description = "Service to indicate the weather at Santo Domingo's City.";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.weatherAppServiceProcessInstaller,
            this.weatherAppServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller weatherAppServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller weatherAppServiceInstaller;
    }
}