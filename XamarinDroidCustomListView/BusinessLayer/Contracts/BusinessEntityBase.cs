using SQLite;

namespace XamarinDroidCustomListView.BusinessLayer.Contracts
{
    public abstract class BusinessEntityBase : IBusinessEntity
    {
        protected BusinessEntityBase()
        {
            
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}