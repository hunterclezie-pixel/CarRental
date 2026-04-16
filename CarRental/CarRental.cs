/* 
Hunter Clezie 
Spring 2026
RCET2265
CarRental
github url: https://github.com/hunterclezie-pixel/CarRental.git
*/
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarRental
{
    public partial class CarRental : Form
    {
        public CarRental()
        {
            InitializeComponent();
            SetDefaults();
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
            AAAMemberCheckBox.Checked = false;
            SeniorCitizenCheckBox.Checked = false;
        }

        private bool ValidateFields()
        {
            bool valid = true;

            if (CustomerNameTextBox.Text != "")
            {
                CustomerNameTextBox.BackColor = Color.White;
            }
            else
            {
                CustomerNameTextBox.BackColor = Color.LightYellow;
                valid = false;
            }

            if (AddressTextBox.Text != "")
            {
                AddressTextBox.BackColor = Color.White;
            }
            else
            {
                AddressTextBox.BackColor = Color.LightYellow;
                valid = false;
            }

            if (CityTextBox.Text != "")
            {
                CityTextBox.BackColor = Color.White;
            }
            else
            {
                CityTextBox.BackColor = Color.LightYellow;
                valid = false;
            }

            if (StateTextBox.Text != "")
            {
                StateTextBox.BackColor = Color.White;
            }
            else
            {
                StateTextBox.BackColor = Color.LightYellow;
                valid = false;
            }

            if (ZipCodeTextBox.Text != "")
            {
                ZipCodeTextBox.BackColor = Color.White;
            }
            else
            {
                ZipCodeTextBox.BackColor = Color.LightYellow;
                valid = false;
            }

            try
            {
                if (int.Parse(BeginningOdometerTextBox.Text) >= 0 && int.Parse(BeginningOdometerTextBox.Text) < (int.Parse(EndingOdometerTextBox.Text)))
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
                valid = false;
            }

            try
            {
                if (int.Parse(EndingOdometerTextBox.Text) >= 0)
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
                valid = false;
            }

            try
            {
                if (int.Parse(NumberDaysTextBox.Text) >= 1 && int.Parse(NumberDaysTextBox.Text) <= 45)
                {
                    NumberDaysTextBox.BackColor = Color.White;
                }
                else
                {
                    NumberDaysTextBox.BackColor = Color.LightYellow;
                    valid = false;
                }
            }
            catch (Exception)
            {
                NumberDaysTextBox.BackColor = Color.LightYellow;
                valid = false;
            }
            return valid;
        }

        private bool ImproperInputMessages()
        {
            bool valid = true;
            string message = "";
            if (CustomerNameTextBox.Text == "")
            {
                message += "Please enter a valid customer name.\n";
            }
            if (AddressTextBox.Text == "")
            {
                message += "Please enter a valid address.\n";
            }
            if (CityTextBox.Text == "")
            {
                message += "Please enter a valid city.\n";
            }
            if (StateTextBox.Text == "")
            {
                message += "Please enter a valid state.\n";
            }
            if (ZipCodeTextBox.Text == "")
            {
                message += "Please enter a valid zip code.\n";
            }
            try
            {
                if (int.Parse(BeginningOdometerTextBox.Text) < 0 || int.Parse(BeginningOdometerTextBox.Text) > (int.Parse(EndingOdometerTextBox.Text)))
                {
                    message += "Please enter a valid beginning odometer reading that is less than or equal to the ending odometer reading.\n";
                }
            }
            catch (Exception)
            {
                message += "Please enter a valid beginning odometer reading that is less than or equal to the ending odometer reading.\n";
            }
            try
            {

                if (int.Parse(EndingOdometerTextBox.Text) < 0)
                {
                    message += "Please enter a valid ending odometer reading.\n";
                }

            }
            catch (Exception)
            {
                message += "Please enter a valid ending odometer reading.\n";
            }
            try
            {
                if (int.Parse(NumberDaysTextBox.Text) < 0 || int.Parse(NumberDaysTextBox.Text) > 45)
                {
                    message += "Please enter a valid number of days (0-45).\n";
                }
            }
            catch (Exception)
            {
                message += "Please enter a valid number of days (0-45).\n";
            }

            if (message != "")
            {
                MessageBox.Show(message);
            }

            return valid;
        }

        decimal CalculateAAADiscount(decimal thisAmount)
        {
            decimal discount = 0;
            if (AAAMemberCheckBox.Checked)
            {
                discount = thisAmount * 0.5m;
            }
            return discount;
        }

        decimal CalculateSeniorDiscount(decimal thisAmount)
        {
            decimal discount = 0;
            if (SeniorCitizenCheckBox.Checked)
            {
                discount = thisAmount * 0.3m;
            }
            return discount;
        }

        private decimal CalculateMilesDriven(decimal milesDriven)
        {
            if (KilometersRadioButton.Checked)
            {
                milesDriven = (decimal.Parse(EndingOdometerTextBox.Text) - decimal.Parse(BeginningOdometerTextBox.Text)) * 0.62m;
            }
            else if (MilesRadioButton.Checked)
            {
                milesDriven = decimal.Parse(EndingOdometerTextBox.Text) - decimal.Parse(BeginningOdometerTextBox.Text);
            }
            DistanceDrivenTextBox.Text = milesDriven.ToString();
            return milesDriven;
        }

        private decimal CalculateMilageCharge(decimal milageCharge)
        {
            if (decimal.Parse(DistanceDrivenTextBox.Text) <= 200)
            { 
                milageCharge = 0.00m;
                MilageChargeTextBox.Text = milageCharge.ToString();
            }
            if (decimal.Parse(DistanceDrivenTextBox.Text) >= 200 && decimal.Parse(DistanceDrivenTextBox.Text) >= 500)
            { 
                milageCharge = decimal.Parse(DistanceDrivenTextBox.Text) * 0.12m;
                MilageChargeTextBox.Text = milageCharge.ToString();
            }
            if (decimal.Parse(DistanceDrivenTextBox.Text) >= 501)
            {
                milageCharge = decimal.Parse(DistanceDrivenTextBox.Text) * 0.10m;
                MilageChargeTextBox.Text = milageCharge.ToString();
            }
            return milageCharge;
        }

        private decimal CalculateDayCharge(decimal dayCharge)
        {
            dayCharge = decimal.Parse(NumberDaysTextBox.Text) * 15.00m;
            DayChargeTextBox.Text = dayCharge.ToString();
            return dayCharge;
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
            ImproperInputMessages();
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {

        }

        //Text Changed Event Handlers below here --------------------------------------------------------------

        private void CustomerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void StateTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void ZipCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void BeginningOdometerTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void EndingOdometerTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void NumberDaysTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }
    }
}
