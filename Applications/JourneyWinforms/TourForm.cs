using System.ComponentModel;
using Journey.Models;
using Journey.Storage;

namespace Journey.Applications.ToursWinforms
{
    /// <summary>
    /// Главная форма о туре
    /// </summary>
    public partial class TourForm : Form
    {

        private ToursStorage toursStorage;

        /// <summary>
        /// ctor
        /// </summary>
        public TourForm(ToursStorage toursStorage)
        {
            InitializeComponent();
            this.toursStorage = toursStorage;
            LoadData();

        }

        private void LoadData()
        {
            var tours = new BindingList<Tour>(toursStorage.Tours);

            dataGridView1.DataSource = tours;
            dataGridView1.AutoResizeColumns();
        }

    }
}
