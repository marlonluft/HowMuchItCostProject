namespace HowMuchItCost.API.ViewModel
{
    public class ApiErrorViewModel
    {
        public string Message { get; set; }
        public bool HasError { get; set; }
        public string Detail { get; set; }

        public ApiErrorViewModel(string message)
        {
            Message = message;
            HasError = true;
        }
    }
}
