namespace AtendimentoMultiTenant.Web.CommonArea.Interfaces
{
    public interface IStorageService
    {
        Task SetItem(string key, string data);
        Task SetListItem(IEnumerable<Item> listItems);
        Task GetItem(string key);
    }
}
