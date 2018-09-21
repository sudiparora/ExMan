namespace PerFin.Core.Contracts
{
    public interface IAppSettings
    {

        string DbConnectionString { get; }
        string AWSUserPoolId { get; }
        string AWSClientId { get; }

    }
}
