namespace GroceryStockManager.Services
{
    public interface IBaseCrudServices<T>
    {
        Task<List<T>> GetAllRecordsAsync();
        Task<T> GetRecordByIdAsync(T Id);
        Task<T> UpdateRecordAsync(T model);
        Task<T> DeleteRecordAsync(T Id);
        Task<T> EditRecordAsync(T model);

    }
}
