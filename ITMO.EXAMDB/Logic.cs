using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ITMO.EXAMDB
{
    public class Logic : PropertyChange
    {
        public ObservableCollection<SalesPersonData> Spd { get; set; }
        private SalesPersonData spdEdit = new SalesPersonData();
        private SalesPersonData spdSelected = new SalesPersonData();
        private DBSupport dBSupport;

        #region Commands

        public ICommand Connect { get; }
        public ICommand Add { get; }
        public ICommand Edit { get; }
        public ICommand Delete { get; }

        private void connect(Object p)
        {
            dBSupport = new DBSupport(UserName, Password);
            List<SalesPersonData> a = dBSupport.Select();
            Spd.Clear();
            foreach (SalesPersonData s in a)
                Spd.Add(s);

        }


        private void add(Object p)
        {

        }

        private void edit(Object p)
        {
            dBSupport = new DBSupport(UserName, Password);
            dBSupport.Edit(spdEdit);
            List<SalesPersonData> a = dBSupport.Select();
            Spd.Clear();
            foreach (SalesPersonData s in a)
                Spd.Add(s);
        }

        private void delete(Object p)
        {

        }

        #endregion

        public SalesPersonData SpdSelected
        {
            get => spdSelected;
            set
            {
                spdSelected = value;
                if (spdSelected != null)
                {
                    SpdEdit.BusinessEntityID = spdSelected.BusinessEntityID;
                    SpdEdit.ModifiedDate = spdSelected.ModifiedDate;
                    SpdEdit.SalesLastYear = spdSelected.SalesLastYear;
                    SpdEdit.TerritoryID = spdSelected.TerritoryID;
                    SpdEdit = SpdEdit;
                }
            }
        }
        public SalesPersonData SpdEdit
        {
            get => spdEdit;
            set
            {
                spdEdit = value;
                OnPropertyChanged();
            }
        }
        public string UserName {get; set; }
        public string Password { get; set; }



        public Logic()
        {
            Connect = new Command(connect);
            Add = new Command(add);
            Edit = new Command(edit);
            Delete = new Command(delete);
            Spd = new ObservableCollection<SalesPersonData>();
            #region tutorial
         
            #endregion
        }
    }
}
