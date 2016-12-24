namespace MetroWPF.Strategy
{
    public interface IMetroCheckLignesStations
    {
        string fichierLignes { get; set; }
        string sourceLignes { get; set; }
        string fichierStation { get; set; }
        string sourceStation { get; set; }

        string checkLigne();
        string checkStation();
    }
}
