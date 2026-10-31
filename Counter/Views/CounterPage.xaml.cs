namespace Counter.Views;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public partial class CounterPage : ContentPage
{
    public ObservableCollection<CounterModel> Counters { get; set; } = new();

    private readonly CounterStorage _storage = new();

    public CounterPage()
	{
		InitializeComponent();

        foreach (var counter in _storage.Load())
        {
            Counters.Add(counter);
        }

        BindingContext = this;
    }

    private void CounterIncrease(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is CounterModel counter)
        {
            counter.Increase();
            _storage.Save(Counters);
        }
    }

    private void CounterDecrease(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is CounterModel counter)
        {
            counter.Decrease();
            _storage.Save(Counters);
        }
    }

    private void AddCounter(object sender, EventArgs e)
    {
        string name = CounterNameEntry.Text?.Trim() ?? "";

        if (name == "")
        {
            return;
        }

        Counters.Add(new CounterModel() { Name = name, CounterValue = 0 });
        CounterNameEntry.Text = "";
        _storage.Save(Counters);
    }
}