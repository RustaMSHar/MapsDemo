namespace MapsDemo.View;

public partial class CalculationsPage : ContentPage
{
	public CalculationsPage()
	{
		InitializeComponent();
	}
    private void OnCalculationPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        FuelCalculationLayout.IsVisible = CalculationPicker.SelectedIndex == 0;
        FlightTimeCalculationLayout.IsVisible = CalculationPicker.SelectedIndex == 1;
        FuelReserveCalculationLayout.IsVisible = CalculationPicker.SelectedIndex == 2;
        MaxRangeCalculationLayout.IsVisible = CalculationPicker.SelectedIndex == 3;
        ClimbTimeCalculationLayout.IsVisible = CalculationPicker.SelectedIndex == 4;
        ClimbRateCalculationLayout.IsVisible = CalculationPicker.SelectedIndex == 5;
        DescentTimeCalculationLayout.IsVisible = CalculationPicker.SelectedIndex == 6;
        DescentRateCalculationLayout.IsVisible = CalculationPicker.SelectedIndex == 7;
        ResultLabel.Text = string.Empty;
    }

    private void OnCalculateFuelButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(DistanceEntry.Text, out double distance) &&
            double.TryParse(WeightEntry.Text, out double weight) &&
            double.TryParse(SpeedEntry.Text, out double speed) &&
            double.TryParse(FuelConsumptionRateEntry.Text, out double fuelConsumptionRate))
        {
            double flightTime = distance / speed;
            double totalFuelConsumption = flightTime * fuelConsumptionRate;

            ResultLabel.Text = $"����������� ���������� �������: {totalFuelConsumption:F2} ������";
        }
        else
        {
            ResultLabel.Text = "����������, ������� ���������� ������.";
        }
    }

    private void OnCalculateFlightTimeButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(DistanceFlightTimeEntry.Text, out double distance) &&
            double.TryParse(SpeedFlightTimeEntry.Text, out double speed))
        {
            double flightTime = distance / speed;

            ResultLabel.Text = $"����� ������: {flightTime:F2} �����";
        }
        else
        {
            ResultLabel.Text = "����������, ������� ���������� ������.";
        }
    }

    private void OnCalculateFuelReserveButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(DistanceReserveEntry.Text, out double distance) &&
            double.TryParse(SpeedReserveEntry.Text, out double speed) &&
            double.TryParse(FuelConsumptionRateReserveEntry.Text, out double fuelConsumptionRate) &&
            double.TryParse(FuelReservePercentageEntry.Text, out double reservePercentage))
        {
            double flightTime = distance / speed;
            double totalFuelConsumption = flightTime * fuelConsumptionRate;
            double fuelReserve = totalFuelConsumption * (reservePercentage / 100);

            ResultLabel.Text = $"����������� ����� �������: {fuelReserve:F2} ������";
        }
        else
        {
            ResultLabel.Text = "����������, ������� ���������� ������.";
        }
    }

    private void OnCalculateMaxRangeButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(FuelCapacityEntry.Text, out double fuelCapacity) &&
            double.TryParse(FuelConsumptionRateMaxRangeEntry.Text, out double fuelConsumptionRate) &&
            double.TryParse(SpeedMaxRangeEntry.Text, out double speed))
        {
            double maxRange = (fuelCapacity / fuelConsumptionRate) * speed;

            ResultLabel.Text = $"������������ ��������� ������: {maxRange:F2} ��";
        }
        else
        {
            ResultLabel.Text = "����������, ������� ���������� ������.";
        }
    }

    private void OnCalculateClimbTimeButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(ClimbRateEntry.Text, out double climbRate) &&
            double.TryParse(AltitudeEntry.Text, out double altitude))
        {
            double climbTime = altitude / climbRate;

            ResultLabel.Text = $"����� ������ ������: {climbTime:F2} �����";
        }
        else
        {
            ResultLabel.Text = "����������, ������� ���������� ������.";
        }
    }

    private void OnCalculateClimbRateButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(ClimbTimeEntry.Text, out double climbTime) &&
            double.TryParse(AltitudeClimbRateEntry.Text, out double altitude))
        {
            double climbRate = altitude / climbTime;

            ResultLabel.Text = $"�������� ������ ������: {climbRate:F2} �/���";
        }
        else
        {
            ResultLabel.Text = "����������, ������� ���������� ������.";
        }
    }

    private void OnCalculateDescentTimeButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(DescentRateEntry.Text, out double descentRate) &&
            double.TryParse(AltitudeDescentEntry.Text, out double altitude))
        {
            double descentTime = altitude / descentRate;

            ResultLabel.Text = $"����� ������: {descentTime:F2} �����";
        }
        else
        {
            ResultLabel.Text = "����������, ������� ���������� ������.";
        }
    }

    private void OnCalculateDescentRateButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(DescentTimeEntry.Text, out double descentTime) &&
            double.TryParse(AltitudeDescentRateEntry.Text, out double altitude))
        {
            double descentRate = altitude / descentTime;

            ResultLabel.Text = $"�������� ������: {descentRate:F2} �/���";
        }
        else
        {
            ResultLabel.Text = "����������, ������� ���������� ������.";
        }
    }
}