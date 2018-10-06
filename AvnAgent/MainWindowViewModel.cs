using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace AvnAgent
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        //Implement the INotifyPropertyChanged interface 
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The helper method
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region FIELDS
        private string txtMainTitle;
        private string txtSubTitle;

        #endregion

        #region PROPERTIES

        //Binding string for main content's title
        public string TxtMainTitle { get => txtMainTitle; set { txtMainTitle = value; OnPropertyChanged(); } }

        //Binding string for sub information on content
        public string TxtSubTitle { get => txtSubTitle; set { txtSubTitle = value; OnPropertyChanged(); }}


        #endregion

        public MainWindowViewModel()
        {
            this.txtMainTitle = "Avn Project Using WcF";
            this.txtSubTitle = "Subtitle display here";
        }

    }
}
