namespace WpfApp.PL.Interfaces
{
    public interface IDataErrorInfo
    {
        string Error { get; set; }
        string this[string columnName] { get; }
    }
}