namespace OW2ScoreboardController.Properties {


    // This class allows you to handle specific events in your configuration class:
    //  - The SettingChanging event is fired before the setting value is changed.
    //  - PropertyChanged event is fired after setting value is changed.
    //  - The SettingsLoaded event is fired after the settings have been loaded.
    //  - SettingsSaving event is fired before settings are saved.
    internal sealed partial class Settings {
        
        public Settings() {
            // // To add configuration save and change event handlers, uncomment the following lines:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }

        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Add code here to handle the SettingChangingEvent event.
        }

        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code here to handle the SettingsSaving event.
        }
    }
}
