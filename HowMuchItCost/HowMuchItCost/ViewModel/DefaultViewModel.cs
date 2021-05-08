namespace HowMuchItCost.API.ViewModel
{
    public class DefaultViewModel<T>
    {
        public DefaultViewModel()
        {

        }

        public DefaultViewModel(T result) : this()
        {
            Result = result;
        }

        public T Result { get; set; }
    }
}
