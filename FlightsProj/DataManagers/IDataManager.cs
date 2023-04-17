namespace FlightsProj.DataManagers
{
    public interface IDataManager
    {
        void Save(string departureLocation, string arrivalLocation, string departureDate, string arrivalDate, string price, string currency);
    }
}