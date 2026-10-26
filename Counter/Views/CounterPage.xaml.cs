      namespace Counter.Views;

public partial class CounterPage : ContentPage
{
	public CounterPage()
	{
		InitializeComponent();
	}

    private int currentCounterValue = 0;

    private void CounterIncrease(object sender, EventArgs e)
    {
        if (int.TryParse(counterValueDisplay.Text, out int value))
        {
            currentCounterValue = value + 1;
        }
        else
        {
            currentCounterValue = 1;
        }
        counterValueDisplay.Text = currentCounterValue.ToString();
    }

    private void CounterDecrease(object sender, EventArgs e)
    {
        if (int.TryParse(counterValueDisplay.Text, out int value))
        {
            currentCounterValue = value - 1;
        }
        else
        {
            currentCounterValue = 0;
        }
        counterValueDisplay.Text = currentCounterValue.ToString();
    }
}