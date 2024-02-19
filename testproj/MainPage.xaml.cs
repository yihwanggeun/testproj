
namespace testproj;

/**
 * @class MainPage
 * @brief MainPage 클래스는 사용자 인터페이스와 상호작용을 관리합니다.
 *
 * 이 클래스는 사용자의 입력을 처리하고, 애플리케이션의 메인 화면에 대한 로직을 구현합니다.
 */
public partial class MainPage : ContentPage
{

    /**
     * @param stateFlag 사용자가 연산자를 클릭했는지 알려주는 플래그입니다.
     * @param operatorSelected 사용자가 선택한 연산자를 알려줍니다.
     * @param firstNum 연산에서 이미 계산된, 혹은 첫번째 숫자를 저장합니다.
     */
    List<CalculationResult> calculationHistoryList = new List<CalculationResult>();
    bool operatorClicked = false;
    string calHistory = "";
    string operatorSelected = "";
    double firstNum, secondNum;
	public MainPage()
	{
		InitializeComponent();
        calculationHistory.ItemsSource = calculationHistoryList;
    }


    

    /**
    * @brief 숫자 버튼 클릭 시 호출되는 이벤트 핸들러입니다.
    * 
    * 사용자가 숫자 버튼 중 하나를 클릭하면, 해당 숫자의 값을 콘솔에 출력합니다.
    *
    * @param sender 이벤트를 발생시킨 객체입니다.
    * @param e 이벤트에 대한 추가 정보입니다.
    */
    void OnNumberClick(object sender, EventArgs e)
	{
        Button button = (Button)sender;
        string btnText = button.Text;
        calHistory += btnText;
        if((result.Text == "" && btnText != ".") || operatorClicked)
        {
            
            result.Text = "";
            operatorClicked = false;
            
        }

        if(operatorClicked == false && result.Text != "")
        {
            result.Text = "";
        }
        if(result.Text != "" && operatorClicked == true)
        {
            result.Text += "";
        }

        if (btnText == "." && result.Text.Contains("."))
        {
            // Prevent multiple dots
            return;
        }

        result.Text += btnText;

    }

    /**
     * @brief 계산 버튼 클릭 시 호출되는 이벤트 핸들러입니다.
     * 
     * 사용자가 계산 버튼(예: '+', '-', '*', '/') 중 하나를 클릭하면, 해당 연산을 처리합니다.
     *
     * @param sender 이벤트를 발생시킨 객체입니다.
     * @param e 이벤트에 대한 추가 정보입니다.
     */
    void OnCalClick(object sender, EventArgs e)
	{
        Button button = (Button)sender;
        operatorSelected = button.Text;
        calHistory += (" "+ operatorSelected + " ");
        firstNum = double.Parse(result.Text);
        operatorClicked = true;
    }

    
    void OnHistoryItemClicked(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is CalculationResult selectedItem)
        {
            result.Text = selectedItem.Result;
        }
    }

    /**
    * @brief 제출 버튼 클릭 시 호출되는 이벤트 핸들러입니다.
    * 
    * 사용자가 제출 버튼을 클릭하면(예 : '=') 입력된 데이터를 제출합니다.
    * 
    *
    * @param sender 이벤트를 발생시킨 객체입니다.
    * @param e 이벤트에 대한 추가 정보입니다.
    */
    void OnSubmitClick(object sender, EventArgs e)
	{
        secondNum = double.Parse(result.Text);
        calHistory += " = ";
        double resultValue = 0;

        switch (operatorSelected)
        {
            case "+":
                resultValue = firstNum + secondNum;
                break;
            case "-":
                resultValue = firstNum - secondNum;
                break;
            case "*":
                resultValue = firstNum * secondNum;
                break;
            case "%":
                resultValue = firstNum % secondNum;
                break;
            case "/":
                if (secondNum != 0)
                {
                    resultValue = firstNum / secondNum;
                }
                else
                {
                    result.Text = "Error";
                    return;
                }
                break;
            default:
                break;
        }

        result.Text = resultValue.ToString();
        operatorClicked = false;

        // 계산 결과를 기록 리스트에 추가
        calculationHistoryList.Add(new CalculationResult { Result = resultValue.ToString(), CalculationProcess = calHistory + resultValue.ToString() });
        calHistory = "";
        // ListView 갱신
        calculationHistory.ItemsSource = null;
        calculationHistory.ItemsSource = calculationHistoryList;
    }

    void OnSaveClick(object sender, EventArgs e)
    {
       
    }

}



public class CalculationResult
{
    public string CalculationProcess { get; set; } // 연산 과정을 저장할 필드
    public string Result { get; set; } // 연산 결과를 저장할 필드
}
