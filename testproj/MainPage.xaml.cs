namespace testproj;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}


	void OnNumberClick(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		string selected = button.Text;
		Console.WriteLine(selected);
	}

	void OnCalClick(object sender, EventArgs e)
	{

	}

	void OnSubmitClick(object sender, EventArgs e)
	{

	}

	void OnPointClick(object sender, EventArgs e)
	{

	}
	//private void OnCounterClicked(object sender, EventArgs e)
	//{
	//	count++;

	//	if (count == 1)
	//		CounterBtn.Text = $"Clicked {count} time";
	//	else
	//		CounterBtn.Text = $"Clicked {count} times";

	//	SemanticScreenReader.Announce(CounterBtn.Text);
	//}
}


