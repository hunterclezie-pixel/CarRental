/* 
Hunter Clezie 
Spring 2026
RCET2265
CarRental
github url: https://github.com/hunterclezie-pixel/CarRental.git
*/
namespace CarRental
{
    public partial class CarRental : Form
    {
        public CarRental()
        {
            InitializeComponent();
            SetDefaults();
            ValidateCalculateButton();
        }

        //Custom Methids below here --------------------------------------------------------------

        void SetDefaults()
        {
            CustomerNameTextBox.Text = "";
            CustomerNameTextBox.BackColor = Color.LightYellow;
            AddressTextBox.Text = "";
            AddressTextBox.BackColor = Color.LightYellow;
            CityTextBox.Text = "";
            CityTextBox.BackColor = Color.LightYellow;
            StateTextBox.Text = "";
            StateTextBox.BackColor = Color.LightYellow;
            ZipCodeTextBox.Text = "";
            ZipCodeTextBox.BackColor = Color.LightYellow;
            BeginningOdometerTextBox.Text = "";
            BeginningOdometerTextBox.BackColor = Color.LightYellow;
            EndingOdometerTextBox.Text = "";
            EndingOdometerTextBox.BackColor = Color.LightYellow;
            NumberDaysTextBox.Text = "";
            NumberDaysTextBox.BackColor = Color.LightYellow;
            SummaryButton.Enabled = false;
            MilesRadioButton.Checked = true;
        }

        private bool ValidateFields()
        {
            bool valid = true;
            string message = "";

            if (CustomerNameTextBox.Text != "")
            {
                CustomerNameTextBox.BackColor = Color.White;
            }
            else
            {
                CustomerNameTextBox.BackColor = Color.LightYellow;
                message += "Please enter a valid customer name.\n";
                valid = false;
            }

            if (AddressTextBox.Text != "")
            {
                AddressTextBox.BackColor = Color.White;
            }
            else
            {
                AddressTextBox.BackColor = Color.LightYellow;
                message += "Please enter a valid address.\n";
                valid = false;
            }

            if (CityTextBox.Text != "")
            {
                CityTextBox.BackColor = Color.White;
            }
            else
            {
                CityTextBox.BackColor = Color.LightYellow;
                message += "Please enter a valid city.\n";
                valid = false;
            }

            if (StateTextBox.Text != "")
            {
                StateTextBox.BackColor = Color.White;
            }
            else
            {
                StateTextBox.BackColor = Color.LightYellow;
                message += "Please enter a valid state.\n";
                valid = false;
            }

            if (ZipCodeTextBox.Text != "")
            {
                ZipCodeTextBox.BackColor = Color.White;
            }
            else
            {
                ZipCodeTextBox.BackColor = Color.LightYellow;
                message += "Please enter a valid zip code.\n";
                valid = false;
            }

            try
            {
                if (int.Parse(BeginningOdometerTextBox.Text) >= 0 && int.Parse(BeginningOdometerTextBox.Text) <= (int.Parse(EndingOdometerTextBox.Text)))
                {
                    BeginningOdometerTextBox.BackColor = Color.White;
                }
                else
                {
                    BeginningOdometerTextBox.BackColor = Color.LightYellow;
                    valid = false;
                }
            }
            catch (Exception)
            {
                BeginningOdometerTextBox.BackColor = Color.LightYellow;
                message += "Please enter a valid beginning odometer reading that is less than or equal to the ending odometer reading.\n";
                valid = false;
            }

            try
            {
                if (int.Parse(EndingOdometerTextBox.Text) == 0)
                {
                    EndingOdometerTextBox.BackColor = Color.White;
                }
                else
                {
                    EndingOdometerTextBox.BackColor = Color.LightYellow;
                    valid = false;
                }
            }
            catch (Exception)
            {
                EndingOdometerTextBox.BackColor = Color.LightYellow;
                message += "Please enter a valid ending odometer reading.\n";
                valid = false;
            }

            try
            {
                if (int.Parse(NumberDaysTextBox.Text) >= 0 && int.Parse(NumberDaysTextBox.Text) <= 45)
                {
                    EndingOdometerTextBox.BackColor = Color.White;
                }
                else
                {
                    EndingOdometerTextBox.BackColor = Color.LightYellow;
                    valid = false;
                }
            }
            catch (Exception)
            {
                EndingOdometerTextBox.BackColor = Color.LightYellow;
                message += "Please enter a valid number of days (0-45).\n";
                valid = false;
            }

            if (message != "")
            {
                valid = false;
                MessageBox.Show(message);
            }

            return valid;
        }

        void ValidateCalculateButton()
        {
            
        }

        private double KilometersToMiles(double kilometers)
        {
            return kilometers * 0.62;
        }

        //Event Handlers below here --------------------------------------------------------------

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            ValidateFields();
        }
    }
}
