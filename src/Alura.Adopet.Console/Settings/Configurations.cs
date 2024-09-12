using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings
{
    public class Configurations
    {
        public static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets("61d71028-6014-4dc4-9e48-04652af5e08e")
                .Build();
        }

        public static AppSettings ApiSetting {
            get {
                var _conf = BuildConfiguration();
                return _conf
                    .GetSection(AppSettings.Section)
                    .Get<AppSettings>() ?? throw new ArgumentException("Seção API não encontrada");
            }
        }

        public static MailSettings MailSetting {
            get {
                var _config = BuildConfiguration();
                return _config
                    .GetSection(MailSettings.EmailSection)
                    .Get<MailSettings>() ??
                    throw new ArgumentException("Seção para configuração do e-mail não encontrada!");
            }
        }
    }
}
