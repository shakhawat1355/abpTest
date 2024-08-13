using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Encryption;

namespace MAS.FloraFire.ClientPortal.Services;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IStringEncryptionService))]
public class CustomEncryptionService : StringEncryptionService
{
    private readonly string _passPhrase;
    private readonly byte[] _salt;
    private readonly string _jsonFile = "appsettings.secrets.json";

    public CustomEncryptionService(IOptions<AbpStringEncryptionOptions> options)
        : base(options)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(_jsonFile, optional: false, reloadOnChange: true);
        IConfigurationRoot config = builder.Build();

        _passPhrase = config.GetValue<string>("encryptionSecrets:passPhrase")!;
        var salt = config.GetValue<string>("encryptionSecrets:salt")!;
        _salt = Encoding.UTF8.GetBytes(salt);
    }

    public override string? Encrypt(
        string? plainText,
        string? passPhrase = null,
        byte[]? salt = null
    )
    {
        return base.Encrypt(plainText, _passPhrase, _salt);
    }

    public override string? Decrypt(
        string? cipherText,
        string? passPhrase = null,
        byte[]? salt = null
    )
    {
        return base.Decrypt(cipherText, _passPhrase, _salt);
    }
}
